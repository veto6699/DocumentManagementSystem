using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Variables
    {
        public ICollection<string> @Enum { get; set; }
        public string Default { get; set; }
        public string Description { get; set; }
    }
}
