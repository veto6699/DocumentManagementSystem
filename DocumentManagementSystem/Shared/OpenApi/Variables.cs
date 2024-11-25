using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Variables
    {
        /// <summary>
        /// какие то перечисление
        /// </summary>
        public List<string>? @Enum { get; set; }
        /// <summary>
        /// какие то дефолтные значения
        /// </summary>
        public string? Default { get; set; }
        /// <summary>
        /// Описание переменной (может содержать Marcdown)
        /// </summary>
        public string? Description { get; set; }
    }
}
