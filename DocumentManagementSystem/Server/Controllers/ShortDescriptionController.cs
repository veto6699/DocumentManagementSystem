using DocumentManagementSystem.Server.Data;
using DocumentManagementSystem.Shared;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace DocumentManagementSystem.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с кратким описанием документации
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShortDescriptionController(ILogger<ShortDescriptionController> logger, ShortDescriptionDbContext db) : ControllerBase
    {
        private readonly ILogger<ShortDescriptionController> _logger = logger;
        private readonly ShortDescriptionDbContext _db = db;

        [HttpGet]
        public async Task<List<ShortDescriptionResponse>> GetAll()
        {
            var descriptions = await _db.GetAll();

            var descriptionsResponse = new List<ShortDescriptionResponse>(descriptions.Count);

            foreach (var description in descriptions)
                descriptionsResponse.Add(new(description));

            return descriptionsResponse;
        }

        [Authorize]
        [HttpPost]
        public async Task Add(ShortDescriptionRequest args)
        {
            try
            {
                await _db.Add(new(args));
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
