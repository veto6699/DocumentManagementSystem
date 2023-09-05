using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class Info
    {
        /// <summary>
        /// Заголовок документа
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Полное описание API (может содержать Marcdown)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Краткое описание API
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Версия документа
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Условия использования(URL адрес)
        /// </summary>
        public Uri TermsOfService { get; set; }
        /// <summary>
        /// Контакты для связи
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
        /// Лицензии
        /// </summary>
        public License License { get; set; }
    }
}
