using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Components
    {
        [BsonIgnoreIfNull]
        public Dictionary<string, Schema>? Schemas { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, Response>? Responses { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, Parameter>? Parameters { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, Example>? Examples { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, RequestBody>? RequestBodies { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, Header>? Headers { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, SecuritySchema>? SecuritySchemes { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, Link>? Links { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, object>? CallBacks { get; set; }
        [BsonIgnoreIfNull]
        public Dictionary<string, PathItem>? PathItems { get; set; }
    }
}
