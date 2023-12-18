using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Schema
    {
        /// <summary>
        /// Ссылка на компонент
        /// </summary>
        [JsonPropertyName("$ref")]
        public string? @Ref { get; set; }
        public string? Type { get; set; }
        public ICollection<string>? Required { get; set; }
        /// <summary>
        /// Параметры компонента
        /// </summary>
        public Dictionary<string, Property>? Properties { get; set; }
        public Dictionary<string, string>? Discriminator { get; set; }
        public string? Description { get; set; }

    }
}
