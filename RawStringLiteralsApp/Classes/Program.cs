
using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace RawStringLiteralsApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample: Raw string literals";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}