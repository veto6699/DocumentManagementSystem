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
    internal class SchemaJsonConverter : JsonConverter<Schema?>
    {
        public readonly static JsonSerializerOptions JSONSerializerOptions = new() { PropertyNameCaseInsensitive = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        private readonly static Type _itemType = typeof(Item);
        private readonly static JsonConverter<Item> _defaultItemConverter = (JsonConverter<Item>)JsonSerializerOptions.Default.GetConverter(_itemType);

        private readonly static Type _requiredType = typeof(List<string>);
        private readonly static JsonConverter<List<string>?> _defaultRequiredConverter = (JsonConverter<List<string>?>)JsonSerializerOptions.Default.GetConverter(_requiredType);

        private readonly static Type _propertyType = typeof(Dictionary<string, Property>);
        private readonly static JsonConverter<Dictionary<string, Property>> _defaultPropertyConverter = (JsonConverter<Dictionary<string, Property>>)JsonSerializerOptions.Default.GetConverter(_propertyType);

        private readonly static Type _discriminatorType = typeof(Dictionary<string, string>);
        private readonly static JsonConverter<Dictionary<string, string>> _defaultDiscriminatorConverter = (JsonConverter<Dictionary<string, string>>)JsonSerializerOptions.Default.GetConverter(_discriminatorType);

        private readonly static Type _additionalPropertyType = typeof(AdditionalProperty);
        private readonly static JsonConverter<AdditionalProperty> _defaultAdditionalPropertyConverter = (JsonConverter<AdditionalProperty>)JsonSerializerOptions.Default.GetConverter(_additionalPropertyType);

        private readonly static Type _xmlType = typeof(XML);
        private readonly static JsonConverter<XML> _defaultXMLConverter = (JsonConverter<XML>)JsonSerializerOptions.Default.GetConverter(_xmlType);

        public override Schema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                return null;

            Schema schema = new();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return schema;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string? propertyName = reader.GetString();
                    reader.Read();

                    if (reader.TokenType == JsonTokenType.None || reader.TokenType == JsonTokenType.Null)
                        continue;

                    switch (propertyName)
                    {
                        case "$ref":
                            schema.Ref = reader.GetString();
                            break;
                        case "type":
                            schema.Type = reader.GetString();
                            break;
                        case "items":
                            schema.Items = _defaultItemConverter.Read(ref reader, _itemType, options);
                            break;
                        case "required":
                            schema.Required = _defaultRequiredConverter.Read(ref reader, _requiredType, options);
                            break;
                        case "properties":
                            schema.Properties = _defaultPropertyConverter.Read(ref reader, _propertyType, options);
                            break;
                        case "discriminator":
                            schema.Discriminator = _defaultDiscriminatorConverter.Read(ref reader, _discriminatorType, options);
                            break;
                        case "description":
                            schema.Description = reader.GetString();
                            break;
                        case "additionalProperties":
                            var parseElement = JsonElement.ParseValue(ref reader).ToString();

                            if (!bool.TryParse(parseElement, out bool _))
                                schema.AdditionalProperties = JsonSerializer.Deserialize<AdditionalProperty?>(parseElement, JSONSerializerOptions);
                            break;
                        case "xml":
                            schema.XML = _defaultXMLConverter.Read(ref reader, _xmlType, options);
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Schema? schema, JsonSerializerOptions options)
        {
            if (schema is null)
                return;

            writer.WriteStartObject();

            if (schema.Ref is not null)
            {
                writer.WritePropertyName("$ref");
                writer.WriteStringValue(schema.Ref);
            }

            if (schema.Type is not null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(schema.Type);
            }

            if (schema.Items is not null)
            {
                writer.WritePropertyName("items");
                _defaultItemConverter.Write(writer, schema.Items, options);
            }

            if (schema.Required is not null)
            {
                writer.WritePropertyName("required");
                _defaultRequiredConverter.Write(writer, schema.Required, options);
            }

            if (schema.Properties is not null)
            {
                writer.WritePropertyName("properties");
                _defaultPropertyConverter.Write(writer, schema.Properties, options);
            }

            if (schema.Discriminator is not null)
            {
                writer.WritePropertyName("discriminator");
                _defaultDiscriminatorConverter.Write(writer, schema.Discriminator, options);
            }

            if (schema.Description is not null)
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(schema.Description);
            }

            if (schema.AdditionalProperties is not null)
            {
                writer.WritePropertyName("additionalProperties");
                _defaultAdditionalPropertyConverter.Write(writer, schema.AdditionalProperties, options);
            }

            writer.WriteEndObject();
            writer.Flush();
        }
    }
}
