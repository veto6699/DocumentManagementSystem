using DocumentManagementSystem.Shared.OpenApi;
using System.IO;

namespace DocumentManagementSystem.Client.Models
{
    /// <summary>
    /// Модель API/Action, так называемого действия
    /// </summary>
    public struct Action
    {
        public Action(PathItem pathItem, string path)
        {
            if(!string.IsNullOrWhiteSpace(path))
                Path = path;

            if (pathItem.Post is not null)
                Parse(pathItem.Post, "POST");

            if (pathItem.Get is not null)
                Parse(pathItem.Get, "GET");

            if (pathItem.Put is not null)
                Parse(pathItem.Put, "UPDATE");

            if (pathItem.Delete is not null)
                Parse(pathItem.Delete, "DELETE");

            if (pathItem.Head is not null)
                Parse(pathItem.Head, "HEAD");

            if (pathItem.Options is not null)
                Parse(pathItem.Options, "OPTIONS");

            if (pathItem.Patch is not null)
                Parse(pathItem.Patch, "PATCH");

            if (pathItem.Trace is not null)
                Parse(pathItem.Trace, "TRACE");
        }
        /// <summary>
        /// Путь
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Метод взаимодействия
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Краткое описание, для заголовка
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Полное описание, для подробного описания работы API
        /// </summary>
        public string Description { get; set; }

        void Parse(Operation operation, string method)
        {
            Method = method;

            if(operation.Summary is not null)
            {
                Summary = operation.Summary;
            }

            if (operation.Description is not null)
            {
                Description = operation.Description;
            }
        }
    }
}
