using QuestionOfTheDay.Extensions;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {
        MissingSample();

        ExitPrompt();
    }

    private static void MissingSample()
    {
        int[] array2 = { 1, 3, 6, 7, 8, 10, 11, 4 };
        var result1 = array2.Missing1A();
        var result2 = array2.Missing();

        Console.WriteLine(ObjectDumper.Dump(result1));
        Console.WriteLine();
        Console.WriteLine(ObjectDumper.Dump(result2));
    }
}