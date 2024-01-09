using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class AdditionalProperty
    {
        /// <summary>
        /// Допустимо ли null значение
        /// </summary>
        public bool? Nullable { get; set; }
        /// <summary>
        /// Тип параметра (на пример object, string, integer, array, boolean, number)
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// Параметры элемента массива
        /// </summary>
        public Item? Items { get; set; }
    }
}
