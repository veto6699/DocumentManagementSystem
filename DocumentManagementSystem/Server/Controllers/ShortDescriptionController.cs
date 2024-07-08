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
        private readonly ShortDescriptionDbContext _db;

        public ShortDescriptionController(ILogger<ShortDescriptionController> logger, ShortDescriptionDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<List<ShortDescription>> GetAll()
        {
            return await _db.GetAll();
        }

        [HttpPost]
        public async Task Add(ShortDescription args)
        {
            try
            {
                await _db.Add(args);
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
