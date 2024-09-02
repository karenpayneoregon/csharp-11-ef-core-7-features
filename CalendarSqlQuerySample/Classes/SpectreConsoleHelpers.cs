using System.Runtime.CompilerServices;

namespace CalendarSqlQuerySample.Classes;
public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).Centered());

        Console.ReadLine();
    }
    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    /// <summary>
    /// Replaces the placeholder "{Holiday}" with formatted holiday text for Spectre.Console
    /// </summary>
    /// <param name="item">The input string.</param>
    /// <returns>Formatted string with color embedded</returns>
    public static string HolidayColors(this string item)
        => item.Replace("{Holiday}", "[yellow]{[/][lightskyblue3]Holiday[/][yellow]}[/]");
}
