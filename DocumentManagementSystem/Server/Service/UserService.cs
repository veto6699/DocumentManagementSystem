using DocumentManagementSystem.Server.Data;
using DocumentManagementSystem.Server.Models;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DocumentManagementSystem.Server.Service
{
    public class UserService
    {
        private readonly UserDbContext _userdb;
        private readonly RefreshTokenDbContext _refreshTokendb;
        readonly AuthTokenSettings _tokenSettings;

        public UserService(UserDbContext userDB, RefreshTokenDbContext refreshTokenDB, IOptions<AuthTokenSettings> tokenSettings)
        {
            _userdb = userDB;
            _refreshTokendb = refreshTokenDB;
            _tokenSettings = tokenSettings.Value;
        }

        public async Task<User?> GetUser(Guid id)
        {
            var result = await _userdb.Get(id);

            if (result is not null)
                return result;

            return null;
        }

        public async Task Registration(RegistrationRequest args)
        {
            if (string.IsNullOrWhiteSpace(args.Email) || string.IsNullOrWhiteSpace(args.Password) || string.IsNullOrWhiteSpace(args.Name) || string.IsNullOrWhiteSpace(args.Surname))
            {
                throw new ArgumentNullException();
            }

            args.Email = args.Email.Trim().ToLower();

            if (await CheckEmail(args.Email))
            {
                throw new ArgumentException();
            }

            args.Password = HashPassword(args.Password);
            User user = new(args);

            await _userdb.Add(user);
        }

        public async Task<LoginResponse?> Login(LoginRequest args)
        {
            if (string.IsNullOrWhiteSpace(args.Email) || string.IsNullOrWhiteSpace(args.Password))
            {
                throw new ArgumentNullException();
            }

            args.Email = args.Email.Trim().ToLower();
            args.Password = args.Password.Trim();

            var user = await SearchByEmail(args.Email);

            if (user is not null && user.Email == args.Email && PasswordVerification(args.Password, user.Password))
                return new LoginResponse(GenerateJwtToken(user), await GenerateRefreshToken(user.Id));
            else
                throw new ArgumentException();
        }

        public async Task<RefreshAccessTokenResponse?> RefreshAccessToken(RefreshAccessTokenRequest args)
        {
            if(string.IsNullOrWhiteSpace(args.RefreshToken))
                throw new ArgumentNullException();

            var refreshToken = await _refreshTokendb.Get(args.RefreshToken);

            if(refreshToken is null || refreshToken.IsUsed)
                throw new ArgumentException();

            if(refreshToken.ExpirationDate < DateTime.Now)
                throw new ArgumentException();

            await _refreshTokendb.MakeUsedToken(args.RefreshToken);

            var user = await GetUser(refreshToken.UserId);

            return new RefreshAccessTokenResponse(GenerateJwtToken(user), await GenerateRefreshToken(user.Id));
        }

        public async Task<bool> CheckEmail(string email)
        {
            var result = await _userdb.SearchByEmail(email);

            if (result is not null)
                return true;
            
            return false;
        }

        public async Task<User?> SearchByEmail(string email)
        {
            var result = await _userdb.SearchByEmail(email);

            if (result is not null)
                return result;

            return null;
        }

        private string HashPassword(string plainPassword)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var rfcPassord = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassord.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);

            return Convert.ToBase64String(passwordHash);
        }

        private bool PasswordVerification(string plainPassword, string dbPassword)
        {
            byte[] dbPasswordHash = Convert.FromBase64String(dbPassword);

            byte[] salt = new byte[16];
            Array.Copy(dbPasswordHash, 0, salt, 0, 16);

            var rfcPassord = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassord.GetBytes(20);

            for (int i = 0; i < rfcPasswordHash.Length; i++)
            {
                if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));

            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var cliams = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials,
                claims: cliams);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        private async Task<string> GenerateRefreshToken(Guid userId)
        {
            byte[] tokenByte = Guid.NewGuid().ToByteArray();

            var token = Convert.ToBase64String(tokenByte);

            var refreshToken = new RefreshToken(userId, token);

            await _refreshTokendb.Add(refreshToken);

            return token;
        }
    }
}
