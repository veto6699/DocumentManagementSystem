using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class XML
    {
        public string? Name { get; set; }
        public string? Namespace { get; set; }
        public string? Prefix { get; set; }
        public bool? Attribute { get; set; }
        public bool? Wrapped { get; set; }
    }
}
