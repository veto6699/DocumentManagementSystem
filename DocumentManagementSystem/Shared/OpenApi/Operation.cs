using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Operation
    {
        /// <summary>
        /// Тег(контроллер) к которому относится действие
        /// </summary>
        public IList<string> Tags { get; set; }
        /// <summary>
        /// Краткое описаине действия
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Полное описание действия
        /// </summary>
        public string Description { get; set; }
        public ExternalDoc ExternalDocs { get; set; }
        public string OperationId { get; set; }
        public IList<Parameter> Parameters { get; set; }
        /// <summary>
        /// Описание запроса
        /// </summary>
        public RequestBody RequestBody { get; set; }
        /// <summary>
        /// Описание ответа
        /// </summary>
        public Response Response { get; set; }
        public Dictionary<string, object> CallBacks { get; set; }
        public bool Deprecated { get; set; }
        public IList<Dictionary<string, IList<string>>> Security { get; set; }
        public IList<Server> Servers { get; set; }
    }
}
