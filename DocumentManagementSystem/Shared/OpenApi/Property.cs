using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Property
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
        /// Описание параметра
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Description { get; set; }
        /// <summary>
        /// Параметры элемента массива
        /// </summary>
        [BsonIgnoreIfNull]
        public Item? Items { get; set; }
        /// <summary>
        /// Дефолтное значение
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Default { get; set; }
        /// <summary>
        /// Формат числа 
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Format { get; set; }
        /// <summary>
        /// Допустимо ли null значение
        /// </summary>
        [BsonIgnoreIfNull]
        public bool? Nullable { get; set; }
        /// <summary>
        /// Дополнительные свойства, используется для массивов
        /// </summary>
        [BsonIgnoreIfNull]
        public AdditionalProperty? AdditionalProperties { get; set; }
        /// <summary>
        /// Список возможных значений
        /// </summary>
        [BsonIgnoreIfNull]
        public List<string>? @Enum { get; set; }
    }
}
