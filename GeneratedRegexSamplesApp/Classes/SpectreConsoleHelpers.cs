using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace GeneratedRegexSamplesApp.Classes;

public static partial class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]");
        Console.ReadLine();
    }

    public static void PrintCyan([CallerMemberName] string methodName = null)
    {
        string SplitCase(string sender) =>
            string.Join(" ", SplitterRegex().Matches(sender)
                .Select(m => m.Value));

        AnsiConsole.MarkupLine($"[cyan]{SplitCase(methodName)}[/]");
        Console.WriteLine();
    }


    /// <summary>
    /// Spectre.Console  Add [ to [ and ] to ] so Children[0].Name changes to Children[[0]].Name
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleEscape(this string sender)
        => Markup.Escape(sender);

    /// <summary>
    /// Spectre.Console Removes markup from the specified string.
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleRemove(this string sender)
        => Markup.Remove(sender);


    [GeneratedRegex("([A-Z][a-z]+)")]
    private static partial Regex SplitterRegex();
}