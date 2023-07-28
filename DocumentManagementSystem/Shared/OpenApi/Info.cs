using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Info
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Version { get; set; }
        public Uri TermsOfService { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public ICollection<License> License { get; set; }
    }
}
