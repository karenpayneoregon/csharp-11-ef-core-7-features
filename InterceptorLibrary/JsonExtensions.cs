
using System.Text.Json;

namespace InterceptorLibrary;
public static class JsonExtensions
{

    public static string ToJson<T>(this List<T> sender) 
        => JsonSerializer.Serialize(sender, Options);

    private static JsonSerializerOptions Options => new() { WriteIndented = true };
}



