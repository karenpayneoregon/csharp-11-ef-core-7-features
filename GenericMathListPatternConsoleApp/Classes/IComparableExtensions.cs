

namespace GenericMathListPatternConsoleApp.Classes;

public static class IComparableExtensions
{
    public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T>
        => Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;

    public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        => sender.CompareTo(minimumValue) > 0 && sender.CompareTo(maximumValue) < 0;

    public static bool IsGreaterThan<T>(this T sender, T value) where T : IComparable
        => sender.CompareTo(value) > 0;

    public static bool IsLessThan<T>(this T sender, T value) where T : IComparable
        => sender.CompareTo(value) < 0;

    public static string CaseWhen(this int sender)
    {
        return sender switch
        {
            { } value1 and >= 7 and <= 14 => $"I am 7 or above but less than 14: {value1}",
            { } value2 when value2.Between(4, 6) => $"I am between 4 and 6: {value2}",
            { } value3 when (value3.IsLessThan(3)) => $"I am 3 or less: {value3}",
            _ => "I'm old"
        };
    }
}