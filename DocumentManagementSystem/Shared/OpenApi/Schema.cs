﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Schema
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        [BsonIgnoreIfNull]
        public string? @Ref { get; set; }
        [BsonIgnoreIfNull]
        public string? Type { get; set; }
        /// <summary>
        /// Обязательные параметры
        /// </summary>
        [BsonIgnoreIfNull]
        public ICollection<string>? Required { get; set; }
        /// <summary>
        /// Параметры компонента
        /// </summary>
        [BsonIgnoreIfNull]
        public Dictionary<string, Property>? Properties { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, string>? Discriminator { get; set; }
        [BsonIgnoreIfNull]
        public string? Description { get; set; }

    }
}
