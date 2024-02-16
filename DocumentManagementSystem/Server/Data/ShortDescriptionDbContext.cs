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

            _collection = _client.GetDatabase(SystemConstants.DatabaseName).GetCollection<ShortDescription>(SystemConstants.ShortDescriptionsCollectionName);

            var id = new CreateIndexModel<ShortDescription>(Builders<ShortDescription>.IndexKeys.Hashed(r => r.Id), new CreateIndexOptions() { Sparse = true, Name = "Id" });
            var code = new CreateIndexModel<ShortDescription>(Builders<ShortDescription>.IndexKeys.Hashed(r => r.Code), new CreateIndexOptions() { Sparse = true, Name = "Code" });

            _collection.Indexes.CreateMany([id, code]);
        }

        public ShortDescription Get(string code)
        {
            return _collection.Find(Builders<ShortDescription>.Filter.Where(doc => doc.Code == code)).FirstOrDefault();
        }

        public List<ShortDescription> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public Task Add(ShortDescription description)
        {
            description.Id = new();
            _collection.InsertOne(description);

            return Task.CompletedTask;
        }
    }
}
