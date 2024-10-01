using MongoDB.Bson.Serialization.Attributes;
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
        [BsonIgnoreIfNull]
        public bool? Nullable { get; set; }
        /// <summary>
        /// Тип параметра (например: object, string, integer, array, boolean, number)
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Type { get; set; }
        /// <summary>
        /// Параметры элемента массива
        /// </summary>
        [BsonIgnoreIfNull]
        public Item? Items { get; set; }
        /// <summary>
        /// Формат (например: int32, int64)
        /// </summary>
        [BsonIgnoreIfNull]
        public string? Format { get; set; }
    }
}
