using DocumentManagementSystem.Shared;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> Get(string? code)
        {
            code = code.ToLower();
            string fileName = string.Empty;

            switch(code)
            {
                case "ecp":
                    fileName = "ecp.json";
                    break;
                case "ps":
                    fileName = "ps.json";
                    break;
            }

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];

                await fs.ReadAsync(buffer, 0, buffer.Length);

                return Encoding.Default.GetString(buffer);
            }
        }
    }
}
