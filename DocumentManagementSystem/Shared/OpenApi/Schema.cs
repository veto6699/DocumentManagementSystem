using DocumentManagementSystem.Shared.JsonConverters;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    [JsonConverter(typeof(SchemaJsonConverter))]
    public class Schema
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        [BsonIgnoreIfNull]
        public string? @Ref { get; set; }
        /// <summary>
        /// Тип элемента
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Type { get; set; }
        /// <summary>
        /// Массив элемента
        /// </summary>
        public Item? Items { get; set; }
        /// <summary>
        /// Обязательные параметры
        /// </summary>
        [BsonIgnoreIfNull]
        public List<string>? Required { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        [BsonIgnoreIfNull]
        public Dictionary<string, Property>? Properties { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, string>? Discriminator { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Description { get; set; }
        /// <summary>
        /// Расширенные параметры
        /// </summary>
        [BsonIgnoreIfNull]
        public AdditionalProperty? AdditionalProperties { get; set; }
        /// <summary>
        /// Расширенные парааметры, только для xml
        /// </summary>
        [JsonPropertyName("xml")]
        [BsonIgnoreIfNull]
        public XML? XML { get; set; }
    }
}
