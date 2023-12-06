using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace UsingAliasExample;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[green1]Press enter to exit[/]")
            .RuleStyle(Style.Parse("white"))
            .Centered());

        Console.ReadLine();
    }
}
