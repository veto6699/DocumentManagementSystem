using DocumentManagementSystem.Server.Constants;
using DocumentManagementSystem.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DocumentManagementSystem.Server.Data
{
    public class ShortDescriptionDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<ShortDescription> _collection;

        public ShortDescriptionDbContext(MongoClient client) 
        {
            _client = client;

            if (!BsonClassMap.IsClassMapRegistered(typeof(ShortDescription)))
                BsonClassMap.RegisterClassMap<ShortDescription>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<ShortDescription>(SystemConstants.ShortDescriptions);

            var id = new CreateIndexModel<ShortDescription>(Builders<ShortDescription>.IndexKeys.Hashed(r => r.Id), new CreateIndexOptions() { Sparse = true, Name = "Id" });
            var code = new CreateIndexModel<ShortDescription>(Builders<ShortDescription>.IndexKeys.Hashed(r => r.Code), new CreateIndexOptions() { Sparse = true, Name = "Code" });

            _collection.Indexes.CreateMany([id, code]);
        }

        public async Task<ShortDescription> Get(string code)
        {
            var result = await _collection.FindAsync(Builders<ShortDescription>.Filter.Where(doc => doc.Code == code));
            return result.FirstOrDefault();
        }

        public async Task<List<ShortDescription>> GetAll()
        {
            var result = await _collection.FindAsync(new BsonDocument());
            return result.ToList();
        }

        public async Task Add(ShortDescription description)
        {
            await _collection.InsertOneAsync(description);
        }
    }
}
