using DocumentManagementSystem.Shared.Responses;
using DocumentManagementSystem.Shared.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManagementSystem.Server.Models
{
    public class Summary(SummaryRequest args)
    {
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = args.Code;
        public string Name { get; set; } = args.Name;
        public string? Description { get; set; } = args.Description;

        public SummaryResponse GetDTOResponse()
        {
            var content = new SummaryResponse()
            {
                Code = Code,
                Name = Name,
            };

            if(Description is not null)
                content.Description = Description;

            return content;
        }
    }
}
