using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class PathItem
    {
        [BsonIgnoreIfNull]
        public string? @Ref { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Summary { get; set; }
        /// <summary>
        /// Подробное описание
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Description { get; set; }
        /// <summary>
        /// Описание Get запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Get { get; set; }
        /// <summary>
        /// Описание Put(Update) запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Put { get; set; }
        /// <summary>
        /// Описание Post запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Post { get; set; }
        /// <summary>
        /// Описание Delete запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Delete { get; set; }
        /// <summary>
        /// Описание Options запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Options { get; set; }
        /// <summary>
        /// Описание Head запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Head { get; set; }
        /// <summary>
        /// Описание Patch запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Patch { get; set; }
        /// <summary>
        /// Описание Trace запроса
        /// </summary>
        [BsonIgnoreIfNull]
        public Operation? Trace { get; set; }
        [BsonIgnoreIfNull]
        public List<Server>? Servers { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        [BsonIgnoreIfNull]
        public List<Parameter>? Parameters { get; set; }
    }
}
