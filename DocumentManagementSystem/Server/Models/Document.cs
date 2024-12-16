using DocumentManagementSystem.Shared.OpenApi;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManagementSystem.Server.Models
{
    public class Document(DocumentRequest args)
    {
        /// <summary>
        /// Ид
        /// </summary>
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = args.Code;
        /// <summary>
        /// Описание в формате OpenAPI
        /// </summary>
        public OpenAPIRoot OpenAPI { get; set; } = args.Document;

        public DocumentResponse GetDTOResponse()
        {
            return new DocumentResponse(Code, OpenAPI);
        }
    }
}
