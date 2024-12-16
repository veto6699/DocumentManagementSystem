using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Server.Data;
using Microsoft.AspNetCore.Authorization;
using DocumentManagementSystem.Shared.Responses;
using DocumentManagementSystem.Shared.Requests;

namespace DocumentManagementSystem.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с документацией
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DocumentController(ILogger<DocumentController> logger, DocumentDbContext db) : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger = logger;
        private readonly DocumentDbContext _db = db;

        [HttpGet]
        public async Task<DocumentResponse?> Get(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                code = code.ToLower();

                var document = await _db.Get(code);

                if (document is not null && document.OpenAPI is not null)
                {
                    return document.GetDTOResponse();
                }
                else
                {
                    HttpContext.Response.StatusCode = 404;
                    return null;
                }
            }

            HttpContext.Response.StatusCode = 400;
            return null;
        }

        [Authorize]
        [HttpPost]
        public async Task Add(DocumentRequest args)
        {
            if (string.IsNullOrWhiteSpace(args.Code))
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }

            args.Code = args.Code.ToLower();

            try
            {
                await _db.Add(new(args));
            }
            catch (ArgumentException ex)
            {
                HttpContext.Response.StatusCode = 409;
                return;
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
                return;
            }

            HttpContext.Response.StatusCode = 200;
            return;
        }
    }
}
