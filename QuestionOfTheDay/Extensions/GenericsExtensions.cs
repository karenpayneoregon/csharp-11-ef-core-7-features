using System.Numerics;

namespace QuestionOfTheDay.Extensions;


public static partial class GenericsExtensions
{
    public static int FractionalNumber<T>(this T sender) where T : INumber<T>
    {
        int value = (int)(decimal.CreateChecked(sender) % 1 * 100);
        return int.IsNegative(value) ? value.Invert() : value;
    }

    public static int FractionalFromFloats<T>(this T sender) where T : IFloatingPoint<T>
    {
        int value = (int)(decimal.CreateChecked(sender) % 1 * 100);
        return int.IsNegative(value) ? value.Invert() : value;
    }

    public static T Invert<T>(this T source) where T : INumber<T>
        => -source;

    public static double GetPercentage<T>(this T sender, int percentage) where T : IFloatingPoint<T> 
        => (double)(decimal.CreateChecked(sender) * percentage / 100);
}


