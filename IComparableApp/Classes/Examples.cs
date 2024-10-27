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

        AnsiConsole.MarkupLine($"[{Color.Fuchsia}]Nullable int[/]");
        AnsiConsole.MarkupLine($"Is {PrintValue(value)} between " +
                               $"{PrintValue(start)} and {PrintValue(end)}? " +
                               $"{PrintYes(value.Value.Between(start.Value, end.Value).ToYesNo())}");

        Console.WriteLine();

        AnsiConsole.MarkupLine($"[{Color.Fuchsia}]int[/]");

        foreach (var (index, item) in MockedInt.List.Index())
        {
            AnsiConsole.MarkupLine($"{index,-3}Is " +
                                   $"{PrintValue(item.Value)} between " +
                                   $"{PrintValue(item.Start)} and {PrintValue(item.End)}? " +
                                   $"{PrintYes(item.Value.Between(item.Start, item.End).ToYesNo())}");
        }


    }
    public static void BetweenDecimal()
    {
        PrintHeader();


        foreach (var (index, item) in MockedDecimals.List.Index())
        {
            AnsiConsole.MarkupLine($"{index,-3}Is " +
                                   $"{PrintValue(item.Value)} between " +
                                   $"{PrintValue(item.Start)} and {PrintValue(item.End)}? " +
                                   $"{PrintYes(item.Value.Between(item.Start, item.End).ToYesNo())}");
        }

    }
    public static void BetweenDateTime()
    {
        PrintHeader();


        foreach (var (index, item) in MockedDateTimes.List.Index())
        {
            AnsiConsole.MarkupLine($"{index,-3}Is " +
                                   $"{PrintValue(item.Value)} between " +
                                   $"{PrintValue(item.Start)} and {PrintValue(item.End)}? " +
                                   $"{PrintYes(item.Value.Between(item.Start, item.End).ToYesNo())}");
        }


    }

    public static void BetweenDateOnly()
    {

        PrintHeader();
        
        foreach (var (index, item) in MockedDateOnlyItem.List.Index())
        {
            AnsiConsole.MarkupLine($"{index,-3}Is " +
                                   $"{PrintValue(item.Value)} between " +
                                   $"{PrintValue(item.Start)} and {PrintValue(item.End)}? " +
                                   $"{PrintYes(item.Value.Between(item.Start, item.End).ToYesNo())}");
        }

    }

    public static void BetweenTimeOnly()
    {
        PrintHeader();

        foreach (var (index, item) in MockedTimeOnlyItem.List.Index())
        {
            AnsiConsole.MarkupLine($"{index,-3}Is " +
                                   $"{PrintValue(item.Value)} between " +
                                   $"{PrintValue(item.Start)} and {PrintValue(item.End)}? " +
                                   $"{PrintYes(item.Value.Between(item.Start, item.End).ToYesNo())}");
        }

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


    }

}
