namespace SqlServerHasData.Classes;

public static class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a prompt to the user, instructing them to press ENTER to exit the application.
    /// </summary>
    /// <remarks>
    /// This method renders a styled message using Spectre.Console and waits for the user to press ENTER.
    /// It is typically used as a graceful way to conclude a console application.
    /// </remarks>
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

}