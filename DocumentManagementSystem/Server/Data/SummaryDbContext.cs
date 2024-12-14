using DocumentManagementSystem.Server.Constants;
using DocumentManagementSystem.Server.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DocumentManagementSystem.Server.Data
{
    public class SummaryDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<Summary> _collection;

        public SummaryDbContext(MongoClient client) 
        {
            _client = client;

            if (!BsonClassMap.IsClassMapRegistered(typeof(Summary)))
                BsonClassMap.RegisterClassMap<Summary>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<Summary>(SystemConstants.ShortDescriptions);

            var code = new CreateIndexModel<Summary>(Builders<Summary>.IndexKeys.Hashed(r => r.Code), new CreateIndexOptions() { Sparse = true, Name = "Code" });

            _collection.Indexes.CreateMany([code]);
        }

        public async Task<Summary> Get(string code)
        {
            var result = await _collection.FindAsync(Builders<Summary>.Filter.Where(doc => doc.Code == code));
            return result.FirstOrDefault();
        }

        public async Task<List<Summary>> GetAll()
        {
            var result = await _collection.FindAsync(new BsonDocument());
            return result.ToList();
        }

        public async Task Add(Summary description)
        {
            if (await Get(description.Code) == default)
                await _collection.InsertOneAsync(description);
            else
                throw new ArgumentException();
        }
    }
}
