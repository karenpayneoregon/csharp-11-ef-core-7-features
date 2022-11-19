

namespace GenericMathLibrary;

public static class IComparableExtensions
{
    public static bool Between<T>(this T value, T lowerValue, T upperValue)
        where T : struct, IComparable<T>
        => Comparer<T>.Default.Compare(value, lowerValue) >= 0 &&
           Comparer<T>.Default.Compare(value, upperValue) <= 0;

    public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        => sender.CompareTo(minimumValue) > 0 && sender.CompareTo(maximumValue) < 0;

    public static bool IsGreaterThan<T>(this T sender, T value) where T : IComparable
        => sender.CompareTo(value) > 0;

    public static bool IsLessThan<T>(this T sender, T value) where T : IComparable
        => sender.CompareTo(value) < 0;
}