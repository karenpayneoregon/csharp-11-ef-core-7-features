using Spectre.Console;

namespace AuditInterceptorSampleApp.Classes;

public class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).Centered());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }
    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
    }
}