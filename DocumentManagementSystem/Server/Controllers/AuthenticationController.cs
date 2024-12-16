using DocumentManagementSystem.Server.Service;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagementSystem.Server.Controllers
{
    /// <summary>
    /// Контроллер для авторизации
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userService"></param>
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthenticationController(ILogger<AuthenticationController> logger, UserService userService) : Controller
    {
        private readonly ILogger<AuthenticationController> _logger = logger;
        private readonly UserService _userService = userService;

        [HttpPost]
        public async Task<LoginResponse?> Login(LoginRequest args)
        {
            LoginResponse result;

            try
            {
                result = await _userService.Login(args);
            }
            catch(ArgumentNullException)
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 403;
                return null;
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }

            return result;
        }

        [HttpPost]
        public async Task<RefreshAccessTokenResponse?> RefreshAccessToken(RefreshAccessTokenRequest args)
        {
            RefreshAccessTokenResponse result;

            try
            {
                result = await _userService.RefreshAccessToken(args);
            }
            catch (ArgumentNullException)
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }
            catch (ArgumentException)
            {
                HttpContext.Response.StatusCode = 403;
                return null;
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }

            return result;
        }
    }
}
