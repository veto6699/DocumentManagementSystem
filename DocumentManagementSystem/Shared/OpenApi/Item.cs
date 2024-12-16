using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Item
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        [BsonIgnoreIfNull]
        public string? @Ref { get; set; }
        /// <summary>
        /// Тип параметра (на пример object, string, integer, array, boolean, number)
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Type { get; set; }
        /// <summary>
        /// Параметры элемента массива
        /// </summary>
        [BsonIgnoreIfNull]
        public Item? Items { get; set; }
        /// <summary>
        /// Дополнительные свойства, используется для массивов
        /// </summary>
        [BsonIgnoreIfNull]
        public AdditionalProperty? AdditionalProperties { get; set; }
    }
}
