using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace NorthWind2023App;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("[white on blue]EF Core logs under LogFiles[/]");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
