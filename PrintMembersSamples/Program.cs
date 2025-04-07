using PrintMembersSamples.Classes;
using PrintMembersSamples.Models;
using static PrintMembersSamples.Classes.SpectreConsoleHelpers;

namespace PrintMembersSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        Print("People - birth date conditional");

        var people = PersonRepository.SamplePeople();
        foreach (var person in people)
        {
            AnsiConsole.MarkupLine(person.Colorize());
        }

        Console.WriteLine();

        Print("Taxpayers - mask SSN");

        var taxpayers = TaxpayersRepository.SampleTaxpayers();
        foreach (var taxpayer in taxpayers)
        {
            AnsiConsole.MarkupLine(taxpayer.Colorize());
        }

        Console.WriteLine();

        Print("Teacher");
        Human teacher = new Teacher("Jill", "Smith", ["555-1234", "555-6789", "555-5758"], Grade.First);
        AnsiConsole.MarkupLine(teacher.Colorize());

        ExitPrompt();
    }
}