using DocumentManagementSystem.Shared.OpenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Responses
{
    public class DocumentResponse(string code, OpenAPIRoot document)
    {
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = code;
        /// <summary>
        /// Описание в формате OpenAPI
        /// </summary>
        public OpenAPIRoot Document { get; set; } = document;
    }
}
