using System.Globalization;
using System.Numerics;

#pragma warning disable CS8619

namespace GenericMathListPatternConsoleApp.Classes;

public static class GenericExtensions
{

    /// <summary>
    /// Convert all values in array to int array where non int values will be set to the default value.
    /// </summary>
    /// <param name="sender">string array</param>
    /// <returns>All elements in array as int</returns>
    public static T[] ToNumbersPreserveArray<T>(this string[] sender) where T : INumber<T>
    {

        var array = Array.ConvertAll(sender, (input) =>
        {
            T.TryParse(input, NumberStyles.Any | NumberStyles.AllowDecimalPoint | NumberStyles.Float, CultureInfo.CurrentCulture, out var integerValue);
            return integerValue;
        });

        return array;

    }

    /// <summary>
    ///  Example of how the we would write to get numbers before generic math, now we have <see cref="ToNumbersPreserveArray"/> above
    /// </summary>
    public static double[] ToDoublePreserveArray(this string[] sender)
    {

        var doubleArray = Array.ConvertAll(sender, (input) =>
        {
            double.TryParse(input, out var doubleValue);
            return doubleValue;
        });
        
        return doubleArray;

    }

    public static decimal[] ToDecimalPreserveArray(this string[] sender)
    {

        var decimalArray = Array.ConvertAll(sender, (input) =>
        {
            decimal.TryParse(input, out var decimalValue);
            return decimalValue;
        });

        return decimalArray;

    }


    public static int[] ToIntPreserveArray(this string[] sender)
    {

        var intArray = Array.ConvertAll(sender, (input) =>
        {
            int.TryParse(input, out var intValue);
            return intValue;
        });

        return intArray;

    }

    /// <summary>
    /// Convert string array to an array of <typeparam name="T"></typeparam>
    /// </summary>
    /// <typeparam name="T">convert to</typeparam>
    /// <param name="sender">source array</param>
    /// <returns>converted array</returns>
    public static T[] ToNumberArray<T>(this string[] sender) where T : INumber<T> =>
        Array
            .ConvertAll(sender,
                (input) => new
                {
                    IsNumber = T.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var value),
                    Value = value})
            .Where(result => result.IsNumber)
            .Select(result => result.Value)
            .ToArray();

    /// <summary>
    /// Get non numeric value indices
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="sender">string array</param>
    /// <returns>array of indices if there are any non-numeric values</returns>
    public static int[] GetNonNumericIndexes<T>(this string[] sender) where T : INumber<T> =>
        sender.Select(
                (item, index) => T.TryParse(item, NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out var _) ?
                    new { IsNumber = true, Index = index } :
                    new { IsNumber = false, Index = index })
            .ToArray()
            .Where(item => item.IsNumber == false)
            .Select(item => item.Index).ToArray();
 
}