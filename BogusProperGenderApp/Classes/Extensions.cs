using System.Text.Json;

namespace BogusProperGenderApp.Classes;
public static class Extensions
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = true };
    public static string DumpAsJson(this object sender) 
        => JsonSerializer.Serialize(sender, JsonSerializerOptions);
}
