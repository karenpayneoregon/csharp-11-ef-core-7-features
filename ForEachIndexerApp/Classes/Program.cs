using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ForEachIndexerApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = $"Question of the day {DateTime.Now:D}";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
