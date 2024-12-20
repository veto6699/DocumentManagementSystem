using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocumentManagementSystem.Client.Constants
{
    internal class SystemConstants
    {
        internal const string PropertySpace = "  ";
        internal readonly static JsonSerializerOptions JSONSerializerOptions = new() { PropertyNameCaseInsensitive = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    }
}
