using System.Configuration;

namespace ValidatorsApp.Classes;
internal class ValidationHelpers
{
    public static void ValidateInteger(IntegerValidator integerValidator, int valueToValidate)
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
        }
    }
}
