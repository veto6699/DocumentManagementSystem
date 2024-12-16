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
        public override Property? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                return null;
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                return null;
            }

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
                            var items = JsonElement.ParseValue(ref reader).ToString();
                            var tmpItems = JsonSerializer.Deserialize<Item?>(items);

                            if(tmpItems is not null &&
                                tmpItems.Type is not null &&
                                tmpItems.Items is not null &&
                                tmpItems.Ref is not null)
                                    property.Items = tmpItems;

                            break;
                        case "format":
                            property.Format = reader.GetString();
                            break;
                        case "nullable":
                            property.Nullable = reader.GetBoolean();
                            break;
                        case "additionalProperties":
                            var additionalProperties = JsonElement.ParseValue(ref reader).ToString();
                            var tmpAdditionalProperties = JsonSerializer.Deserialize<AdditionalProperty?>(additionalProperties);

                            if (tmpAdditionalProperties is not null &&
                                tmpAdditionalProperties.Type is not null &&
                                tmpAdditionalProperties.Items is not null &&
                                tmpAdditionalProperties.Nullable is not null &&
                                tmpAdditionalProperties.Ref is not null &&
                                tmpAdditionalProperties.Format is not null)
                                    property.AdditionalProperties = tmpAdditionalProperties;

                            break;
                        case "enum":
                            var myEnum = JsonElement.ParseValue(ref reader);
                            property.@Enum = JsonSerializer.Deserialize<List<string>?>(myEnum);
                            break;
                    }
                }

            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Property property, JsonSerializerOptions options)
        {
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
                writer.WriteString("items", JsonSerializer.Serialize(property.Items));

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
                writer.WriteString("additionalProperties", JsonSerializer.Serialize(property.AdditionalProperties));

            if (property.Enum is not null)
                writer.WriteString("enum", JsonSerializer.Serialize(property.Enum));

            writer.WriteEndObject();
            writer.Flush();
        }
    }
}
