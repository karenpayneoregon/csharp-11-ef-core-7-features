using System.Runtime.CompilerServices;

namespace FormattableSamples.Classes;

public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        AnsiConsole.MarkupLine("[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]");
        Console.ReadLine();
    }


    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[b]Method:[/] [cyan]{methodName.SplitCase()}[/]");
        Console.WriteLine();
    }

    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
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
}