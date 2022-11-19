using System.Runtime.CompilerServices;
using static ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace ExecuteUpdateSample;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample: Execute update";
        SetConsoleWindowPosition(AnchorWindow.Center);
    }
}