using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Flow
    {
        public Uri? AuthorizationUrl { get; set; }
        public Uri? TokenUrl { get; set; }
        public Uri? RefreshUrl { get; set; }
        public Dictionary<string, string>? Scopes { get; set; }
    }
}
