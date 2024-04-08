using DocumentManagementSystem.Server.Constants;
using DocumentManagementSystem.Shared;
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

            _collection = _client.GetDatabase(SystemConstants.DatabaseName).GetCollection<Document>(SystemConstants.DocumentsCollectionName);

            var id = new CreateIndexModel<Document>(Builders<Document>.IndexKeys.Hashed(r => r.Id), new CreateIndexOptions() { Sparse = true, Name = "Id" });
            var code = new CreateIndexModel<Document>(Builders<Document>.IndexKeys.Hashed(r => r.Code), new CreateIndexOptions() { Sparse = true, Name = "Code" });

            _collection.Indexes.CreateMany([id, code]);
        }

        public Document? Get(string code)
        {
            var document = _collection.Find(Builders<Document>.Filter.Where(doc => doc.Code == code)).FirstOrDefault();

            if (document is not null && document.OpenAPI is not null)
            {
                return document;
            }

            return null;
        }

        public Task Add(Document document)
        {
            document.Id = new();
            _collection.InsertOne(document);

            return Task.CompletedTask;
        }
    }
}
