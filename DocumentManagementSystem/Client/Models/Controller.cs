using DocumentManagementSystem.Client.Components.OpenAPI;
using DocumentManagementSystem.Shared.OpenApi;
using Microsoft.AspNetCore.Components;

namespace DocumentManagementSystem.Client.Models
{
    public struct Controller
    {
        public Controller(string name, PathItem pathItem)
        {
            Name = name;
            IsOpen = true;
            Actions = new() { pathItem };
        }

        /// <summary>
        /// Название контроллера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Флаг, инфа о контроллере открыта
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// Список действий
        /// </summary>
        public List<PathItem> Actions { get; set; }
    }
}
