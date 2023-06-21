using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class Server
    {
        public Uri URL { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Variables> Variables { get; set; }
    }
}
