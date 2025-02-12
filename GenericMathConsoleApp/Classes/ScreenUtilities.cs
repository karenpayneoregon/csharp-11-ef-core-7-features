namespace GenericMathConsoleApp.Classes;

internal class ScreenUtilities
{
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    /// <summary>
    /// Displays a menu prompt to the user, including a styled message, and waits for user input.
    /// </summary>
    public static void MenuPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[black on grey93]Press a key for menu[/]")
            .RuleStyle(Style.Parse("silver"))
            .Centered());
        Console.ReadLine();
    }
}