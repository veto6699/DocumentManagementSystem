using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class PathItem
    {
        public string @Ref { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public Operation Get { get; set; }
        public Operation Put { get; set; }
        public Operation Post { get; set; }
        public Operation Delete { get; set; }
        public Operation Options { get; set; }
        public Operation Head { get; set; }
        public Operation Patch { get; set; }
        public Operation Trace { get; set; }
        public ICollection<Server> Servers { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
    }
}
