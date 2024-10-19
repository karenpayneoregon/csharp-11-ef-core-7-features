using ComparableLibrary;
using IComparableApp.Classes.Extensions;
using static IComparableApp.Classes.SpectreConsoleHelpers;
namespace IComparableApp.Classes;
internal class Examples
{
    public static void BetweenChars()
    {
        PrintHeader();
        var item = 'b'.Between('a', 'c');
        AnsiConsole.MarkupLine($"Is [blue]b[/] between [blue]a[/] and [blue]c[/] {PrintYes(item.ToYesNo())}");
        Console.WriteLine();
    }
    /// <summary>
    /// Works with int or int?, same with decimal and double
    /// </summary>
    /// <param name="value"></param>
    public static void BetweenInt(int? value = 9)
    {
        PrintHeader();

        int? start = 5;
        int? end = 15;


        if (value.HasValue)
        {
            // true
            var result1 = value.Value.Between(start.Value, end.Value);
            value = 15;
            // false
            var result2 = value.Value.BetweenExclusive(start.Value, end.Value);
            value = 9;
        }


        AnsiConsole.MarkupLine($"Is {PrintValue(value)} between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Value.Between(start.Value, end.Value).ToYesNo())}");


    }
    public static void BetweenDecimal(decimal value = 9.9m)
    {
        PrintHeader();

        decimal start = 5;
        decimal end = 9.6m;

        string output = $"Is {PrintValue(value)} between " +
                        $"{PrintValue(start)} and {PrintValue(end)}? " +
                        $"{PrintYes(value.Between(start, end).ToYesNo())}";

        AnsiConsole.MarkupLine(output);

    }

    public static void BetweenDateTime()
    {
        PrintHeader();

        DateTime start = new(2023, 11, 1, 14, 0, 0);
        DateTime end = new(2023, 11, 22, 16, 0, 0);
        DateTime value = new(2023, 11, 22, 15, 0, 0);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Between(start, end).ToYesNo())}");


    }

    public static void BetweenDateOnly()
    {
        PrintHeader();

        DateOnly start = new(2023, 11, 1);
        DateOnly end = new(2023, 11, 22);
        DateOnly value = new(2023, 11, 1);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Between(start, end).ToYesNo())}");


    }

    public static void BetweenTimeOnly()
    {
        PrintHeader();

        TimeOnly start = new(14, 0, 0);
        TimeOnly end = new(13, 0, 0);
        TimeOnly value = new(16, 0, 0);

        var result = value.Between(start, end);

        AnsiConsole.MarkupLine($"Is {PrintValue(value)} between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintNo(value.Between(start, end).ToYesNo())}");


    }

    public static void BetweenTimeOnlyNative()
    {
        PrintHeader();

        var startTime = TimeOnly.Parse("11:00 PM");
        var hoursWorked = 2;
        TimeOnly endTime = startTime.AddHours(hoursWorked);

        var isBetween = TimeOnly.Parse("12:00 AM").IsBetween(startTime, endTime);
        Console.WriteLine($"12:00 AM is between {startTime} and {endTime} -> {isBetween.ToYesNo()}"); // Yes

        isBetween = TimeOnly.Parse("1:00 PM").IsBetween(startTime, endTime);
        Console.WriteLine($"1:00 PM is between {startTime} and {endTime} -> {isBetween.ToYesNo()}"); // No

        //WhereDatesBetween

    }

    public static void Deconstruction1()
    {
        {
            var (_, contentId, answer) = Deconstruction.Demo1(1);
        }

        {
            var (id, contentID, answer) = Deconstruction.Demo2(1);
        }

        {
            var (id, contentId, answer) = Deconstruction.Conventional(1);
        }
    }
}
