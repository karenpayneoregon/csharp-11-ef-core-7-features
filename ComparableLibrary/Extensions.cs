namespace ComparableLibrary;
public static class Extensions
{
    public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T>
        => Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;
    public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        => sender.CompareTo(minimumValue) > 0 && sender.CompareTo(maximumValue) < 0;
    public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0) return min;
        if (value.CompareTo(max) > 0) return max;

        return value;
    }
}
