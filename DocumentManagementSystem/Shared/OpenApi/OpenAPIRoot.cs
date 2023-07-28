using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class OpenAPIRoot
    {
        public string OpenAPI { get; set; }
        public Info Info { get; set; }
        public string JsonSchemaDialect { get; set; }
        public IList<Server> Servers { get; set; }
        public Dictionary<string, PathItem> Paths { get; set; }
        public Components Components { get; set; }
        public Dictionary<string, PathItem> WebHooks { get; set; }
        public IList<Dictionary<string, IList<string>>> Security { get; set; }
        public IList<string> Tags { get; set; }
        public object ExternalDocs { get; set; }
    }
}
