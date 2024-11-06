using DocumentManagementSystem.Shared.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace DocumentManagementSystem.Shared
{
    public class ShortDescription(ShortDescriptionRequest args)
    {
        [JsonIgnore]
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        [Required]
        public string Code { get; set; } = args.Code;
        [Required]
        public string Name { get; set; } = args.Name;
        public string? Description { get; set; } = args.Description;
    }
}
