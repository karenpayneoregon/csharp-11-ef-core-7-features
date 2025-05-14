namespace ComparableLibrary;

/// <summary>
/// Between and IsBetween are the same, use one, delete the other
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Determines whether the specified value is between the given lower and upper bounds, inclusive.
    /// </summary>
    /// <typeparam name="T">The type of the value, which must be a value type that implements <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to compare.</param>
    /// <param name="lowerValue">The lower bound to compare against.</param>
    /// <param name="upperValue">The upper bound to compare against.</param>
    /// <returns>
    /// <c>true</c> if the value is between the lower and upper bounds, inclusive; otherwise, <c>false</c>.
    /// </returns>
    public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T>
        => Comparer<T>.Default.Compare(value, lowerValue) >= 0 && 
           Comparer<T>.Default.Compare(value, upperValue) <= 0;

    /// <summary>
    /// Determines whether the specified value is between the given lower and upper bounds, inclusive.
    /// </summary>
    /// <typeparam name="T">The type of the value, which must be a value type that implements <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to compare.</param>
    /// <param name="lowerValue">The lower bound to compare against.</param>
    /// <param name="upperValue">The upper bound to compare against.</param>
    /// <returns>
    /// <c>true</c> if the value is between the lower and upper bounds, inclusive; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetween<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T>
        => value.Between(lowerValue, upperValue);

    /// <summary>
    /// Determines whether the specified value is strictly between the given lower and upper bounds.
    /// </summary>
    /// <typeparam name="T">The type of the value, which must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="sender">The value to compare.</param>
    /// <param name="minimumValue">The lower bound to compare against.</param>
    /// <param name="maximumValue">The upper bound to compare against.</param>
    /// <returns>
    /// <c>true</c> if the value is strictly between the lower and upper bounds; otherwise, <c>false</c>.
    /// </returns>
    public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        => sender.CompareTo(minimumValue) > 0 && 
           sender.CompareTo(maximumValue) < 0;

    /// <summary>
    /// Determines whether the specified value is strictly between the given lower and upper bounds.
    /// </summary>
    /// <typeparam name="T">The type of the value, which must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="sender">The value to compare.</param>
    /// <param name="minimumValue">The lower bound to compare against.</param>
    /// <param name="maximumValue">The upper bound to compare against.</param>
    /// <returns>
    /// <c>true</c> if the value is strictly between the lower and upper bounds; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        => sender.BetweenExclusive(minimumValue, maximumValue);


}

