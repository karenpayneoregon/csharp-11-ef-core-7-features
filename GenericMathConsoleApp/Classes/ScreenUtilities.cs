namespace GenericMathConsoleApp.Classes;

internal class ScreenUtilities
{
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void MenuPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[black on grey93]Press a key for menu[/]")
            .RuleStyle(Style.Parse("silver"))
            .Centered());
        Console.ReadLine();
    }
}