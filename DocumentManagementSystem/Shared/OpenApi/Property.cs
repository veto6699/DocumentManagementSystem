﻿using DocumentManagementSystem.Shared.JsonConverters;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    [JsonConverter(typeof(PropertyJsonConverter))]
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
        /// Значение по умолчанию
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
        /// <summary>
        /// Расширенные парааметры, только для xml
        /// </summary>
        [JsonPropertyName("xml")]
        [BsonIgnoreIfNull]
        public XML? XML { get; set; }
        /// <summary>
        /// Только для чтения
        /// </summary>
        [BsonIgnoreIfNull]
        public bool? ReadOnly { get; set; }
        /// <summary>
        /// Максимальный размер
        /// </summary>
        [BsonIgnoreIfNull]
        public int? MaxLength { get; set; }
        /// <summary>
        /// Минимальный размер
        /// </summary>
        [BsonIgnoreIfNull]
        public int? MinLength { get; set; }
    }
}
