using DocumentManagementSystem.Server.Service;
using DocumentManagementSystem.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagementSystem.Server.Controllers
{
    /// <summary>
    /// Контроллер для регистрации
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController(ILogger<RegistrationController> logger, UserService userService) : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger = logger;
        private readonly UserService _userService = userService;

        [HttpPost]
        public async Task Registration(RegistrationRequest args)
        {
            try
            {
                await _userService.Registration(args);
            }
            catch (ArgumentNullException)
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 409;
                return;
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return;
            }

            HttpContext.Response.StatusCode = 204;
            return;
        }
    }
}
