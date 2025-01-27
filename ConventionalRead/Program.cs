using ConventionalRead.Classes;

namespace ConventionalRead;

internal partial class Program
{
    /// <summary>
    /// This method reads configuration values from the application's JSON configuration file, 
    /// such as the main connection string and entity creation settings, and displays them in the console.
    /// </summary>
    private static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("    [yellow]Source:[/][cyan] appsettings.json[/]");
        var mainConnectionString = Config.Configuration.JsonRoot()
            .GetSection(nameof(ConnectionStrings))[nameof(ConnectionStrings.MainConnection)];

        AnsiConsole.MarkupLine($"[yellow]Connection:[/] [cyan]{mainConnectionString}[/]");

        var shouldCreate = Config.Configuration.JsonRoot()
            .GetSection(nameof(EntityConfiguration))[nameof(EntityConfiguration.CreateNew)];

        AnsiConsole.MarkupLine($"    [yellow]Create:[/] [cyan]{shouldCreate.ToBool().ToYesNo()}[/]");
        Console.ReadLine();
        
    }

}