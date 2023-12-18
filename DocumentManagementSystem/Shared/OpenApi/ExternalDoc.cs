using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class ExternalDoc
    {
        /// <summary>
        /// Описание внешней документации (может содержать Marcdown)
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Ссылка на документацию
        /// </summary>
        public Uri? URL { get; set; }
    }
}
