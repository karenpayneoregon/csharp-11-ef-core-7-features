using static System.Text.Json.JsonSerializer;

namespace SqliteHasData.Classes;
internal class JsonOperations
{
    public static Configuration GetConfiguration()
    {
        var json = File.ReadAllText("appsettings.json");
        return Deserialize<Configuration>(json);
    }
}

public class Configuration
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public EntityConfiguration EntityConfiguration { get; set; }
}

public class ConnectionStrings
{
    public string MainConnection { get; set; }
    public string SecondaryConnection { get; set; }
}

public class EntityConfiguration
{
    public bool CreateNew { get; set; }
}

