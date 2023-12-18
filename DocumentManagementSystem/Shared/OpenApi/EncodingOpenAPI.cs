using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class EncodingOpenAPI
    {
        public string? ContentType { get; set; }
        public Dictionary<string, Header>? Headers { get; }
        public string? Style { get; set; }
        public bool? Explode { get; set; }
        public bool? AllowReserved { get; set; }

    }
}
