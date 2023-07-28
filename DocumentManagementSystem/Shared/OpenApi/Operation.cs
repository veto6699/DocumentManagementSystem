using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Operation
    {
        public IList<string> Tags { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public ExternalDocs ExternalDocs { get; set; }
        public string OperationId { get; set; }
        public IList<Parameter> Parameters { get; set; }
        public RequestBody RequestBody { get; set; }
        public Response Response { get; set; }
        public Dictionary<string, object> CallBacks { get; set; }
        public bool Deprecated { get; set; }
        public IList<Dictionary<string, IList<string>>> Security { get; set; }
        public IList<Server> Servers { get; set; }
    }
}
