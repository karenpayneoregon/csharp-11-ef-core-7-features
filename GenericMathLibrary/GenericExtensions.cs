using System.Globalization;
using System.Numerics;

#pragma warning disable CS8619

namespace GenericMathLibrary;

public static class GenericExtensions
{

    /// <summary>Determines if a value represents an even integral value.</summary>
    public static bool IsEven<T>(this T sender) where T : INumber<T> 
        => T.IsEvenInteger(sender);

    /// <summary>Determines if a value represents an odd integral value.</summary>
    public static bool IsOdd<T>(this T sender) where T : INumber<T>
        => T.IsOddInteger(sender);

    public static bool IsPositive<T>(this T sender) where T : INumber<T>
        => T.IsPositive(sender);

    public static bool IsNegative<T>(this T sender) where T : INumber<T>
        => T.IsNegative(sender);

    /// <summary> Increment by 1 </summary>
    public static T Increment<T>(this T sender) where T : INumber<T>
        => sender + T.One;

    /// <summary> Increment by <param name="value"></param> </summary>
    public static T Increment<T>(this T sender, T value) where T : INumber<T>
        => sender + value;

    /// <summary> Decrement by 1 </summary>
    public static T Decrement<T>(this T sender) where T : INumber<T> 
        => sender - T.One;

    /// <summary> Decrement by <param name="value"></param> </summary>
    public static T Decrement<T>(this T sender, T value) where T : INumber<T>
        => sender - value;
    public static T Add<T>(this T  left, T right) where T : INumber<T> 
        => left + right;

    /// <summary>Add two values.</summary>
    public static T Add<T>(this T left, T right, ref T value) where T : INumber<T>
    {
        return value =  left + right;
    }

    /// <summary>Add elements in an array</summary>
    public static T AddAll<T>(this T[] sender) where T : INumber<T>
    {
        T result = T.Zero;
        foreach (T item in sender) { result += item; }
        return result;
    }

    public static T Subtract<T>(this T  left, T right) where T : INumber<T> 
        => left - right;

    /// <summary>Computes the absolute of a value.</summary>
    public static T Abs<T>(this T left, T right) where T : INumber<T> => 
        T.Abs(left);

    /// <summary>Compares two values to compute which is lesser and returning the other value if an input is <c>NaN</c>.</summary>
    public static T GetMinNumber<T>(this T a, T b) where T : INumber<T>
        => T.MinNumber(a, b);

    /// <summary>Compares two values to compute which is greater and returning the other value if an input is <c>NaN</c>.</summary>
    public static T GetMaxNumber<T>(this T a, T b) where T : INumber<T> 
        => T.MaxNumber(a, b);

    /// <summary>Clamps a value to an inclusive minimum and maximum value.</summary>
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> 
        => T.Clamp(value, min, max);

    /// <summary> Flip negative to positive or positive to negative </summary>
    public static T Invert<T>(this T source) where T : INumber<T> 
        => -source;

    public static T Round<T>(this T sender, int decimalPlaces) where T : IFloatingPoint<T>
        => T.Round(sender, decimalPlaces);

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

    /// <summary>
    /// Add ellipsis-es to the end of a int and convert to a string
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="sender">Type of <see cref="T"/></param>
    /// <param name="width">Width to pad</param>
    /// <param name="paddingChar">Character to pad with, defaults to a period</param>
    /// <returns>Padded string</returns>
    public static string Ellipsis<T>(this T sender, int width, char paddingChar = '.') where T : INumber<T>
    {
        return sender.ToString().Ellipsis(width, paddingChar);
    }
    public static string Ellipsis<T>(this T? sender, int width, char paddingChar = '.') where T : struct
    {
        if (sender is not null)
        {
            return sender.ToString().Ellipsis(width, paddingChar);
        }
        else
        {
            return "".Ellipsis(width, paddingChar);
        }

    }
}