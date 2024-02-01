using System.Configuration;
using ValidatorsApp.Classes;
using static ValidatorsApp.Classes.SpectreConsoleHelpers;

// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace ValidatorsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        IntegerValidationSample();

        ExitPrompt();
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
        ValidationHelpers.ValidateIntegerMicrosoft(integerValidator, testInt);
        Console.WriteLine();

        testInt = 1;
        ValidationHelpers.ValidateIntegerMicrosoft(integerValidator, testInt);
        Console.WriteLine();

        testInt = 5;
        ValidationHelpers.ValidateIntegerMicrosoft(integerValidator, testInt);
    }
}