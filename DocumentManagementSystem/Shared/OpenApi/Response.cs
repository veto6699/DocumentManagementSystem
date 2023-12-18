using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Response
    {
        public string? Description { get; set; }
        public Dictionary<string, Header>? Headers { get; set; }
        public Dictionary<string, MediaType>? Content { get; set; }
        public Dictionary<string, Link>? Links { get; set; }
    }
}
