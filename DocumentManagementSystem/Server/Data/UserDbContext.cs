using MongoDB.Driver;
using DocumentManagementSystem.Server.Models;
using MongoDB.Bson.Serialization;
using DocumentManagementSystem.Server.Constants;

namespace DocumentManagementSystem.Server.Data
{
    public class UserDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<User> _collection;

        public UserDbContext(MongoClient client)
        {
            _client = client;

            if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
                BsonClassMap.RegisterClassMap<User>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<User>(SystemConstants.Users);

            var email = new CreateIndexModel<User>(Builders<User>.IndexKeys.Hashed(r => r.Email), new CreateIndexOptions() { Sparse = true, Name = "Email" });

            _collection.Indexes.CreateMany([email]);
        }

        public async Task<User?> Get(Guid id)
        {
            var result = await _collection.FindAsync(Builders<User>.Filter.Where(doc => doc.Id == id));
            var user = result.FirstOrDefault();

            if (user is not null && user.Email is not null)
            {
                return user;
            }

            return null;
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
    }
}
