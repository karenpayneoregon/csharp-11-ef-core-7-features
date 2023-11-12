using GenericMathListPatternConsoleApp.Classes;

namespace GenericMathListPatternConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Examples.BasicExample();
        Examples.GetIntegers();
        Examples.GetDecimals();
        Examples.JustGetTheNumbers();

        //Examples.BetweenExamples();

        Console.ReadLine();
    }
}