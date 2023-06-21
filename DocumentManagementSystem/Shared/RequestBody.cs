using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class RequestBody
    {
        public string Description { get; set; }
        public MediaType Content { get; set; }
        public bool Required { get; set; }
    }
}
