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
        public Dictionary<string, Schema>? Schemas { get; set; }
        public Dictionary<string, Response>? Responses { get; set; }
        public Dictionary<string, Parameter>? Parameters { get; set; }
        public Dictionary<string, Example>? Examples { get; set; }
        public Dictionary<string, RequestBody>? RequestBodies { get; set; }
        public Dictionary<string, Header>? Headers { get; set; }
        public Dictionary<string, SecuritySchema>? SecuritySchemes { get; set; }
        public Dictionary<string, Link>? Links { get; set; }
        public Dictionary<string, object>? CallBacks { get; set; }
        public Dictionary<string, PathItem>? PathItems { get; set; }
    }
}
