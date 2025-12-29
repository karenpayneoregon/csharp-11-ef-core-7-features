using System.Numerics;
using GenericMathLibrary;
using System.Runtime.CompilerServices;

namespace GenericMathConsoleApp.Classes
{
    /// <summary>
    /// Provides a collection of sample methods demonstrating various mathematical and utility operations.
    /// </summary>
    /// <remarks>
    /// This class contains static methods showcasing examples such as clamping values, 
    /// inverting numbers, working with percentages, and other generic helper functionalities.
    /// These examples are intended for educational and demonstration purposes.
    /// </remarks>
    internal class Samples
    {
        public static void AddAllNumbersExample()
        {
            PrintSampleName();

            double[] values = [100, 50, -75, 102.50, -77.50];
            Console.WriteLine("double[] values = [100, 50, -75, 102.50, -77.50]");
            AnsiConsole.MarkupLine($"[springgreen2]{values.AddAllNumbers()}[/]");
            ScreenUtilities.MenuPrompt();
        }

        /// <summary>
        /// Demonstrates the usage of a generic percentage type by generating and displaying
        /// a list of percentage values from 0% to 100% in increments of 10%.
        /// </summary>
        /// <remarks>
        /// This method utilizes the <see cref="Percent{T}"/> type to create percentage values
        /// and formats them for display using ANSI console markup. It is intended to showcase
        /// the flexibility and utility of generic math in C#.
        ///
        /// https://dev.to/entomy/cs-generic-math-from-f-31a7
        /// 
        /// </remarks>
        public static void PercentageExample()
        {
            PrintSampleName();

            List<string> list = new List<string>();

            for (int index = 0; index < 110; index+=10)
            {
                list.Add($"[white]{new Percent<double>(index)}[/]");
            }

            AnsiConsole.MarkupLine(string.Join(",", list));
            ScreenUtilities.MenuPrompt();
        }

        /// <summary>
        /// Converts string arrays to numeric arrays while maintaining the original array structure.
        /// </summary>
        /// <remarks>
        /// This method demonstrates the use of the <see cref="GenericMathLibrary.GenericExtensions.ToNumbersPreserveArray{T}"/> extension method
        /// to transform string arrays into numeric arrays of a specified type without altering the array layout.
        /// Non-numeric values in the input array are replaced with default numeric values.
        /// </remarks>
        /// <example>
        /// The following example illustrates the conversion of string arrays to numeric arrays:
        /// <code>
        /// string[] intValues = { "1", "2", "A", "4" };
        /// var result = intValues.ToNumbersPreserveArray&lt;int&gt;();
        /// // Output: [1, 2, 0, 4]
        ///
        /// string[] doubleValues = { "1.1m", "2.2", "A", "4.5" };
        /// var result = doubleValues.ToNumbersPreserveArray&lt;double&gt;();
        /// // Output: [1.1, 2.2, 0.0, 4.5]
        /// </code>
        /// </example>
        public static void PreserveArrayExamples()
        {

            PrintSampleName();

            string[] intValues = ["1", "2", "A", "4"];
            AnsiConsole.MarkupLine($"string[[]] intValues = {{ \"1\", \"2\", \"A\", \"4\" }}; = [springgreen2]{string.Join(",", intValues.ToNumbersPreserveArray<int>())}[/]");

            string[] doubleValues = ["1.1m", "2.2", "A", "4.5"];
            AnsiConsole.MarkupLine($"string[[]] doubleValues = {{ \"1.1m\", \"2.2\", \"A\", \"4.5\" }}; = [springgreen2]{string.Join(",", doubleValues.ToNumbersPreserveArray<double>())}[/]");
            ScreenUtilities.MenuPrompt();
        }

        /// <summary>
        /// Demonstrates the usage of the <see cref="GenericMathLibrary.GenericExtensions.Clamp{T}(T, T, T)"/> method 
        /// to constrain values within specified minimum and maximum bounds.
        /// </summary>
        /// <remarks>
        /// This method showcases examples of clamping integer and decimal values using the generic 
        /// <c>Clamp</c> extension method. The results are displayed using formatted console output.
        /// </remarks>
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

        /// <summary>
        /// Demonstrates the inversion of numeric values using the <see cref="GenericMathLibrary.GenericExtensions.Invert{T}(T)"/> extension method.
        /// </summary>
        /// <remarks>
        /// This method showcases the usage of the <c>Invert</c> extension method to invert the sign of numeric values.
        /// It includes examples with <c>int</c> and <c>decimal</c> types, displaying the results in the console.
        /// </remarks>
        public static void Invert()
        {

            PrintSampleName();

            int iValue = -10;
            AnsiConsole.MarkupLine($"int iValue = -10; = [springgreen2]{iValue.Invert()}[/]");

            decimal dDecimal = 10.6m;

            AnsiConsole.MarkupLine($"decimal dDecimal = 10.6m; = [springgreen2]{dDecimal.Invert()}[/]");

            ScreenUtilities.MenuPrompt();
        }

