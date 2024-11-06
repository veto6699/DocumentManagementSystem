using System.Text.Json;

namespace DocumentManagementSystem.Client.Constants
{
    public class SystemConstants
    {
        public const string PropertySpace = "  ";
        public static JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };
    }
}
