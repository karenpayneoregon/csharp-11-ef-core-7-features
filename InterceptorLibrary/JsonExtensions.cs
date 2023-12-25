using Newtonsoft.Json;

namespace InterceptorLibrary;
public static class JsonExtensions
{
    public static string ToJson<T>(this List<T> source)
    {
        return JsonConvert.SerializeObject(source, Formatting.Indented);
    }
}
