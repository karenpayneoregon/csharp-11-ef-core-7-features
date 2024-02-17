using QuestionOfTheDay.Classes;
using QuestionOfTheDay.Models;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {
        Language language = MenuChoices.LanguageChoice;
        if (language.Id == -1)
        {
            return;
        }

        AnsiConsole.MarkupLine($"[yellow]{language.Title}[/] [cyan]{language.Code}[/]");

        ExitPrompt();
    }
}

