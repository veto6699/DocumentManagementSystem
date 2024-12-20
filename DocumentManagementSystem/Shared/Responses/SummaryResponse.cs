using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Responses
{
    public class SummaryResponse
    {
        public SummaryResponse(string code, string name, string? description = null)
        {
            Code = code;
            Name = name;

            if(description is not null)
                Description = description;
        }
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string? Description { get; set; }
    }
}
