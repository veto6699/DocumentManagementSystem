using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class SummaryRequest
    {
        public SummaryRequest(string name, string code, string? description)
        {
            Code = code;
            Name = name;

            if (!string.IsNullOrWhiteSpace(description))
                Description = description;
        }
        /// <summary>
        /// Код
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string? Description { get; set; }
    }
}
