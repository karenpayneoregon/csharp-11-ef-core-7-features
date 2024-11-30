using System.Runtime.CompilerServices;

namespace BinaryFormatterAlternate.Classes;

public static class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a prompt to the console, instructing the user to press ENTER to exit the demo.
    /// </summary>
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    /// <summary>
    /// Displays a confirmation prompt with the specified question text and returns the user's response.
    /// </summary>
    /// <param name="questionText">The text of the question to display to the user.</param>
    /// <param name="defaultValue">The default value to use if the user does not provide an input. Defaults to false.</param>
    /// <returns>True if the user selects 'Y'; otherwise, false if the user selects 'N'.</returns>
    public static bool Question(string questionText, bool defaultValue = false)
    {
        ConfirmationPrompt prompt = new($"[{Color.Yellow}]{questionText}[/]")
        {
            DefaultValueStyle = new(Color.Cyan1, Color.Black, Decoration.None),
            DefaultValue = defaultValue,
            ChoicesStyle = new(Color.Yellow, Color.Black, Decoration.None),
            InvalidChoiceMessage = $"[{Color.Red}]Invalid choice[/]. Please select a Y or N.",
            //ShowDefaultValue = false
        };

        return prompt.Show(AnsiConsole.Console);
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }

    /// <summary>
    /// Enhances the appearance of the specified string by applying color markup to specific placeholders for Spectre.Console.
    /// </summary>
    /// <param name="sender">The input string containing placeholders to be beautified.</param>
    /// <returns>A string with color markup applied to the placeholders "{Person}" and "{Address}".</returns>
    public static string BeautifyPersonDump(string sender)
    {
        return sender
            .Replace("{Person}", "[yellow]{Person}[/]")
            .Replace("{Address}", "[cyan]{Address}[/]");
    }


    public static string BeautifyPersonDump1(string sender)
    {
        return sender
            .Replace("{Person1}", "[yellow]{Person1}[/]")
            .Replace("{Address}", "[cyan]{Address}[/]");
    }

    /// <summary>
    /// Enhances the appearance of the specified string by applying color markup to the "{Friend}" placeholder for Spectre.Console.
    /// </summary>
    /// <param name="sender">The input string containing the "{Friend}" placeholder to be beautified.</param>
    /// <returns>A string with color markup applied to the "{Friend}" placeholder.</returns>
    public static string BeautifyFriendDump(string sender)
    {
        return sender
            .Replace("{Friend}", "[yellow]{Friend}[/]");
    }

}