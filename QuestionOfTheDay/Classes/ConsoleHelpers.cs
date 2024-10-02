namespace QuestionOfTheDay.Classes;

public partial class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a question prompt and returns the user's response.
    /// </summary>
    /// <param name="questionText">The text of the question.</param>
    /// <returns>True if the user selects 'Y', False if the user selects 'N'.</returns>
    public static bool Question(string questionText)
    {
        ConfirmationPrompt prompt = new($"[{Color.Yellow}]{questionText}[/]")
        {
            DefaultValueStyle = new(Color.Cyan1, Color.Black, Decoration.None),
            ChoicesStyle = new(Color.Yellow, Color.Black, Decoration.None),
            InvalidChoiceMessage = $"[{Color.Red}]Invalid choice[/]. Please select a Y or N.",
        };

        return prompt.Show(AnsiConsole.Console);
    }
}
