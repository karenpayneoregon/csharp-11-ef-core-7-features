using GenericMathConsoleApp.Models;

namespace GenericMathConsoleApp.Classes;

internal class MenuOperations
{
    /// <summary>
    /// Creates and configures a selection prompt for displaying a menu of options.
    /// </summary>
    /// <returns>
    /// A <see cref="SelectionPrompt{MenuItem}"/> instance configured with menu options and styles.
    /// </returns>
    /// <remarks>
    /// The selection prompt includes various menu items, each associated with an action to execute upon selection.
    /// It supports search functionality and highlights the selected option.
    /// </remarks>
    public static SelectionPrompt<MenuItem> SelectionPrompt()
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = new Style(Color.White, Color.Blue1, Decoration.None),
            SearchHighlightStyle = new Style(Color.Blue1, Color.White, Decoration.None), 
            SearchEnabled = true
        };

        menu.Title("[orchid1]Select a option[/]");
        menu.PageSize(14);

        _ = menu.AddChoices(new List<MenuItem>()
        {
            new () {Id =  1,  Text  = "Add ByRef Extension ", Action = Samples.AddByRefExtensionExamples },
            new () {Id =  2,  Text  = "Clamp               ", Action = Samples.ClampExamples },
            new () {Id =  3,  Text  = "IsOdd IsEven        ", Action = Samples.IsOddIsEvenExamples },
            new () {Id =  4,  Text  = "Invert              ", Action = Samples.Invert },
            new () {Id =  5,  Text  = "Increment Decrement ", Action = Samples.IncrementDecrementExamples },
            new () {Id =  6,  Text  = "Preserve Array      ", Action = Samples.PreserveArrayExamples },
            new () {Id =  7,  Text  = "Generic Helpers     ", Action = Samples.GenericHelpersExamples },
            new () {Id =  8,  Text  = "Switch expression   ", Action = Samples.Expressions },
            new () {Id =  10, Text  = "Rounding            ", Action = Samples.Rounding },
            new () {Id =  11, Text  = "Percentage          ", Action = Samples.PercentageExample },
            new () {Id =  12, Text  = "Add positive        ", Action = Samples.AddAllNumbersExample },
            new () {Id =  13, Text  = "About               ", Action = About },
            new () {Id =  -1, Text  = "Exit                ", Action = () => Environment.Exit(0)},
        });

        Action<int> printActionDel = Console.WriteLine;
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