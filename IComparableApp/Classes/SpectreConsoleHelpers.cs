#nullable enable
using System.Runtime.CompilerServices;

namespace IComparableApp.Classes;

public class SpectreConsoleHelpers
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

    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
        Console.WriteLine();
    }
    public static void PrintHeader([CallerMemberName] string? methodName = null)
    {
        Console.WriteLine();
        AnsiConsole.MarkupLine($"[yellow]{methodName}[/]");
   
    }

    public static string PrintValue<T>(T item) => $"[cyan]{item!.ToString()}[/]";
    public static string PrintYes<T>(T item) => $"[green]{item!.ToString()}[/]";
    public static string PrintNo<T>(T item) => $"[red]{item!.ToString()}[/]";
    
}
