using ReadEntitySettings.Models;
using System.Text.Json;
using ReadEntitySettings.Classes;

namespace ReadEntitySettings;

internal partial class Program
{
    static void Main(string[] args)
    {
        ReadCreateNew();
        
        AnsiConsole.MarkupLine("[yellow]From class should create[/]");
        if (EntitySettings.CreateNew())
        {
            AnsiConsole.MarkupLine("[green]Create database and populate[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Do not recreate database[/]");
        }
        Console.WriteLine();

        ReadAllSettings();

        Console.ReadLine();
    }

    private static void ReadAllSettings()
    {
        AnsiConsole.MarkupLine($"[yellow]{nameof(ReadAllSettings)}[/]");
        var settings = JsonSerializer.Deserialize<ConfigurationRoot>(File.ReadAllText("appsettings.json"));
        AnsiConsole.MarkupLine(settings.EntityConfiguration.CreateNew
            ? "[green]Create database and populate[/]"
            : "[red]Do not recreate database[/]");

        Console.WriteLine();
    }

    private static void ReadCreateNew()
    {
        AnsiConsole.MarkupLine($"[yellow]{nameof(ReadCreateNew)}[/]");

        string filePath = "appsettings.json";


        string json = File.ReadAllText(filePath);
        using JsonDocument doc = JsonDocument.Parse(json);

        JsonElement root = doc.RootElement;
        if (root.TryGetProperty(nameof(EntityConfiguration), out JsonElement entityConfig))
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            EntityConfiguration settings = JsonSerializer.Deserialize<EntityConfiguration>(entityConfig.GetRawText(), options);

            Console.WriteLine($"CreateNew: {settings.CreateNew}");
        }
        else
        {
            Console.WriteLine("EntityConfiguration section not found.");
        }

        Console.WriteLine();

    }
}