using System.Numerics;
using GenericMathLibrary;
using System.Runtime.CompilerServices;

namespace GenericMathConsoleApp.Classes
{
    internal class Samples
    {
        public static void PreserveArrayExamples()
        {

            PrintSampleName();

            string[] intValues = { "1", "2", "A", "4" };
            AnsiConsole.MarkupLine($"string[[]] intValues = {{ \"1\", \"2\", \"A\", \"4\" }}; = [springgreen2]{string.Join(",", intValues.ToNumbersPreserveArray<int>())}[/]");

            string[] doubleValues = { "1.1m", "2.2", "A", "4.5" };
            AnsiConsole.MarkupLine($"string[[]] doubleValues = {{ \"1.1m\", \"2.2\", \"A\", \"4.5\" }}; = [springgreen2]{string.Join(",", doubleValues.ToNumbersPreserveArray<double>())}[/]");
            ScreenUtilities.MenuPrompt();
        }

        public static void ClampExamples()
        {

            PrintSampleName();

            AnsiConsole.MarkupLine($"12.Clamp(1, 10) = [springgreen2]{12.Clamp(1, 10)}[/]");
            AnsiConsole.MarkupLine($"12.Clamp(1, 12) = [springgreen2]{12.Clamp(1, 12)}[/]");

            Console.WriteLine(12m.Clamp(1, 10.5m));
            AnsiConsole.MarkupLine($"12m.Clamp(1, 10.5m) = [springgreen2]{12m.Clamp(1, 10.5m)}[/]");
            AnsiConsole.MarkupLine($"12m.Clamp(1, 12.5m) = [springgreen2]{12m.Clamp(1, 12.5m)}[/]");

            ScreenUtilities.MenuPrompt();
        }

        public static void Invert()
        {

            PrintSampleName();

            int iValue = -10;
            AnsiConsole.MarkupLine($"int iValue = -10; = [springgreen2]{iValue.Invert()}[/]");

            decimal dDecimal = 10.6m;

            AnsiConsole.MarkupLine($"decimal dDecimal = 10.6m; = [springgreen2]{dDecimal.Invert()}[/]");

            ScreenUtilities.MenuPrompt();
        }

        public static void IncrementDecrementExamples()
        {

            PrintSampleName();

            int value = 10;
            AnsiConsole.MarkupLine($"value.Increment() = [springgreen2]{value.Increment()}[/]");
            AnsiConsole.MarkupLine($"value.Decrement() = [springgreen2]{value.Decrement()}[/]");

            value = 0;
            for (int index = 0; index < 10; index++)
            {
                value = value.Increment();
            }

            AnsiConsole.MarkupLine($"For Increment [springgreen2]{value}[/]");

            for (int index = 0; index < 10; index++)
            {
                value = value.Decrement(2);
            }

            AnsiConsole.MarkupLine($"For Decrement(2) [springgreen2]{value}[/]");

            double dValue = 0.5;
            Console.WriteLine("double dValue = 0.5;");
            AnsiConsole.MarkupLine($"dValue.Increment() = [springgreen2]{dValue.Increment()}[/]");
            AnsiConsole.MarkupLine($"dValue.Decrement() = [springgreen2]{dValue.Decrement()}[/]");

            ScreenUtilities.MenuPrompt();
        }

        public static void IsOddIsEvenExamples()
        {
            PrintSampleName();

            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };");
            AnsiConsole.MarkupLine($"string.Join(\",\", intArray.Where(x => x.IsEven())) = [springgreen2]{string.Join(",", intArray.Where(x => x.IsEven()))}[/]");
            AnsiConsole.MarkupLine($"string.Join(\",\", intArray.Where(x => x.IsOdd())) = [springgreen2]{string.Join(",", intArray.Where(x => x.IsOdd()))}[/]");

            Console.WriteLine();
            double[] doubleArray = { 1, 2, 3, 4.6, 5, 6.5, 7, 8, 9, 10 };
            Console.WriteLine(string.Join(",", doubleArray.Where(x => x.IsEven()))); // 2,8,10

            ScreenUtilities.MenuPrompt();
        }

