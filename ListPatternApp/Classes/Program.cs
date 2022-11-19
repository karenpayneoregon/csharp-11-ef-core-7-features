using ListPatternApp.Classes;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ListPatternApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: List patterns";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
    }

    private static void Print([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[white on blue]{methodName.SplitCamelCase()}[/]");
        Console.WriteLine();
    }
}