using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ExecuteDeleteSample;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample: EF Core ExecuteDelete";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    #region Screen helpers
    public static Table CreateTableEntityFramework()
        => new Table().RoundedBorder()
            .AddColumn("[cyan]Event[/]")
            .AddColumn("[cyan]Count[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]Results[/]");

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        
        Render(new Rule("[yellow]Press a key to exit the demo[/]")
            .RuleStyle(Style.Parse("silver"))
            .Centered());

        Console.ReadLine();
    }
    #endregion
}