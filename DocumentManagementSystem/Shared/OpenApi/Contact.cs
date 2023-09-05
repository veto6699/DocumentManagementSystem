using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Contact
    {
        /// <summary>
        /// Ссылка на контакт
        /// </summary>
        public Uri URL { get; set; }
        /// <summary>
        /// Название контакта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Email контакта
        /// </summary>
        public string Email { get; set; }
    }
}
