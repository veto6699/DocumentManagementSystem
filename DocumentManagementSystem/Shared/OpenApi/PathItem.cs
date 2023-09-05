using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.OpenApi
{
    public class PathItem
    {
        public string @Ref { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Описание Get запроса
        /// </summary>
        public Operation Get { get; set; }
        /// <summary>
        /// Описание Put(Update) запроса
        /// </summary>
        public Operation Put { get; set; }
        /// <summary>
        /// Описание Post запроса
        /// </summary>
        public Operation Post { get; set; }
        /// <summary>
        /// Описание Delete запроса
        /// </summary>
        public Operation Delete { get; set; }
        /// <summary>
        /// Описание Options запроса
        /// </summary>
        public Operation Options { get; set; }
        /// <summary>
        /// Описание Head запроса
        /// </summary>
        public Operation Head { get; set; }
        /// <summary>
        /// Описание Patch запроса
        /// </summary>
        public Operation Patch { get; set; }
        /// <summary>
        /// Описание Trace запроса
        /// </summary>
        public Operation Trace { get; set; }
        public ICollection<Server> Servers { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
    }
}
