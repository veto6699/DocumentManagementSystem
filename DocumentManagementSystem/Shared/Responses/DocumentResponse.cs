using DocumentManagementSystem.Shared.OpenApi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Responses
{
    public class DocumentResponse
    {
        public DocumentResponse() { }
    
        public DocumentResponse(Document args)
        {
            Code = args.Code;
            Document = args.OpenAPI;
        }
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Описание в формате OpenAPI
        /// </summary>
        public OpenAPIRoot Document { get; set; }
    }
}
