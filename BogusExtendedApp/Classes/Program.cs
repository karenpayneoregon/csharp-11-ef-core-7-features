using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BogusExtendedApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Bogus custom dataset code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
