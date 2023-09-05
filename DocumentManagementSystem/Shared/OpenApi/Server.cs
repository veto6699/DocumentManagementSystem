using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Server
    {
        /// <summary>
        /// Адрес сервера
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Описание сервера (может содержать Marcdown)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// какие то переменные, не разобрался
        /// </summary>
        public Dictionary<string, Variables> Variables { get; set; }
    }
}
