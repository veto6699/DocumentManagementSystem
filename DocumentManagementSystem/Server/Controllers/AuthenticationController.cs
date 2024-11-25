using DocumentManagementSystem.Server.Data;
using DocumentManagementSystem.Server.Models;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagementSystem.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<UserDbContext> _logger;
        private readonly UserDbContext _db;

        public AuthenticationController(ILogger<UserDbContext> logger, UserDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<LogInResponse?> LogIn(LogInRequest args)
        {
            if (string.IsNullOrWhiteSpace(args.Email) || string.IsNullOrWhiteSpace(args.Password))
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }

            args.Email = args.Email.Trim().ToLower();
            args.Password = args.Password.Trim();

            User user;

            try
            {
                user = await _db.SearchByEmail(args.Email);
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
                return null;
            }

            if (user is not null && user.Email == args.Email && user.Password == args.Password)
            {
                return new LogInResponse() { AccessToken = _db.GenerateJwtToken(user) };
            }

            HttpContext.Response.StatusCode = 400;
            return null;
        }
    }
}
