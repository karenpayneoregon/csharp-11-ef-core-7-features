using System.Configuration;
using System.Globalization;
using CommaDelimitedStringCollectionSampleApp.Classes;

namespace CommaDelimitedStringCollectionSampleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        //MainExamples();

        AnsiConsole.MarkupLine("[yellow]Comma delimited full month names[/]");
        CommaDelimitedStringCollection result1 = [];

        result1.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]);
        Console.WriteLine($"{result1}");

        AnsiConsole.MarkupLine("[yellow]Using an int array[/]");
        int[] items = [1, 2, 3];
        CommaDelimitedStringCollection result2 = new();
        result2.AddRange(items.ToStringArray());
        result2.Add("4");
        Console.WriteLine($"{result2}");

        AnsiConsole.MarkupLine("[yellow]Using DateOnly[/]");
        CommaDelimitedStringCollection results3 = [];

        List<DateOnly> dates = [new(2022, 1, 1), new(2023, 2, 14), new(2024, 3, 17), new(2025, 7, 4)];
        foreach (var date in dates)
        {
            results3.Add(date.ToString());
        }

        Console.WriteLine($"{results3}");

        List<DateOnly> datesBack = results3
            .Cast<string>()                      
            .Select(DateOnly.Parse)     
            .ToList();

        AnsiConsole.MarkupLine("Back to DateOnly");
        var results4 = string.Join(",", datesBack);
        Console.WriteLine(results4);
        Console.ReadLine();
    }

    private static void Other()
    {
        string[] mockedData = [
            "Start Download:",
            "[Start Time]: 12/30/2023 00:42:00",
            "[File Name]: log.txt",
            "[File URL]: ~/its_just_a_test/log.txt",
            "[Status] Downloading in progress",
            $"[End Time]: 12/30/2023 00:42:30",
            "Show Progress 20%:",
            "[Start Time]: 12/30/2023 00:42:32",
            "[File Name]: log.txt",
            "[File URL]: ~/another/log.txt",
            "[Status] Downloading in progress"
        ];

        LogOperations.Initialize();
        foreach (string item in mockedData)
        {
            LogOperations.Add(item);
        }

        Console.WriteLine(LogOperations.Finish());
    }

    private static void MainExamples()
    {
        {
            AnsiConsole.MarkupLine("[yellow]Comma delimited full month names[/]");
            CommaDelimitedStringCollection result = [];

            result.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]);
            Console.WriteLine($"\t{result}");

            AnsiConsole.MarkupLine("[yellow]Remove current month[/]");
            var currentMonthName = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            result.Remove(currentMonthName);
            Console.WriteLine($"\t{result}");

            AnsiConsole.MarkupLine("[yellow]Insert current month at proper index[/]");
            result.Insert(DateTime.Now.Month - 1, currentMonthName);
            Console.WriteLine($"\t{result}");
        }

        Console.WriteLine();

        {
            AnsiConsole.MarkupLine("[yellow]Comma delimited abbreviated month names[/]");
            CommaDelimitedStringCollection result = new();
            result.AddRange(DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[..^1]);
            Console.WriteLine($"\t{result}");

            for (int index = 0; index < result.Count; index++)
            {
                Console.WriteLine($"\t{result[index]}");
            }
        }

        {
            AnsiConsole.MarkupLine("[yellow]Using an int array[/]");
            int[] items = [1, 2, 3];
            CommaDelimitedStringCollection result = new();
            result.AddRange(items.ToStringArray());
            result.Add("4");
            Console.WriteLine($"\t{result}");
            AnsiConsole.MarkupLine($"\tIs [white on red]3[/] in collection {result.Contains("3").ToYesNo()}");
        }

        {
            AnsiConsole.MarkupLine("[yellow]Files found[/]");
            CommaDelimitedStringCollection result = new();
            var files = FileHelpers.FilterFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), "txt", "json");
            foreach (var file in files)
            {
                result.Add(Path.GetFileName(file));
            }
            Console.WriteLine($"\t{result}");
            Console.WriteLine(result.Contains("appsettings.json").ToYesNo());



            result.SetReadOnly();
            if (!result.IsReadOnly)
            {
                result.Add("SomeFile.txt");
            }
        }
    }
    private static string[] ConvertIntArrayToStringArray(int[] intArray)
    {
        string[] stringArray = new string[intArray.Length];
        for (int i = 0; i < intArray.Length; i++)
        {
            stringArray[i] = intArray[i].ToString();
        }
        return stringArray;
    }

}