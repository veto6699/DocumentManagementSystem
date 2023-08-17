using DocumentManagementSystem.Shared.OpenApi;

namespace DocumentManagementSystem.Client.Models
{
    public struct Controller
    {
        public Controller(string name)
        {
            Name = name;
            Actions = new();
        }

        /// <summary>
        /// Название контроллера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список действий
        /// </summary>
        public List<Action> Actions { get; set; }
    }
}
