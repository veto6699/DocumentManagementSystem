using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class ShortDescriptionRequest
    {
        public ShortDescriptionRequest(string name, string code, string description)
        {
            Code = code;
            Description = description;
            Name = name;
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
