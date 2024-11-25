using DocumentManagementSystem.Server.Data;
using DocumentManagementSystem.Server.Models;
using DocumentManagementSystem.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DocumentManagementSystem.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserDbContext> _logger;
        private readonly UserDbContext _db;

        public UserController(ILogger<UserDbContext> logger, UserDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public async Task<User?> Get(string id)
        {
            if (ObjectId.TryParse(id, out ObjectId objectId))
            {
                var user = await _db.Get(objectId);

                if (user is not null && user.Email is not null)
                {
                    return user;
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

        [HttpPost]
        public async Task Add(AddUserRequest args)
        {
            if (string.IsNullOrWhiteSpace(args.Email) || string.IsNullOrWhiteSpace(args.Password) || string.IsNullOrWhiteSpace(args.Name) || string.IsNullOrWhiteSpace(args.Surname))
            {
                HttpContext.Response.StatusCode = 400;
                return;
            }

            args.Email = args.Email.Trim().ToLower();
            args.Password = args.Password.Trim();
            args.Name = args.Name.Trim();
            args.Surname = args.Surname.Trim();

            if(await _db.CheckEmail(args.Email))
            {
                HttpContext.Response.StatusCode = 409;
                return;
            }

            try
            {
                await _db.Add(new User(args));
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
