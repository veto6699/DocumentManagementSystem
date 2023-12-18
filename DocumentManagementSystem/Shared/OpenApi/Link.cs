using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Link
    {
        public string? OperationRef { get; set; }
        public string? OperationId { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }
        public object? RequestBody { get; set; }
        public string? Description { get; set; }
        public Server? Server { get; set; }
    }
}
