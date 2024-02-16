using DocumentManagementSystem.Shared.OpenApi;
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
    public class Document
    {
        [JsonIgnore]
        [BsonId]
        public ObjectId Id { get; set; }
        [Required]
        public string Code {  get; set; }
        [Required]
        public OpenAPIRoot OpenAPI {  get; set; }
    }
}
