using System.Text.Json;
using System.Text.Json.Serialization;

public class TJsonConverter<T> : JsonConverter<T> where T : class
{
    private readonly Func<string, Type> _typeResolver;

    public TJsonConverter(Func<string, Type> typeResolver)
    {
        _typeResolver = typeResolver ?? throw new ArgumentNullException(nameof(typeResolver));
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDoc.RootElement;

        if (!jsonObject.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("The JSON object does not contain a 'type' property.");
        }

        var type = typeProperty.GetString();
        var targetType = _typeResolver(type??string.Empty);

        if (targetType == null)
        {
            throw new JsonException($"Unable to resolve type for: {type}");
        }

        return JsonSerializer.Deserialize(jsonObject.GetRawText(), targetType, options) as T;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Serialization is not implemented.");
    }
}
