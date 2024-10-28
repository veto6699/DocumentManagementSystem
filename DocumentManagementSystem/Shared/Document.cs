using DocumentManagementSystem.Shared.OpenApi;
using DocumentManagementSystem.Shared.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    [BsonIgnoreExtraElements]
    public class Document(DocumentRequest args)
    {
        /// <summary>
        /// Ид
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = args.Code;
        /// <summary>
        /// Описание в формате OpenAPI
        /// </summary>
        public OpenAPIRoot OpenAPI { get; set; } = args.Document;
    }
}
