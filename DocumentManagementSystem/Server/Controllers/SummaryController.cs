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
    public class SummaryController(ILogger<SummaryController> logger, SummaryDbContext db) : ControllerBase
    {
        private readonly ILogger<SummaryController> _logger = logger;
        private readonly SummaryDbContext _db = db;

        [HttpGet]
        public async Task<List<SummaryResponse>> Get()
        {
            var summaries = await _db.GetAll();

            var summaryResponse = new List<SummaryResponse>(summaries.Count);

            foreach (var summary in summaries)
            {
                SummaryResponse content = new()
                {
                    Code = summary.Code,
                    Name = summary.Name
                };

                if(summary.Description is not null)
                    content.Description = summary.Description;

                summaryResponse.Add(summary.GetDTOResponse());
            }

            return summaryResponse;
        }

        [Authorize]
        [HttpPost]
        public async Task Add(SummaryRequest args)
        {
            try
            {
                await _db.Add(new(args));
            }
            catch(ArgumentException ex)
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
