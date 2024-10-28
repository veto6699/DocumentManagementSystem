using DocumentManagementSystem.Server.Constants;
using DocumentManagementSystem.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DocumentManagementSystem.Server.Data
{
    public class DocumentDbContext
    {
        readonly MongoClient _client;
        readonly IMongoCollection<Document> _collection;

        public DocumentDbContext(MongoClient client)
        {
            _client = client;

            if(!BsonClassMap.IsClassMapRegistered(typeof(Document)))
                BsonClassMap.RegisterClassMap<Document>(reg =>
                {
                    reg.AutoMap();
                });

            _collection = _client.GetDatabase(SystemConstants.DBName).GetCollection<Document>(SystemConstants.Documents);

            var id = new CreateIndexModel<Document>(Builders<Document>.IndexKeys.Hashed(r => r.Id), new CreateIndexOptions() { Sparse = true, Name = "Id" });
            var code = new CreateIndexModel<Document>(Builders<Document>.IndexKeys.Hashed(r => r.Code), new CreateIndexOptions() { Sparse = true, Name = "Code" });

            _collection.Indexes.CreateMany([id, code]);
        }

        public async Task<Document?> Get(string code)
        {
            var result = await _collection.FindAsync(Builders<Document>.Filter.Where(doc => doc.Code == code));
            var document = result.FirstOrDefault();

            if (document is not null && document.OpenAPI is not null)
            {
                return document;
            }

            return null;
        }

        public async Task Add(Document document)
        {
            await _collection.InsertOneAsync(document);
        }
    }
}
