﻿using System.Globalization;
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

    /// <summary>
    /// Clamps a value to a specified range defined by a minimum and maximum value.
    /// </summary>
    /// <typeparam name="T">
    /// The numeric type of the value, minimum, and maximum. Must implement <see cref="System.Numerics.INumber{T}"/>.
    /// </typeparam>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>
    /// <returns>
    /// The clamped value, which will be equal to <paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>, 
    /// or <paramref name="max"/> if <paramref name="value"/> is greater than <paramref name="max"/>. 
    /// Otherwise, it will return <paramref name="value"/>.
    /// </returns>
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> 
        => T.Clamp(value, min, max);

    /// <summary>Computes the absolute of a value.</summary>
    public static T Abs<T>(this T left, T right) where T : INumber<T> => 
        T.Abs(left);

    /// <summary>
    /// Compares two values to determine the lesser value, returning the other value if one is <c>NaN</c>.
    /// </summary>
    /// <typeparam name="T">
    /// A numeric type implementing <see cref="System.Numerics.INumber{T}"/>.
    /// </typeparam>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <returns>The lesser value, or the other if one is <c>NaN</c>.</returns>
    public static T GetMinNumber<T>(this T a, T b) where T : INumber<T>
        => T.MinNumber(a, b);

    /// <summary>
    /// Returns the greater of two values, or the other value if one is <c>NaN</c>.
    /// </summary>
    /// <typeparam name="T">
    /// A numeric type implementing <see cref="System.Numerics.INumber{T}"/>.
    /// </typeparam>
    /// <param name="a">The first value.</param>
    /// <param name="b">The second value.</param>
    /// <returns>The greater value, or the other if one is <c>NaN</c>.</returns>
    public static T GetMaxNumber<T>(this T a, T b) where T : INumber<T> 
        => T.MaxNumber(a, b);

    /// <summary>
    /// Negates the specified numeric value, effectively flipping its sign.
    /// </summary>
    /// <typeparam name="T">The numeric type of the value, constrained to implement <see cref="System.Numerics.INumber{T}"/>.</typeparam>
    /// <param name="source">The numeric value to be inverted.</param>
    /// <returns>The negated value of <paramref name="source"/>.</returns>
    public static T Invert<T>(this T source) where T : INumber<T> 
        => -source;

    /// <summary>
    /// Rounds the specified floating-point value to a given number of decimal places.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the floating-point value. Must implement <see cref="IFloatingPoint{T}"/>.
    /// </typeparam>
    /// <param name="sender">The floating-point value to round.</param>
    /// <param name="decimalPlaces">The number of decimal places to round to.</param>
    /// <returns>The rounded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="decimalPlaces"/> is negative.
    /// </exception>
    public static T Round<T>(this T sender, int decimalPlaces) where T : IFloatingPoint<T>
        => T.Round(sender, decimalPlaces);

    /// <summary>
    /// Merges two arrays into a single array by concatenating the elements of the second array
    /// to the end of the first array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the arrays, constrained to numeric types.</typeparam>
    /// <param name="front">The first array to merge.</param>
    /// <param name="back">The second array to merge.</param>
    /// <returns>A new array containing all elements from both input arrays.</returns>
    public static T[] Merge<T>(this T[] front, T[] back) where T : INumber<T>
        => front.Concat(back).ToArray();

    // NET8 version of Merge above
    // public static T[] Merge2<T>(this T[] front, T[] back) where T : INumber<T> => [.. front, .. back];

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
    ///  Example of how we would write to get numbers before generic math
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
    //public static int[] GetNonNumericIndexes<T>(this string[] sender) where T : INumber<T> =>
    //    sender.Select(
    //            (item, index) => T.TryParse(item, NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out _) ?
    //                new { IsNumber = true, Index = index } :
    //                new { IsNumber = false, Index = index })
    //        .ToArray()
    //        .Where(item => item.IsNumber == false)
    //        .Select(item => item.Index).ToArray();
    public static int[] GetNonNumericIndexes<T>(this string[] sender) where T : INumber<T>
    {
        int count = 0;
        int length = sender.Length;
        // First pass: count non-numeric values
        for (int i = 0; i < length; i++)
        {
            if (T.TryParse(sender[i], NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture,
                    out _)) continue;
            count++;
        }
        // Allocate array of the required size
        int[] indexes = new int[count];
        int index = 0;
        // Second pass: fill the array with indices
        for (int i = 0; i < length; i++)
        {
            if (T.TryParse(sender[i], NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture,
                    out _)) continue;
            indexes[index++] = i;
        }
        return indexes;
    }

    /// <summary>
    /// Add ellipsis-es to the end of type and convert to a string
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