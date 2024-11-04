using AgeCalculator;
using AgeCalculator.Extensions;
using QuestionOfTheDay.Classes;
using QuestionOfTheDay.Extensions;
using QuestionOfTheDay.Models;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {

        //if (Question("Continue?"))
        //{
        
        //}
        //else
        //{
        
        //}

        //var lineBreaks = Samples.LineEndings();
        var dob = DateTime.Parse("09/24/1956 00:00:02");

        var age1 = new DateOnly(1956, 9, 24).CalculateAge(DateTime.Today, true);
        Console.WriteLine($"Age1 = {age1.Years} years, {age1.Months} months {age1.Days} days, {age1.Time:hh\\:mm}");
        // #1. Using the Age class constructor.
        var age = new Age(dob, DateTime.Today); // as of 09/19/2021
        Console.WriteLine($"Age: {age.Years} years, {age.Months} months, {age.Days} days, {age.Time}");

        //Language language = MenuChoices.LanguageChoice;
        //if (language.Id == -1)
        //{
        //    return;
        //}

        //AnsiConsole.MarkupLine($"[yellow]{language.Title}[/] [cyan]{language.Code}[/]");


        //int current = 2024_04_03;
        //int birthDate = 1900_09_24;

        //int yearsOld = int.Parse((current - birthDate).ToString()[..^4]);
        //Console.WriteLine(yearsOld);
        //Console.WriteLine((current - birthDate).ToString().RemoveLastCharacters().Age());

        //int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        //int dob = int.Parse(new DateOnly(1900,9,24).ToString("yyyyMMdd"));
        //int age = (now - dob) / 10000;
        //Console.WriteLine(age);

        Console.WriteLine(new DateOnly(1956, 9, 24).GetAge());

        //Console.WriteLine(Samples.January25Challenge());
        AnsiConsole.MarkupLine("[yellow]Hello[/] [red]World[/]");

        IEnumerable<string> lines2 = File.ReadAllLines("output.txt");
        foreach ((int index, string line) in lines2.Index())
        {
            Console.WriteLine($"{index + 1,-4}{line}");
        }



        ExitPrompt();
    }


    private static void Merging()
    {
        int[] arr1 = [1, 2, 3, 4, 5, 0];
        int[] arr2 = [6, 7, 8, 9, 0];

        var array1 = arr1.Merge(arr2);
        Console.WriteLine(string.Join(",", array1));

        var array2 = arr1.Merge(arr2);
        Console.WriteLine(string.Join(",", array2));

        List<int> list1 = [];
        list1 = list1.Merge(arr1, arr2);
        Console.WriteLine(string.Join(",", list1));

        List<decimal> list2 = [];
        decimal[] decimals1 = [1.1m, 2.2m, 3.3m];
        decimal[] decimals2 = [4.1m, 5.2m, 6.3m];
        decimal[] decimals3 = [7.1m, 8.2m, 9.3m];

        list2 = list2.Merge(decimals1, decimals2, decimals3);
        Console.WriteLine(string.Join(", ", list2));
    }
}

public static class SomeExtensions
{
    /// <summary>
    /// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
    /// https://stackoverflow.com/a/11942/5509738
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <returns></returns>
    public static int GetAge(this DateOnly dateOfBirth)
    {
        var today = DateTime.Today;

        var value1 = (today.Year * 100 + today.Month) * 100 + today.Day;
        var value2 = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (value1 - value2) / 10000;
    }


    public static string RemoveLastCharacters1(this string sender, int count = 1)
        => sender[..^count];

    public static string RemoveLastCharacters2(this string sender, int count = 1)
        => new(sender.AsSpan()[..^count]);

    public static int Age(this string sender) => int.Parse(sender);

}