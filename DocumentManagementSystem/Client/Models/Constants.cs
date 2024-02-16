using System.Text.Json;

namespace DocumentManagementSystem.Client.Models
{
    public class Constants
    {
        public const string PropertySpace = "  ";
        public static JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };
    }
}
