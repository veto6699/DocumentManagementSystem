using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Tag
    {
        /// <summary>
        /// Название тега
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Описание тега (может содержать Marcdown)
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Ссылка на внешнюю документацию для этого тега
        /// </summary>
        public ExternalDoc? ExternalDocs { get; set; }
    }
}
