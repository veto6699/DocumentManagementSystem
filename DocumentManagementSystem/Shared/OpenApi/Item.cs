using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Item
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        public string? @Ref { get; set; }
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
