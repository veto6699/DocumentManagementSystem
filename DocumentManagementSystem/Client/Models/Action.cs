using DocumentManagementSystem.Shared.OpenApi;
using openAPI = DocumentManagementSystem.Shared.OpenApi;
using System.IO;
using System.ComponentModel;

namespace DocumentManagementSystem.Client.Models
{
    /// <summary>
    /// Модель API/Action, так называемого действия
    /// </summary>
    public struct Action
    {
        public Action(PathItem pathItem, string path, openAPI.Components components)
        {
            if (!string.IsNullOrWhiteSpace(path))
                Path = path;

            if (pathItem.Post is not null)
                Parse(pathItem.Post, "POST", components);

            if (pathItem.Get is not null)
                Parse(pathItem.Get, "GET", components);

            if (pathItem.Put is not null)
                Parse(pathItem.Put, "UPDATE", components);

            if (pathItem.Delete is not null)
                Parse(pathItem.Delete, "DELETE", components);

            if (pathItem.Head is not null)
                Parse(pathItem.Head, "HEAD", components);

            if (pathItem.Options is not null)
                Parse(pathItem.Options, "OPTIONS", components);

            if (pathItem.Patch is not null)
                Parse(pathItem.Patch, "PATCH", components);

            if (pathItem.Trace is not null)
                Parse(pathItem.Trace, "TRACE", components);
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
        /// <summary>
        /// Параметры для запроса
        /// </summary>
        public ICollection<Parameter> Parameters { get; set; }
        /// <summary>
        /// Запросы раздленные на медиа типы
        /// </summary>
        public Dictionary<string, Schema> Requests { get; set; }
        /// <summary>
        /// Ответы раздленные на медиа типы
        /// </summary>
        public Dictionary<string, Schema> Response { get; set; }



        ///// <summary>
        ///// Тело запроса(ключ - медиа тип, значение - тело запроса)
        ///// </summary>
        //public Dictionary<string, MediaType> Request { get; set; }
        ///// <summary>
        ///// Тело ответа(ключ - http код ответа, значение - возможные ответы)
        ///// </summary>
        //public Dictionary<string, Response> Response { get; set; }

        void Parse(Operation operation, string method, openAPI.Components components)
        {
            Method = method;

            if (operation.Summary is not null)
                Summary = operation.Summary;

            if (operation.Description is not null)
                Description = operation.Description;

            if (operation.Parameters is not null && operation.Parameters.Count > 0)
                Parameters = operation.Parameters;

            if (operation.RequestBody is not null && operation.RequestBody.Content is not null && operation.RequestBody.Content.Count > 0)
            {
                foreach (var mediaType in operation.RequestBody.Content)
                {
                    //string schemaName = null;

                    //if (mediaType.Value is not null)
                    //{
                    //    if (mediaType.Value.Schema is not null)
                    //    {
                    //        if (mediaType.Value.Schema.Ref is not null)
                    //        {
                    //            if (mediaType.Value.Schema.Ref.Contains("#/components/schemas/"))
                    //                schemaName = mediaType.Value.Schema.Ref.Substring(21);
                    //        }
                    //    }
                    //}

                    //var component = components.Schemas[schemaName];

                    if (Requests is null)
                        Requests = new Dictionary<string, Schema>();

                    Requests.Add(mediaType.Key, mediaType.Value.Schema);
                }
            }
        }
    }
}
