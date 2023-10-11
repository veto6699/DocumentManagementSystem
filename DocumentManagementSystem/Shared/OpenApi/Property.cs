using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Property
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        public string @Ref { get; set; }
        /// <summary>
        /// Тип параметра (на пример object, string, integer, array, boolean, number)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Описание параметра
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Параметры элемента массива
        /// </summary>
        public Items Items { get; set; }
        public string Format { get; set; }
        /// <summary>
        /// Допустимо ли null значение
        /// </summary>
        public bool Nullable { get; set; }
        /// <summary>
        /// Дополнительые свойства, используется для массивов
        /// </summary>
        public AdditionalProperty AdditionalProperties { get; set; }
    }
}
