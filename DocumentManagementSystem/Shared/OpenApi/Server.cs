using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Server
    {
        public string URL { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Variables> Variables { get; set; }
    }
}
