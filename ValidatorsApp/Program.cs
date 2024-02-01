using System.Configuration;
using ValidatorsApp.Classes;

namespace ValidatorsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        IntegerValidationSample();

        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }

    /// <summary>
    ///     
    /// </summary>
    private static void IntegerValidationSample()
    {
        // Create Validator for the range of 1 to 10 inclusive
        int minIntVal = 1;
        int maxIntVal = 10;
        bool exclusive = false;

        IntegerValidator integerValidator = new(minIntVal, maxIntVal, exclusive);

        int testInt = 0;
        ValidationHelpers.ValidateInteger(integerValidator, testInt);
        testInt = 1;
        ValidationHelpers.ValidateInteger(integerValidator, testInt);
        testInt = 5;
        ValidationHelpers.ValidateInteger(integerValidator, testInt);
    }
}