using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Flows
    {
        public Flow? @Implicit { get; set; }
        public Flow? Password { get; set; }
        public Flow? ClientCredentials { get; set; }
        public Flow? AuthorizationCode { get; set; }

    }
}
