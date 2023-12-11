#nullable enable
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericMathListPatternConsoleApp.Classes;
internal class Examples
{
    public static void BasicExample()
    {
        Print();

        var lines = MockedData.FileDataForIntegers()
            .Split(Environment.NewLine)
            .Select(line => line.Split(','))
            .ToArray();

        foreach (var parts in lines)
        {
            if (parts is [_, _, .. var values])
            {
                var results = values.GetNonNumericIndexes<int>();
                if (results.Length > 0)
                {
                    Console.WriteLine($"{string.Join(",", results)}");
                }
            }
        }
    }

    public static void GetIntegers()
    {
        Print();

        var lines = MockedData.FileDataForIntegers()
            .Split(Environment.NewLine)
            .Select((line, index) => new { Index = index, Items = line.Split(',') })
            .ToArray();

        foreach (var anonymousItem in lines)
        {
            if (anonymousItem.Items is [_, _, .. var values])
            {
                var results = values.GetNonNumericIndexes<int>();
                if (results.Length > 0)
                {
                    Console.WriteLine(
                        $"Bad Line {anonymousItem.Index,-3}{string.Join(",", results),-5} -> {string.Join(",", anonymousItem.Items.Skip(2))}");
                }
                else
                {
                    Console.WriteLine($"Line {anonymousItem.Index} is good");
                    int[] numbers = anonymousItem.Items.ToNumberArray<int>();
                    Console.WriteLine($"\t{string.Join(",", numbers)}");
                }
            }
        }
    }

    public static void GetDecimals()
    {
        Print();

        var lines = MockedData.FileDataForDecimals()
            .Split(Environment.NewLine)
            .Select((line, index) => new { Index = index, Items = line.Split(',') })
            .ToArray();

        foreach (var anonymousItem in lines)
        {
            if (anonymousItem.Items is [_, _, .. var values])
            {
                var results = values.GetNonNumericIndexes<decimal>();
                if (results.Length > 0)
                {
                    Console.WriteLine(
                        $"Bad Line {anonymousItem.Index,-3}{string.Join(",", results),-5} -> {string.Join(",", anonymousItem.Items.Skip(2))}");
                }
                else
                {
                    Console.WriteLine($"Line {anonymousItem.Index} is good");
                    decimal[] numbers = anonymousItem.Items.ToNumberArray<decimal>();
                    Console.WriteLine($"\t{string.Join(",", numbers)}");
                }
            }
        }
    }

public static void JustGetTheNumbers()
{
    Print();

    var lines = MockedData.FileDataForDecimals()
        .Split(Environment.NewLine)
        .Select((line, index) => new
        {
            Index = index, 
            Items = line.Split(',')
        })
        .ToArray();

    foreach (var anonymousItem in lines)
    {
        if (anonymousItem.Items is [_, _, .. var values])
        {
            var results = anonymousItem.Items.ToNumbersPreserveArray<decimal>();
            Console.WriteLine(string.Join(",", results.Skip(2)));
        }
    }
}

    private static void Print([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[white on blue]{methodName}[/]");
        Console.WriteLine();
    }

    public static void BetweenExamples()
    {

        Print();

        TimeOnly startTime = TimeOnly.Parse("11:00 PM");
        var hoursWorked = 2;
        TimeOnly endTime = startTime.AddHours(hoursWorked);

        // IsBetween here is native to TimeOnly
        var isBetween = TimeOnly.Parse("12:00 AM").IsBetween(startTime, endTime);
        Console.WriteLine($"12AM is between {startTime} and {endTime} -> {isBetween.ToYesNo()}");

        // uses our extension
        var age = 30;
        Console.WriteLine($"{age,-3} is over 30 {age.Between(30, 33).ToYesNo()}");

        DateTime lowDateTime = new(2022, 1, 1);
        DateTime someDateTime = new(2022, 1, 2);
        DateTime highDateTime = new(2022, 1, 8);

        // uses our extension switch expression
        Console.WriteLine($"{someDateTime:d} between {lowDateTime:d} and {highDateTime:d}? {someDateTime.Between(lowDateTime, highDateTime).ToYesNo()}");

        // uses our extension within a 
        Console.WriteLine($"{7.CaseWhen()}");
        Console.WriteLine($"{5.CaseWhen()}");
        Console.WriteLine($"{1.CaseWhen()}");
        Console.WriteLine($"{16.CaseWhen()}");


    }


}
