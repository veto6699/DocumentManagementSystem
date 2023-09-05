using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class License
    {
        /// <summary>
        /// Название лицензии
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// какой то идентификатор лицензии
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Ссылка на лицензию
        /// </summary>
        public Uri URL { get; set; }
    }
}
