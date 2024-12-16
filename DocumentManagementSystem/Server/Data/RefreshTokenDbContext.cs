using DocumentManagementSystem.Server.Constants;
using DocumentManagementSystem.Server.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DocumentManagementSystem.Server.Data
{
    public class RefreshTokenDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<RefreshToken> _collection;

        public RefreshTokenDbContext(MongoClient client)
        {
            _client = client;

            if (!BsonClassMap.IsClassMapRegistered(typeof(RefreshToken)))
                BsonClassMap.RegisterClassMap<RefreshToken>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<RefreshToken>(SystemConstants.RefreshTokens);

            var token = new CreateIndexModel<RefreshToken>(Builders<RefreshToken>.IndexKeys.Hashed(r => r.Token), new CreateIndexOptions() { Sparse = true, Name = "Token" });

            _collection.Indexes.CreateMany([token]);
        }

        public async Task Add(RefreshToken token)
        {
            await _collection.InsertOneAsync(token);
        }

        public async Task<RefreshToken?> Get(string token)
        {
            var result = await _collection.FindAsync(Builders<RefreshToken>.Filter.Where(doc => doc.Token == token));
            var dbToken = result.FirstOrDefault();

            if (dbToken is not null && !string.IsNullOrEmpty(dbToken.Token) && token == dbToken.Token)
            {
                return dbToken;
            }

            return null;
        }

        public async Task MakeUsedToken(string token)
        {
            await _collection.UpdateOneAsync(Builders<RefreshToken>.Filter.Where(doc => doc.Token == token), Builders<RefreshToken>.Update.Set<bool>(doc => doc.IsUsed, true));
        }
    }
}
