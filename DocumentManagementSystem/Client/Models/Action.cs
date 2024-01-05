using DocumentManagementSystem.Shared.OpenApi;

namespace DocumentManagementSystem.Client.Models
{
    /// <summary>
    /// Модель API/Action, так называемого действия
    /// </summary>
    public class Action
    {
        public Action(PathItem pathItem, string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
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
        public Dictionary<string, Response> Responses { get; set; }



        ///// <summary>
        ///// Тело запроса(ключ - медиа тип, значение - тело запроса)
        ///// </summary>
        //public Dictionary<string, MediaType> Request { get; set; }
        ///// <summary>
        ///// Тело ответа(ключ - http код ответа, значение - возможные ответы)
        ///// </summary>
        //public Dictionary<string, Response> Response { get; set; }

        void Parse(Operation operation, string method)
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
                Requests = new();

                foreach (var mediaType in operation.RequestBody.Content)
                    Requests.Add(mediaType.Key, mediaType.Value.Schema);
            }

            if (operation.Responses is not null && operation.Responses.Count > 0)
            {
                Responses = new();
                foreach (var response in operation.Responses)
                {
                    if (response.Value.Content is not null && response.Value.Content.Count > 0)
                    {
                        Responses.Add(response.Key, response.Value);
                    }
                }
            }
        }
    }
}
