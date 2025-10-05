using System.Configuration;
using System.Diagnostics;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace NativeValidatorsSamples.Classes;
internal partial class Examples
{
    public static void TimeSpanValidator()
    {
        TimeSpan testTimeSpan = new(0, 1, 05);
        TimeSpan minTimeSpan = new(0, 1, 0);
        TimeSpan maxTimeSpan = new(0, 1, 10);
        
        TimeSpanValidator theTimeSpanValidator = new(minTimeSpan, maxTimeSpan, false, 65);

        // Determine if the object to validate can be validated.
        Debug.WriteLine($"CanValidate: {theTimeSpanValidator.CanValidate(testTimeSpan.GetType())}");

        try
        {
            // Attempt validation.
            theTimeSpanValidator.Validate(testTimeSpan);
            Debug.WriteLine("Validated.");
        }
        catch (ArgumentException e)
        {
            // Validation failed.
            Debug.WriteLine($"Error: {e.Message}");
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public static void IntegerValidator()
    {
        int minIntVal = 1;
        int maxIntVal = 10;
        
        bool exclusive = false;
        
        IntegerValidator integerValidator = new(minIntVal, maxIntVal, exclusive);

        int testInt = 0;

        if (CanValidateInteger(integerValidator, testInt))
        {
            // throw an exception
            ValidateInteger(integerValidator, testInt);

            if (testInt.IsValid(minIntVal, maxIntVal))
            {
                Debug.WriteLine("\tValid");
            } else
            {
                Debug.WriteLine("\tInvalid");
            }
        }
        
        testInt = 1;
        ValidateInteger(integerValidator, testInt);
        testInt = 5;
        ValidateInteger(integerValidator, testInt);

        exclusive = true;
        integerValidator = new(minIntVal, maxIntVal, exclusive);

        testInt = 0;
        ValidateInteger(integerValidator, testInt);
        testInt = 1;
        ValidateInteger(integerValidator, testInt);
        testInt = 5;
        ValidateInteger(integerValidator, testInt);

        object testObjectToValidate = "a";
        Debug.WriteLine($"Can validate object of type {testObjectToValidate.GetType()}: {integerValidator.CanValidate(testObjectToValidate.GetType())}");
        testObjectToValidate = new int();
        Debug.WriteLine($"Can validate object of type {testObjectToValidate.GetType()}: {integerValidator.CanValidate(testObjectToValidate.GetType())}");
    }


}
