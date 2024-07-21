using System.Runtime.CompilerServices;


namespace ISetSamples.Classes;

public static class SpectreConsoleHelpers
{
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

    /// <summary>
    /// Display method name split by camel case
    /// </summary>
    public static void ShowExecutingMethodName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"   [white on blue]{methodName.SplitCamelCase()}[/]");
    }

    public static void ShowExecutingMethodName1([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[white on blue]{methodName.SplitCamelCase()}[/]");
    }


}