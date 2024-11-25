using MongoDB.Driver;
using DocumentManagementSystem.Server.Models;
using MongoDB.Bson.Serialization;
using DocumentManagementSystem.Server.Constants;
using MongoDB.Bson;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace DocumentManagementSystem.Server.Data
{
    public class UserDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<User> _collection;
        readonly AuthTokenSettings _tokenSettings;

        public UserDbContext(MongoClient client, IOptions<AuthTokenSettings> tokenSettings)
        {
            _client = client;
            _tokenSettings = tokenSettings.Value;

            if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
                BsonClassMap.RegisterClassMap<User>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<User>(SystemConstants.Users);

            var id = new CreateIndexModel<User>(Builders<User>.IndexKeys.Hashed(r => r.Id), new CreateIndexOptions() { Sparse = true, Name = "Id" });
            var email = new CreateIndexModel<User>(Builders<User>.IndexKeys.Hashed(r => r.Email), new CreateIndexOptions() { Sparse = true, Name = "Email" });

            _collection.Indexes.CreateMany([id, email]);
        }

        public async Task<User?> Get(ObjectId id)
        {
            var result = await _collection.FindAsync(Builders<User>.Filter.Where(doc => doc.Id == id));
            var user = result.FirstOrDefault();

            if (user is not null && user.Email is not null)
            {
                return user;
            }

            return null;
        }

        public async Task<bool> CheckEmail(string email)
        {
            var result = await _collection.FindAsync(Builders<User>.Filter.Where(doc => doc.Email == email));
            var user = result.FirstOrDefault();

            if (user is not null && user.Email is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<User?> SearchByEmail(string email)
        {
            var result = await _collection.FindAsync(Builders<User>.Filter.Where(doc => doc.Email == email));
            var user = result.FirstOrDefault();

            if (user is not null && user.Email is not null)
            {
                return user;
            }

            return null;
        }

        public async Task Add(User user)
        {
            await _collection.InsertOneAsync(user);
        }

        public string GenerateJwtToken(User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));

            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var cliams = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.Name),
                new Claim("LastName", user.Surname),
                new Claim("Email", user.Email)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials,
                claims: cliams);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
