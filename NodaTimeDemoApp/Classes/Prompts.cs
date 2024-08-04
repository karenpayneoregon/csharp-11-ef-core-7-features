namespace NodaTimeDemoApp.Classes;
internal class Prompts
{
    public static DateOnly GetBirthDate() =>
        AnsiConsole.Prompt(
            new TextPrompt<DateOnly>("What is your [white]birth date[/]?")
                .PromptStyle("yellow")
                .DefaultValue(new DateOnly(1956,9,24))
                .ValidationErrorMessage(
                    "[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .Validate(dateTime => dateTime.Year switch
                {
                    >= 1920 => ValidationResult.Error("[red]Must be less than 1920[/]"),
                    _ => ValidationResult.Success(),
                })
                .AllowEmpty());
}
