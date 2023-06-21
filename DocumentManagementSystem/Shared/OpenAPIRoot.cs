using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class OpenAPIRoot
    {
        public string OpenAPI = "3.1.0";
        public Info Info { get; set; }
        public string JsonSchemaDialect { get; set; }
        public ICollection<Server> Servers { get; set; }
        public Dictionary<string, PathItem> Paths { get; set;}
        public Components Components { get; set; }
        public Dictionary<string, PathItem> WebHooks { get; set; }
        public ICollection<Dictionary<string, ICollection<string>>> Security { get; set; }
        public ICollection<string> Tags { get; set; }
        public object ExternalDocs { get; set; }
    }
}
