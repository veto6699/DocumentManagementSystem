using DocumentManagementSystem.Shared;
using DocumentManagementSystem.Shared.OpenApi;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DocumentManagementSystem.Server.Data;

namespace DocumentManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(ILogger<DocumentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<OpenAPIRoot?> Get(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }

            code = code.ToLower();

            var db = HttpContext.RequestServices.GetService<DocumentDbContext>();

            var document = db.Get(code);

            if (document is not null && document.OpenAPI is not null)
            {
                return document.OpenAPI;
            }
            else
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
        }

        [HttpPost]
        public async Task Add(Document args)
        {
            if (string.IsNullOrWhiteSpace(args.Code))
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }

            args.Code = args.Code.ToLower();

            var db = HttpContext.RequestServices.GetService<DocumentDbContext>();

            try
            {
                db.Add(args);
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }

            HttpContext.Response.StatusCode = 204;
            return;
        }
    }
}
