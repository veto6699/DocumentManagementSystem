using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class Schema
    {
        public string Type { get; set; }
        public ICollection<string> Required { get; set; }
        public Dictionary<string, Property> Properties { get; set; }
        public Dictionary<string, string> Discriminator { get; set; }
        public string Description { get; set; }

    }
}
