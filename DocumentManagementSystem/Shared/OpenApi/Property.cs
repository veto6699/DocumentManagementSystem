using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Property
    {
        /// <summary>
        /// Тип параметра (на пример string, int, bool и т.д.)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Описание параметра
        /// </summary>
        public string Description { get; set; }
        public string Format { get; set; }
        /// <summary>
        /// Допустимо ли null значение
        /// </summary>
        public bool Nullable { get; set; }
    }
}