        public static void GenericHelpersExamples()
        {

            PrintSampleName();
            
            AnsiConsole.MarkupLine($"GenericHelpers.Add(2, 2); = [springgreen2]{GenericHelpers.Add(2, 2)}[/]");
            int item1 = GenericHelpers.AddAll<int>(new[] { 2, 3 });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<int>(new[[]] {{2,3}}); = [springgreen2]{item1}[/]");
            decimal item2 = GenericHelpers.AddAll<decimal>(new[] { 2.5m, 3.5m });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<decimal>(new[[]] {{2.5m,3.5m}}); = [springgreen2]{item2}[/]");

            var test4 = 9.Add(1);

            double[] doubles = { 10, 12, 3.5 };
            var test5 = doubles.AddAll<double>();

            var item3 = GenericHelpers.AddAll<double>(new double[] { 22.5, 22.6 });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<double>(new double[[]] {{22.5,22.6}}); = [springgreen2]{item3}[/]");

            ScreenUtilities.MenuPrompt();
        }

        public static void AddByRefExtensionExamples()
        {

            PrintSampleName();

            int intValue = 10;
            int value = 0;

            string text = "[cyan1]Used vars[/] ";
            string variables = $$"""
            {{text}}
            [dodgerblue1]int[/] intValue = 10;
            [dodgerblue1]int[/] value = 0;
            [dodgerblue1]double[/] doubleValue = 20.5;
            """;
            AnsiConsole.MarkupLine(variables);
            Console.WriteLine();

            intValue.Add(2, ref value);
            AnsiConsole.MarkupLine($"intValue.Add(2, [green1]ref[/] value) = [springgreen2]{value}[/]");

            double doubleValue = 20.5;
            doubleValue.Add(2, ref doubleValue);
            AnsiConsole.MarkupLine($"doubleValue.Add(2, [green1]ref[/] doubleValue); = [springgreen2]{doubleValue}[/]");

            ScreenUtilities.MenuPrompt();
        }

        public static void Expressions()
        {
            ExpressionBodiedMember(2.2);
        }

        public static void Rounding()
        {
            decimal someDecimal = 10.1234m;
            AnsiConsole.MarkupLine($"[green]someDecimal.Round(3)[/] = [white]{someDecimal.Round(3)}[/]");
            double someDouble = 10.1234;
            AnsiConsole.MarkupLine($"[green]someDouble.Round(3)[/] = [white]{someDouble.Round(3)}[/]");
            ScreenUtilities.MenuPrompt();
        }
        public static void ExpressionBodiedMember<T>(T caseSwitch) where T : INumber<T> =>
        (
            caseSwitch is 1 ? (Action)Case1 :
            caseSwitch is 2.2 ? Case2 :
            caseSwitch is 3 ? Case3 :
            caseSwitch is > 3 ? Unknown : 
            throw new ArgumentOutOfRangeException(nameof(caseSwitch)))
        ();

        public static void Case1()
        {
            Print();
            ScreenUtilities.MenuPrompt();
        }
        public static void Case2()
        {
            Print();
            ScreenUtilities.MenuPrompt();
        }
        public static void Case3()
        {
            PrintSampleName();
            ScreenUtilities.MenuPrompt();
        }

        public static void Unknown()
        {
            Print();
            ScreenUtilities.MenuPrompt();
        }

        public static void GreaterThanLesserThan()
        {

            TimeOnly timeOnly1 = new(14, 0, 0);
            TimeOnly timeOnly2 = new(13, 0, 0);

            AnsiConsole.MarkupLine($"[white]    timeOnly2.IsLessThan(timeOnly1)[/] {timeOnly2.IsLessThan(timeOnly1).ToYesNoString()}");
            AnsiConsole.MarkupLine($"[white]    timeOnly2.IsLessThan(timeOnly1)[/] {timeOnly2.IsLessThan(timeOnly1).ToYesNoString()}");
            AnsiConsole.MarkupLine($"[white] timeOnly2.IsGreaterThan(timeOnly1)[/] {timeOnly2.IsGreaterThan(timeOnly1).ToYesNoString()}");

            Console.WriteLine();

            AnsiConsole.MarkupLine($"[white]                1.IsGreaterThan(2)[/]  {1.IsGreaterThan(2).ToYesNoString()}");
            AnsiConsole.MarkupLine($"[white]               10.IsGreaterThan(2)[/]  {10.IsGreaterThan(2).ToYesNoString()}");



        }

        #region Utility

        private static void PrintSampleName([CallerMemberName] string? methodName = null)
        {
            Render(new Rule($"[white on blue]{methodName!.SplitCamelCase()}[/]")
                .RuleStyle(Style.Parse("silver"))
                .Centered());
            Console.WriteLine();
        }

        private static void Print([CallerMemberName] string? methodName = null)
        {
            AnsiConsole.MarkupLine($"[white on blue]{methodName}[/]");
            Console.WriteLine();
        }
        
        private static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }


        #endregion
    }
}
