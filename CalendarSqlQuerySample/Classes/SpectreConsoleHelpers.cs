using System.Runtime.CompilerServices;

namespace CalendarSqlQuerySample.Classes;
public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.CursorVisible = false;

        AnsiConsole.Write(new Table()
            .Border(TableBorder.None)
            .Alignment(Justify.Center)
            .AddColumn("").AddColumn("")
            .AddRow(new Pill("Press any key to exit...", PillType.Info), new Text("")));

        Console.ReadLine();
    }
    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }

}
