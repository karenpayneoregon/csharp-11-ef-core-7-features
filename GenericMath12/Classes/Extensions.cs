using System.Globalization;
using System.Numerics;
namespace GenericMath12.Classes;


public static class Extensions
{
    /// <summary>
    /// Truncate to the specified number of decimal places.
    /// </summary>
    /// <param name="value">value to truncate</param>
    /// <param name="places">decimal places</param>
    /// <returns></returns>
    public static double Truncate(this double value, int places = 2)
    {
        var factor = Math.Pow(10, places);
        return Math.Truncate(value * factor) / factor;
    }

    /// <summary>
    /// Truncate to the specified number of decimal places.
    /// </summary>
    /// <param name="value">value to truncate</param>
    /// <param name="places">decimal places</param>
    public static decimal Truncate(this decimal value, int places = 2)
    {
        var factor = (decimal)Math.Pow(10, places);
        decimal result = Math.Truncate(factor * value) / factor;
        return result;
    }

    /// <summary>
    /// Get the fractional part of a number as a decimal.
    /// </summary>
    /// <typeparam name="T">number type</typeparam>
    /// <param name="sender">value</param>
    /// <param name="places">decimal places</param>
    public static decimal GetFractionalPart<T>(this T sender, int places) where T : INumber<T>
        => Math.Round(decimal.CreateChecked(sender) - Math.Truncate(decimal.CreateChecked(sender)), places);

    /// <summary>
    /// Get the fractional part of a number as an int.
    /// </summary>
    /// <typeparam name="T">number type</typeparam>
    /// <param name="sender">value</param>
    /// <param name="places">decimal places</param>
    public static int GetFractionalPartInt<T>(this T sender, int places = 2) where T : INumber<T>
    {
        var value = Convert.ToInt32((decimal.CreateChecked(sender) % 1).ToString(CultureInfo.InvariantCulture).Replace("0.", ""));
        var value1 = value.ToString();
        if (places < value1.Length)
        {
            value = Convert.ToInt32(value1[..places]);
        }
        return int.IsNegative(value) ? value.Invert() : value;
    }

    public static T Invert<T>(this T source) where T : INumber<T>
        => -source;

    /// <summary>
    /// Lazy way to convert a number to currency string.
    /// </summary>
    /// <typeparam name="T">number type</typeparam>
    /// <param name="sender">value</param>
    /// <param name="places">decimal places</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If not decimal or double</exception>
    public static string ToCurrency<T>(this T sender, int places = 2) where T : INumber<T> => sender switch
    {
        decimal => decimal.CreateChecked(sender).ToString($"C{places}"),
        double => double.CreateChecked(sender).ToString($"C{places}"),
        _ => throw new ArgumentException("Invalid type")
    };
}
