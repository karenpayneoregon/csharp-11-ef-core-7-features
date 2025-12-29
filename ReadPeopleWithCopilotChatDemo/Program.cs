using ReadPeopleWithCopilotChatDemo.Classes;
using ReadPeopleWithCopilotChatDemo.Models;

namespace ReadPeopleWithCopilotChatDemo;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        const string filePath = "people.txt";
        List<Person> people = await FileOperations.ReadAsync(filePath);

        foreach (var person in people)
        {
            AnsiConsole.MarkupLine($"[cyan]{person.FirstName,-12} {person.LastName,-12}[/][yellow]{person.BirthDate}[/]");
        }



        Console.ReadLine();
    }

    private static List<string> GetList()
        => DateTime.Now.IsWeekend() ? ["item 1", "item 2"] : [];
}

internal static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime self)
        => self.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;
}