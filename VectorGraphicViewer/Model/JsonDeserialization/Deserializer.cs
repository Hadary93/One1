using System.Text.Json;

public static class Deserializer
{
    public static JsonSerializerOptions DeserializeOptions<T>(Func<string, Type> typeResolver) where T : class
    {
        return new JsonSerializerOptions
        {
            Converters = { new TJsonConverter<T>(typeResolver) },
            PropertyNameCaseInsensitive = false,
        };
    }
}

