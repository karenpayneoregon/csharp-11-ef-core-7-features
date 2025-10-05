using System.Configuration;
using System.Diagnostics;

namespace NativeValidatorsSamples.Classes;
internal partial class Examples
{
    /// <summary>
    /// Validates an integer value using the specified <see cref="IntegerValidator"/>.
    /// </summary>
    /// <param name="integerValidator">
    /// The <see cref="IntegerValidator"/> instance used to validate the integer value.
    /// </param>
    /// <param name="valueToValidate">
    /// The integer value to be validated.
    /// </param>
    /// <remarks>
    /// If the validation fails, an <see cref="ArgumentException"/> is caught and logged.
    /// </remarks>
    private static bool ValidateInteger(IntegerValidator integerValidator, int valueToValidate)
    {
        
        try
        {
            integerValidator.Validate(valueToValidate);
            return true;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        
    }

    /// <summary>
    /// Determines whether the specified integer value can be validated using the provided <see cref="IntegerValidator"/>.
    /// </summary>
    /// <param name="integerValidator">The <see cref="IntegerValidator"/> instance used to validate the integer value.</param>
    /// <param name="valueToValidate">The integer value to be validated.</param>
    /// <returns>
    /// <c>true</c> if the specified integer value can be validated; otherwise, <c>false</c>.
    /// </returns>
    private static bool CanValidateInteger(IntegerValidator integerValidator, int valueToValidate) 
        => integerValidator.CanValidate(valueToValidate.GetType());
}
