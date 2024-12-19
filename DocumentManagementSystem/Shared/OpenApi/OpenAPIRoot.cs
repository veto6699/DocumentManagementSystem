using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class OpenAPIRoot
    {
        /// <summary>
        /// Версия формата
        /// </summary>
        [JsonPropertyName("openapi")]
        public string? OpenAPI { get; set; }
        /// <summary>
        /// Мета данные файла
        /// </summary>
        [BsonIgnoreIfNull]
        public Info? Info { get; set; }
        /// <summary>
        /// Так и не понял для чего это
        /// </summary>
        [BsonIgnoreIfNull]
        public string? JsonSchemaDialect { get; set; }
        /// <summary>
        /// Список серверов для запросов
        /// </summary>
        [BsonIgnoreIfNull]
        public List<Server>? Servers { get; set; }
        /// <summary>
        /// Описание операций (ключ - путь, значение - модель)
        /// </summary>
        public Dictionary<string, PathItem>? Paths { get; set; }
        /// <summary>
        /// Описание структур запросов
        /// </summary>
        [BsonIgnoreIfNull]
        public Components? Components { get; set; }
        /// <summary>
        /// не понял как с этим работать
        /// </summary>
        [BsonIgnoreIfNull]
        public Dictionary<string, PathItem>? WebHooks { get; set; }
        /// <summary>
        /// что то связаннное с авторизацией, не разобрался
        /// </summary>
        [BsonIgnoreIfNull]
        public List<Dictionary<string, List<string>>>? Security { get; set; }
        /// <summary>
        /// Теги по которым группируются операции
        /// </summary>
        [BsonIgnoreIfNull]
        public List<Tag>? Tags { get; set; }
        /// <summary>
        /// какая то внешняя документация, не разобрался
        /// </summary>
        [BsonIgnoreIfNull]
        public ExternalDoc? ExternalDocs { get; set; }
    }
}
