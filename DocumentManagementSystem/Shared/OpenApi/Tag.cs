using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalDocs ExternalDocs { get; set; }
    }
}
