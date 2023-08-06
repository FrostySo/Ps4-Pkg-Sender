using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ps4_Pkg_Sender.Json.Converters {
    public class DictionaryConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Dictionary<string, object>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.TokenType == JsonToken.StartObject) {
                var dictionary = new Dictionary<string, object>();
                while (reader.Read()) {
                    if (reader.TokenType == JsonToken.EndObject)
                        break;

                    if (reader.TokenType == JsonToken.PropertyName) {
                        string propertyName = reader.Value.ToString();
                        reader.Read();

                        if (reader.TokenType == JsonToken.StartObject && TryReadColorObject(reader, out var color)) {
                            dictionary.Add(propertyName, color);
                        } else {
                            object value;
                            if(propertyName == "Font") {
                                value = serializer.Deserialize<Font>(reader);
                            } else {
                                value = serializer.Deserialize(reader);
                            }
                            dictionary.Add(propertyName, value);
                        }
                    }
                }
                return dictionary;
            } else {
                throw new JsonException("Expected the start of an object.");
            }
        }

        private bool TryReadColorObject(JsonReader reader, out Color color) {
            JObject colorObject = JObject.Load(reader);

            if (colorObject.TryGetValue("Transparent", out var transparentToken) &&
                transparentToken.Type == JTokenType.Boolean && (bool)transparentToken) {
                color = Color.Transparent;
                return true;
            }

            if (colorObject.TryGetValue("Empty", out var emptyToken) &&
                emptyToken.Type == JTokenType.Boolean && (bool)emptyToken) {
                color = Color.Empty;
                return true;
            }

            if (colorObject.TryGetValue("A", out var aToken) &&
                colorObject.TryGetValue("R", out var rToken) &&
                colorObject.TryGetValue("G", out var gToken) &&
                colorObject.TryGetValue("B", out var bToken) &&
                aToken.Type == JTokenType.Integer &&
                rToken.Type == JTokenType.Integer &&
                gToken.Type == JTokenType.Integer &&
                bToken.Type == JTokenType.Integer) {
                int a = (int)aToken;
                int r = (int)rToken;
                int g = (int)gToken;
                int b = (int)bToken;

                color = Color.FromArgb(a, r, g, b);
                return true;
            }

            color = default(Color);
            return false;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var dictionary = (Dictionary<string, object>)value;

            writer.WriteStartObject();

            foreach (var kvp in dictionary) {
                writer.WritePropertyName(kvp.Key);

                if (kvp.Value is Color color) {
                    WriteColorObject(writer, color);
                } else if (kvp.Value is IEnumerable<object> enumerable) {
                    writer.WriteStartArray();
                    foreach (var item in enumerable) {
                        serializer.Serialize(writer, item);
                    }
                    writer.WriteEndArray();
                } else {
                    serializer.Serialize(writer, kvp.Value);
                }
            }

            writer.WriteEndObject();
        }

        private void WriteColorObject(JsonWriter writer, Color color) {
            writer.WriteStartObject();
            writer.WritePropertyName("A");
            writer.WriteValue(color.A);
            writer.WritePropertyName("R");
            writer.WriteValue(color.R);
            writer.WritePropertyName("G");
            writer.WriteValue(color.G);
            writer.WritePropertyName("B");
            writer.WriteValue(color.B);
            writer.WritePropertyName("Transparent");
            writer.WriteValue(color.Name == "Transparent" ? true : false);
            writer.WritePropertyName("Empty");
            writer.WriteValue(color.IsEmpty ? true : false);
            writer.WriteEndObject();
        }
    }
}
