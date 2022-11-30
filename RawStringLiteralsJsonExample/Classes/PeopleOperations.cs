using System.Text.Json;

namespace JsonExample.Classes;

public class PeopleOperations
{
    /// <summary>
    /// Write Person data too
    /// </summary>
    public static string FileName => "People.json";
    public static JsonSerializerOptions Indented
        => new() { WriteIndented = true };
    /// <summary>
    /// Read people into list
    /// </summary>
    /// <returns></returns>
    public static List<Person> Read()
    {
        var list = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileName));

        return list!;
    }
    /// <summary>
    /// Save people to a file
    /// </summary>
    /// <param name="list">Valid list of people</param>
    public static void Save(List<Person> list)
    {
        File.WriteAllText(FileName, JsonSerializer.Serialize(list, Indented));
    }
}