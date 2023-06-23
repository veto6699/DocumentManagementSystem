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
        private readonly ILogger<WeatherForecastController> _logger;

        public DocumentController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<string> Get(string? Code)
        {
            if (Code == "ECP")
            {
                using (var fs = new FileStream("ecp.json", FileMode.Open)) 
                {
                    byte[] buffer = new byte[fs.Length];

                    await fs.ReadAsync(buffer, 0, buffer.Length);

                    return Encoding.Default.GetString(buffer);
                }
            }

            if (Code == "FT")
            {
                using (var fs = new FileStream("ft.json", FileMode.Open))
                {
                    byte[] buffer = new byte[fs.Length];

                    await fs.ReadAsync(buffer, 0, buffer.Length);

                    return Encoding.Default.GetString(buffer);
                }
            }

            return string.Empty;
        }
    }
}
