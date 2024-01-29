using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using task_management_api.Enums;

public class JsonStringEnumConverter <T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumString = reader.GetString();
        return Enum.TryParse<T>(enumString, true, out var result) ? result : default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(Enum.GetName(typeof(T), value));
    }
}