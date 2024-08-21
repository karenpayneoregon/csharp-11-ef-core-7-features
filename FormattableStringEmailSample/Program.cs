using FormattableStringEmailSample.Models;
using static FormattableStringEmailSample.Classes.SpectreConsoleHelpers;

namespace FormattableStringEmailSample;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        var service = await GetEmailService();

        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        Manager manager = new() { Id = 2, FirstName = "Sam", LastName = "Smith" };

        AnsiConsole.MarkupLine("[yellow bold]Welcome email[/]\n");
        Console.WriteLine(service.SendEmail(person, manager));


        ExitPrompt();
    }
}