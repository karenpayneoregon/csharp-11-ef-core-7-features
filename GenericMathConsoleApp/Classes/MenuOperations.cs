using GenericMathConsoleApp.Models;

namespace GenericMathConsoleApp.Classes;

class MenuOperations
{
    /// <summary>
    /// Create main menu
    /// </summary>
    public static SelectionPrompt<MenuItem> SelectionPrompt()
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = new Style(Color.White, Color.Blue1, Decoration.None)
        };

        menu.Title("[orchid1]Select a option[/]");
        menu.PageSize(12);

        _ = menu.AddChoices(new List<MenuItem>()
        {
            new () {Id =  1, Text = "Add ByRef Extension ", Action = Samples.AddByRefExtensionExamples },
            new () {Id =  2, Text = "Clamp               ", Action = Samples.ClampExamples },
            new () {Id =  3, Text = "IsOdd IsEven        ", Action = Samples.IsOddIsEvenExamples },
            new () {Id =  4, Text = "Invert              ", Action = Samples.Invert },
            new () {Id =  5, Text = "Increment Decrement ", Action = Samples.IncrementDecrementExamples },
            new () {Id =  6, Text = "Preserve Array      ", Action = Samples.PreserveArrayExamples },
            new () {Id =  7, Text = "Generic Helpers     ", Action = Samples.GenericHelpersExamples },
            new () {Id =  8, Text = "Switch expression   ", Action = Samples.Expressions },
            new () {Id =  9, Text = "Rounding            ", Action = Samples.Rounding },
            new () {Id =  10, Text = "About               ", Action = About },
            new () {Id = -1,Text = "Exit                "},
        });

        return menu;

    }

    public static void About()
    {
        AnsiConsole.Write(new FigletText("About").Centered().Color(Color.Red));

        var rule = new Rule();
        AnsiConsole.Write(rule);

        AnsiConsole.MarkupLine("[deepskyblue1]  Provides example for working with [cyan]C# 11[/] generic math.[/]");
        AnsiConsole.MarkupLine("[deepskyblue1]  [white]*[/] Run the various example[/]");
        AnsiConsole.MarkupLine("[deepskyblue1]  [white]*[/] Inspect the code visually and run through the debugger with breakpoints to understand the code [/]");
        AnsiConsole.MarkupLine("[deepskyblue1]  [white]*[/] [red]do not[/] use just to use, instead use generic math where it makes sense[/]");
        ScreenUtilities.MenuPrompt();
    }


}