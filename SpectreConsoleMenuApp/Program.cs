using SpectreConsoleMenuApp.Classes;

namespace SpectreConsoleMenuApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var languageChoice = MenuChoices.LanguageChoice;
        if (languageChoice.Id == -1)
        {
            AnsiConsole.MarkupLine("[red]No language selected. Exiting application.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[yellow]{languageChoice.Title}[/] [cyan]{languageChoice.Code}[/]");
        }
        Console.ReadLine();
    }
}