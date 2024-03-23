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
        //Language language = MenuChoices.LanguageChoice;
        //if (language.Id == -1)
        //{
        //    return;
        //}

        //AnsiConsole.MarkupLine($"[yellow]{language.Title}[/] [cyan]{language.Code}[/]");

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



        ExitPrompt();
    }
}

