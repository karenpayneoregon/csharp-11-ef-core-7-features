using QuestionOfTheDay.Extensions;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {


        int[] array = { 1,3,6,7,8,10,11,4 };
        var results1 = array.Missing1(); // unsorted - fails
        var results2 = array.Missing2(); // sorted   - works

        Console.WriteLine(ObjectDumper.Dump(results1));
        Console.WriteLine();
        Console.WriteLine(ObjectDumper.Dump(results2));

        ExitPrompt();
    }
}