using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Responses
{
    public class ShortDescriptionResponse
    {
        public ShortDescriptionResponse() { }

        public ShortDescriptionResponse(ShortDescription args)
        {
            Code = args.Code;
            Name = args.Name;
            Description = args.Description;
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
