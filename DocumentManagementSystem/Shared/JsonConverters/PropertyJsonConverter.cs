using DocumentManagementSystem.Shared.OpenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.JsonConverters
{
    internal class PropertyJsonConverter : JsonConverter<Property?>
    {
        private readonly static Type _additionalPropertyType = typeof(AdditionalProperty);
        private readonly static JsonConverter<AdditionalProperty?> _defaultAdditionalPropertyConverter = (JsonConverter<AdditionalProperty?>)JsonSerializerOptions.Default.GetConverter(_additionalPropertyType);

        private readonly static Type _itemType = typeof(Item);
        private readonly static JsonConverter<Item?> _defaultItemConverter = (JsonConverter<Item?>)JsonSerializerOptions.Default.GetConverter(_itemType);

        private readonly static Type _enumType = typeof(List<string>);
        private readonly static JsonConverter<List<string>?> _defaultEnumConverter = (JsonConverter<List<string>?>)JsonSerializerOptions.Default.GetConverter(_enumType);

        private readonly static Type _xmlType = typeof(XML);
        private readonly static JsonConverter<XML> _defaultXMLConverter = (JsonConverter<XML>)JsonSerializerOptions.Default.GetConverter(_xmlType);

        public override Property? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                return null;

            Property property = new();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return property;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string? propertyName = reader.GetString();
                    reader.Read();

                    if (reader.TokenType == JsonTokenType.None || reader.TokenType == JsonTokenType.Null)
                        continue;

                    switch (propertyName)
                    {
                        case "default":
                            property.Default = JsonElement.ParseValue(ref reader).ToString();
                            break;
                        case "$ref":
                            property.Ref = reader.GetString();
                            break;
                        case "type":
                            property.Type = reader.GetString();
                            break;
                        case "description":
                            property.Description = reader.GetString();
                            break;
                        case "items":
                            property.Items = _defaultItemConverter.Read(ref reader, _itemType, options);
                            break;
                        case "format":
                            property.Format = reader.GetString();
                            break;
                        case "nullable":
                            property.Nullable = reader.GetBoolean();
                            break;
                        case "additionalProperties":
                            property.AdditionalProperties = _defaultAdditionalPropertyConverter.Read(ref reader, _additionalPropertyType, options);
                            break;
                        case "enum":
                            property.Enum = _defaultEnumConverter.Read(ref reader, _enumType, options);
                            break;
                        case "xml":
                            property.XML = _defaultXMLConverter.Read(ref reader, _xmlType, options);
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Property? property, JsonSerializerOptions options)
        {
            if (property is null)
                return;

            writer.WriteStartObject();

            if (property.Ref is not null)
            {
                writer.WritePropertyName("$ref");
                writer.WriteStringValue(property.Ref);
            }

            if (property.Default is not null)
            {
                writer.WritePropertyName("default");
                writer.WriteStringValue(property.Default);
            }

            if (property.Type is not null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(property.Type);
            }

            if (property.Description is not null)
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(property.Description);
            }

            if (property.Items is not null)
            {
                writer.WritePropertyName("items");
                _defaultItemConverter.Write(writer, property.Items, options);
            }

            if (property.Format is not null)
            {
                writer.WritePropertyName("format");
                writer.WriteStringValue(property.Format);
            }

            if (property.Nullable is not null)
            {
                writer.WritePropertyName("nullable");
                writer.WriteBooleanValue((bool)property.Nullable);
            }

            if (property.AdditionalProperties is not null)
            {
                writer.WritePropertyName("additionalProperties");
                _defaultAdditionalPropertyConverter.Write(writer, property.AdditionalProperties, options);
            }

            if (property.Enum is not null)
            {
                writer.WritePropertyName("enum");
                _defaultEnumConverter.Write(writer, property.Enum, options);
            }

            writer.WriteEndObject();
            writer.Flush();
        }
    }
}
