
using ComparableLibrary;
using IComparableApp.Classes.Extensions;
using static IComparableApp.Classes.SpectreConsoleHelpers;

namespace IComparableApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        BetweenInt();
        BetweenDateOnly();
        BetweenDateTime();
        BetweenTimeOnly();
        BetweenDecimal();
        ExitPrompt();
    }
    /// <summary>
    /// Works with int or int?, same with decimal and double
    /// </summary>
    /// <param name="value"></param>
    private static void BetweenInt(int? value = 9)
    {
        PrintHeader();

        int? start = 5;
        int? end = 15;


        if (value.HasValue)
        {
            var result = value.Value.Between(start.Value, end.Value);
        }


        AnsiConsole.MarkupLine($"Is {PrintValue(value)} is between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Value.Between(start.Value, end.Value).ToYesNo())}");

        LineSeparator();

    }
    private static void BetweenDecimal(decimal value = 9.9m)
    {
        PrintHeader();

        decimal start = 5;
        decimal end = 9.6m;

        
        AnsiConsole.MarkupLine($"Is {PrintValue(value)} is between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Between(start, end).ToYesNo())}");


    }

    private static void BetweenDateTime()
    {
        PrintHeader();

        DateTime start = new(2023, 11, 1,14,0,0);
        DateTime end = new(2023, 11, 22,16,0,0);
        DateTime value = new(2023, 11, 22, 15, 0, 0);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} is between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Between(start, end).ToYesNo())}");

        LineSeparator();

    }

    private static void BetweenDateOnly()
    {
        PrintHeader();

        DateOnly start = new(2023, 11, 1);
        DateOnly end = new(2023, 11, 22);
        DateOnly value = new DateOnly(2023, 11, 1);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} is between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Between(start, end).ToYesNo())}");

        LineSeparator();

    }

    private static void BetweenTimeOnly()
    {
        PrintHeader();

        TimeOnly start = new(14, 0, 0);
        TimeOnly end = new(13, 0, 0);
        TimeOnly value = new(16, 0, 0);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} is between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintNo(value.Between(start, end).ToYesNo())}");

        LineSeparator();

    }

}