﻿using QuestionOfTheDay.Classes;
using QuestionOfTheDay.Extensions;
using QuestionOfTheDay.Models;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {
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

        //Console.WriteLine(new DateOnly(1900, 9, 24).GetAge());

        Console.WriteLine(Samples.January25Challenge());

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

        list2 = list2.Merge(decimals1,decimals2, decimals3);
        Console.WriteLine(string.Join(", ", list2));
    }
}

public static class SomeExtensions
{
    public static int GetAge(this DateOnly dateOfBirth)
    {
        var today = DateTime.Today;

        var value1 = (today.Year * 100 + today.Month) * 100 + today.Day;
        var value2 = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (value1 - value2) / 10000;
    }


    public static string RemoveLastCharacters(this string sender, int count = 4) 
        => sender[..^count];

    public static int Age(this string sender) => int.Parse(sender);

}