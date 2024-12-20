using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocumentManagementSystem.Client.Constants
{
    public class SystemConstants
    {
        public const string PropertySpace = "  ";
        public readonly static JsonSerializerOptions JSONSerializerOptions = new() { PropertyNameCaseInsensitive = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    }
}
