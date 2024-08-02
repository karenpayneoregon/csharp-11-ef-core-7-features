using ReadPeopleWithCopilotChatDemo.Classes;
using ReadPeopleWithCopilotChatDemo.Models;

namespace ReadPeopleWithCopilotChatDemo;

internal partial class Program
{
    static void Main(string[] args)
    {
        string filePath = "people.txt";
        List<Person> people = FileOperations.ReadPeopleFromFile(filePath);

        foreach (var person in people)
        {
            AnsiConsole.MarkupLine($"[cyan]{person.FirstName, -12} {person.LastName,-12}[/][yellow]{person.BirthDate}[/]");
        }

        Console.ReadLine();
    }
}