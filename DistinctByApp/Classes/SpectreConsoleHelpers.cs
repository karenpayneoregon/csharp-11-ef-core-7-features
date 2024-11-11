using System.Runtime.CompilerServices;
using DistinctByApp.LanguageExtensions;

namespace DistinctByApp.Classes;

public static class SpectreConsoleHelpers
{

    /// <summary>
    /// Prints the name of the calling method in cyan color to the console.
    /// </summary>
    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName.SplitCamelCase()}[/]");
    }
    
    /// <summary>
    /// Prints a header line for methods in Samples class.
    /// </summary>
    public static void MemberHeader()
    {
        AnsiConsole.MarkupLine($"[{Color.Chartreuse1}][u]{"Index",-7}{"Id",-10}{"First",-10}SurName[/][/]");
    }

    public static void MovieHeader()
    {
        AnsiConsole.MarkupLine($"[{Color.Chartreuse1}][u]{"Index",-7}{"Id",-10}{"Name",-25}{"Released"}[/][/]");
    }
    public static void NextResults()
    {
        AnsiConsole.MarkupLine($"[{Color.Fuchsia}]Press ENTER for next sample[/]");
        Console.ReadLine();
        Console.Clear();
    }


}