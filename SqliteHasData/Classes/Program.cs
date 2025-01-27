using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SqliteHasData;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "EF Core Sqlite connection and HasData";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
