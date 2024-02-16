using DocumentManagementSystem.Server.Data;
using DocumentManagementSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace DocumentManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortDescriptionController : ControllerBase
    {
        private readonly ILogger<ShortDescriptionController> _logger;

        public ShortDescriptionController(ILogger<ShortDescriptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<ShortDescription>> GetAll()
        {
            var db = HttpContext.RequestServices.GetService<ShortDescriptionDbContext>();
            return db.GetAll();
        }

        [HttpPost]
        public async Task Add(ShortDescription args)
        {
            var db = HttpContext.RequestServices.GetService<ShortDescriptionDbContext>();

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
