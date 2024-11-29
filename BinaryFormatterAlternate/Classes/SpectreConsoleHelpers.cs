using System.Runtime.CompilerServices;

namespace BinaryFormatterAlternate.Classes;

public static class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a prompt to the console, instructing the user to press ENTER to exit the demo.
    /// </summary>
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }

    /// <summary>
    /// Enhances the appearance of the specified string by applying color markup to specific placeholders for Spectre.Console.
    /// </summary>
    /// <param name="sender">The input string containing placeholders to be beautified.</param>
    /// <returns>A string with color markup applied to the placeholders "{Person}" and "{Address}".</returns>
    public static string BeautifyDump(string sender)
    {
        return sender
            .Replace("{Person}", "[yellow]{Person}[/]")
            .Replace("{Address}", "[cyan]{Address}[/]");
    }


}