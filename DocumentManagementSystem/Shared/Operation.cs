using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class Operation
    {
        public ICollection<string> Tags { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public ExternalDocs ExternalDocs { get; set; }
        public string OperationId { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
        public RequestBody RequestBody { get; set; }
        public Response Response { get; set; }
        public Dictionary<string, object> CallBacks { get; set; }
        public bool Deprecated { get; set; }
        public ICollection<Dictionary<string, ICollection<string>>> Security { get; set; }
        public ICollection<Server> Servers { get; set; }
    }
}
