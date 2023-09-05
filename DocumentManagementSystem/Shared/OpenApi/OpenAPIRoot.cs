using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class OpenAPIRoot
    {
        /// <summary>
        /// Версия формата
        /// </summary>
        public string OpenAPI { get; set; }
        /// <summary>
        /// Мета данные файла
        /// </summary>
        public Info Info { get; set; }
        /// <summary>
        /// Так и не понял для чего это
        /// </summary>
        public string JsonSchemaDialect { get; set; }
        /// <summary>
        /// Список серверов для запросов
        /// </summary>
        public IList<Server> Servers { get; set; }
        /// <summary>
        /// Описание операций (ключ - путь, значение - модель)
        /// </summary>
        public Dictionary<string, PathItem> Paths { get; set; }
        /// <summary>
        /// Описание структур запросов
        /// </summary>
        public Components Components { get; set; }
        /// <summary>
        /// не понял как с этим работать
        /// </summary>
        public Dictionary<string, PathItem> WebHooks { get; set; }
        /// <summary>
        /// что то связаннное с авторизацией, не разобрался
        /// </summary>
        public IList<Dictionary<string, IList<string>>> Security { get; set; }
        /// <summary>
        /// Теги по которым группируются операции
        /// </summary>
        public IList<Tag> Tags { get; set; }
        /// <summary>
        /// какая то внешняя документация, не разобрался
        /// </summary>
        public ExternalDoc ExternalDocs { get; set; }
    }
}
