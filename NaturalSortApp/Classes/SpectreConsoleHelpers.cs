using Spectre.Console;

namespace NaturalSortApp.Classes;

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

    public static Table CreateTable()
        => new Table().RoundedBorder()
            .AddColumn("[cyan]FileNames[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Border(TableBorder.Square)
            .Title("[LightGreen]Results[/]");
}