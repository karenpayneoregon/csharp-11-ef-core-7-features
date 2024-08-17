using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApiApp.Classes;
using static NewsApiApp.Classes.SpectreConsoleHelpers;

namespace NewsApiApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        NewsApiClient client = new(VaultReader.Key);
        
        ArticlesResult articles= client.GetEverything(new EverythingRequest
        {
            Q = "microsoft",
            SortBy = SortBys.Popularity,
            Language = Languages.EN,
            From = DateTime.Now.AddDays(-1) // yesterday
        });

        if (articles.Status == Statuses.Ok)
        {
            AnsiConsole.MarkupLine($"[white]Found:[/] [bold green]{articles.TotalResults}[/]");
            foreach (var article in articles.Articles)
            {
                AnsiConsole.MarkupLine($"[bold cyan]{article.Title.ConsoleEscape()}[/]");
                AnsiConsole.MarkupLine($"[bold yellow]{article.Author}[/]");
                Console.WriteLine(article.Description);
                AnsiConsole.MarkupLine($"[bold green]{article.Url}[/]");
                AnsiConsole.MarkupLine($"[bold yellow]{article.PublishedAt}[/]");
                Console.WriteLine();
            }
        }
        else
        {
            AnsiConsole.MarkupLine(articles.Error.Code == ErrorCodes.SourceTemporarilyUnavailable
                ? $"[bold red]Service down[/]"
                : $"[bold red]Error: {articles.Error.Message}[/]");
        }

        ExitPrompt();
    }
}