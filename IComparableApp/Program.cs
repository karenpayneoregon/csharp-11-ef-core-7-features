
using ComparableLibrary;
using IComparableApp.Classes;
using IComparableApp.Classes.Extensions;
using static IComparableApp.Classes.SpectreConsoleHelpers;

namespace IComparableApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Examples.BetweenChars();
        Examples.BetweenInt();
        Examples.BetweenDateOnly();
        Examples.BetweenDateTime();
        Examples.BetweenTimeOnly();
        Examples.BetweenDecimal();
        Examples.BetweenTimeOnlyNative();

        Conventional();
        ExitPrompt();
    }

    private static void Conventional()
    {
        PrintHeader();

        {
            DateTime startDate = new DateTime(1979, 10, 4);
            DateTime date = new DateTime(1979, 10, 5);
            DateTime endDate = new DateTime(2016, 10, 4);

            AnsiConsole.MarkupLine(date.IsBetweenTwoDates(startDate, endDate)
                ? "[cyan]Date is between[/]"
                : "[cyan]Date is not between[/]");
        }

        Console.WriteLine();

        var result = (1..11).IsBetweenTwoInt(2);

        AnsiConsole.MarkupLine($"2 is between 1 and 11 [cyan]{(1..11).IsBetweenTwoInt(2).ToYesNo()}[/]");
        AnsiConsole.MarkupLine($"2 is between 1 and 23 [cyan]{(1..11).IsBetweenTwoInt(23).ToYesNo()}[/]");

        Console.WriteLine();

        AnsiConsole.MarkupLine($"b is between a and c [cyan]{('a'..'c').IsBetweenTwoChar('b').ToYesNo()}[/]");
        AnsiConsole.MarkupLine($"z is between a and c [cyan]{('a'..'c').IsBetweenTwoChar('z').ToYesNo()}[/]");


        Console.WriteLine();

        {
            DateOnly date = new DateOnly(2024, 10, 23);
            DateOnly startDate = new DateOnly(2024, 10, 1);
            DateOnly endDate = new DateOnly(2024, 10, 15);
            if (date.IsBetweenTwoDateOnly(startDate, endDate))
            {
                AnsiConsole.MarkupLine("[cyan]DateOnly is between[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[cyan]DateOnly is not between[/]");
            }
        }


    }


}