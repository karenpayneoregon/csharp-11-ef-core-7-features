using System.Configuration;
using Serilog;

namespace ValidatorsApp.Classes;
internal class ValidationHelpers
{
    // from Microsoft
    public static void ValidateIntegerMicrosoft(IntegerValidator integerValidator, int valueToValidate)
    {
        Console.Write($"Validating integer value of {valueToValidate}");
        try
        {
            integerValidator.Validate(valueToValidate);
            Console.WriteLine("Validated.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Failed validation.  Message: {e.Message}");
            Log.Error(e, $"Failed validation.  Message: {e.Message}");
        }
    }

    // Karen's version
    public static bool ValidateInteger(IntegerValidator integerValidator, int valueToValidate)
    {
        try
        {
            integerValidator.Validate(valueToValidate);
            return true;
        }
        catch (ArgumentException e)
        {
            Log.Error(e, $"Failed validation.  Message: {e.Message}");
            return false;
        }
    }
}
