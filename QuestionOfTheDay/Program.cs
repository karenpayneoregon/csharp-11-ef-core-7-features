using QuestionOfTheDay.Extensions;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 3, 6, 7, 8, 10, 11, 4 };

        Console.WriteLine($"Method 1 Before : {ObjectDumper.Dump(string.Join(",", array))}");
        var results = array.Missing();
        Console.WriteLine($"Method 1 Result : {ObjectDumper.Dump(string.Join(",", results))}");
        Console.WriteLine($"Method 1 After  : {ObjectDumper.Dump(string.Join(",", array))}");

        int[] array2 = { 1, 3, 6, 7, 8, 10, 11, 4 };
        Console.WriteLine();
        Console.WriteLine($"Method 2 Before : {ObjectDumper.Dump(string.Join(",", array2))}");
        var results2 = array2.MissingWithMax();
        Console.WriteLine($"Method 2 Result : {ObjectDumper.Dump(string.Join(",", results2))}");
        Console.WriteLine($"Method 2 After  : {ObjectDumper.Dump(string.Join(",", array2))}");
        ExitPrompt();
    }
}