using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Parameter
    {
        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Размещение
        /// </summary>
        public string? In { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Флаг необходимо
        /// </summary>
        public bool? Required { get; set; }
        /// <summary>
        /// Флаг устарело
        /// </summary>
        public bool? Deprecated { get; set; }
        /// <summary>
        /// Флаг разрешено не заполнять
        /// </summary>
        public bool? AllowEmptyValue { get; set; }
        /// <summary>
        /// Схема
        /// </summary>
        public Property? Schema { get; set; }
    }
}
