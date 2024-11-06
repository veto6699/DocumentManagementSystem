using DocumentManagementSystem.Shared.OpenApi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class DocumentRequest
    {
        public DocumentRequest(string code, OpenAPIRoot document)
        {
            Code = code;
            Document = document;
        }
        /// <summary>
        /// Код
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Описание в формате OpenAPI
        /// </summary>
        [Required]
        public OpenAPIRoot Document { get; set; }
    }
}
