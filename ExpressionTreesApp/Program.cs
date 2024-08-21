using ExpressionTreesApp.Classes;
using ExpressionTreesApp.Models;
using static ExpressionTreesApp.Classes.SpectreConsoleHelpers;

namespace ExpressionTreesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var person = new Person
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1990, 12, 1)
        };

        Helpers.ViewAfter(() => person);

        Console.WriteLine();

        Helpers.ViewFromCreation(() => new Person
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1990, 12, 1)
        });

        ExitPrompt();
    }
}