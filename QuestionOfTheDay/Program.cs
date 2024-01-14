using QuestionOfTheDay.Extensions;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {


        int[] array = { 1,3,6,7,8,10,11,4 };
        var results = array.Missing(); 


        Console.WriteLine(ObjectDumper.Dump(results));

        ExitPrompt();
    }
}