        /// <summary>
        /// Demonstrates the use of increment and decrement operations on numeric types.
        /// </summary>
        /// <remarks>
        /// This method highlights the functionality of the <see cref="GenericMathLibrary.GenericExtensions.Increment{T}"/>
        /// and <see cref="GenericMathLibrary.GenericExtensions.Decrement{T}"/> extension methods.
        /// It performs the following operations:
        /// <list type="bullet">
        /// <item>Increments and decrements an integer value.</item>
        /// <item>Performs multiple increments and decrements on an integer value using a specified step.</item>
        /// <item>Increments and decrements a double value.</item>
        /// </list>
        /// The results are displayed using ANSI console markup for better visualization.
        /// </remarks>
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

        /// <summary>
        /// Demonstrates the usage of <see cref="GenericMathLibrary.GenericExtensions.IsEven{T}"/> and <see cref="GenericMathLibrary.GenericExtensions.IsOdd{T}"/> 
        /// extension methods for filtering even and odd numbers from collections.
        /// </summary>
        /// <remarks>
        /// This method showcases examples of applying the <c>IsEven</c> and <c>IsOdd</c> methods to arrays of integers 
        /// and doubles, and displays the results using formatted console output.
        /// </remarks>
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

        /// <summary>
        /// Demonstrates the usage of generic helper methods and extensions from the <see cref="GenericMathLibrary.GenericHelpers"/> 
        /// and <see cref="GenericMathLibrary.GenericExtensions"/> classes.
        /// </summary>
        /// <remarks>
        /// This method showcases examples of adding numbers, summing arrays of various numeric types, 
        /// and utilizing extension methods for generic numeric operations.
        /// </remarks>
        public static void GenericHelpersExamples()
        {

            PrintSampleName();
            
            AnsiConsole.MarkupLine($"GenericHelpers.Add(2, 2); = [springgreen2]{GenericHelpers.Add(2, 2)}[/]");
            int item1 = GenericHelpers.AddAll(new[] { 2, 3 });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<int>(new[[]] {{2,3}}); = [springgreen2]{item1}[/]");
            decimal item2 = GenericHelpers.AddAll(new[] { 2.5m, 3.5m });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<decimal>(new[[]] {{2.5m,3.5m}}); = [springgreen2]{item2}[/]");

            var test4 = 9.Add(1);

            double[] doubles = [10, 12, 3.5];
            var test5 = doubles.AddAll<double>();

            var item3 = GenericHelpers.AddAll(new double[] { 22.5, 22.6 });
            AnsiConsole.MarkupLine($"GenericHelpers.AddAll<double>(new double[[]] {{22.5,22.6}}); = [springgreen2]{item3}[/]");

            ScreenUtilities.MenuPrompt();
        }

        /// <summary>
        /// Demonstrates the usage of the <see cref="GenericMathLibrary.GenericExtensions.Add{T}(T, T, ref T)"/> method 
        /// with various numeric types, showcasing how to add values by reference.
        /// </summary>
        /// <remarks>
        /// This method highlights the functionality of the <see cref="GenericMathLibrary.GenericExtensions.Add{T}(T, T, ref T)"/> 
        /// extension method by performing addition operations on integers and doubles. 
        /// It also includes formatted console output to display the results.
        /// </remarks>
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

        /// <summary>
        /// Demonstrates rounding operations on numeric values using the <see cref="GenericMathLibrary.GenericExtensions.Round{T}(T, int)"/> method.
        /// </summary>
        /// <remarks>
        /// This method showcases how to round decimal and double values to a specified number of decimal places.
        /// It utilizes the <see cref="GenericMathLibrary.GenericExtensions.Round{T}(T, int)"/> extension method for rounding.
        /// The results are displayed using ANSI console markup for better visualization.
        /// </remarks>
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

        /// <summary>
        /// Demonstrates the usage of extension methods for comparing values using 
        /// <see cref="IComparableExtensions.IsGreaterThan{T}"/> and 
        /// <see cref="IComparableExtensions.IsLessThan{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method showcases comparisons between <see cref="TimeOnly"/> instances 
        /// and numeric values, utilizing the generic extension methods 
        /// <see cref="IComparableExtensions.IsGreaterThan{T}"/> and 
        /// <see cref="IComparableExtensions.IsLessThan{T}"/>. 
        /// The results are formatted for display using ANSI console markup and converted 
        /// to "Yes" or "No" strings using the <see cref="StringExtensions.ToYesNoString"/> method.
        /// </remarks>
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
