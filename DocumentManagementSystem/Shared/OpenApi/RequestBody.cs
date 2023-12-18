using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class RequestBody
    {
        public string? Description { get; set; }
        /// <summary>
        /// Описание запросов для разных медиа типов
        /// </summary>
        public Dictionary<string, MediaType>? Content { get; set; }
        public bool? Required { get; set; }
    }
}
