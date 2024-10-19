namespace IComparableApp.Classes.Extensions;
public static class GeneralExamples
{
    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value falls within the range defined by the start and end dates.
    /// </summary>
    /// <param name="dt">The date to check.</param>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <returns>
    /// <c>true</c> if the date is between the start and end dates; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetweenTwoDates(this DateTime dt, DateTime start, DateTime end)
    {
        return dt.Ticks > start.Ticks && dt.Ticks < end.Ticks;
    }

    /// <summary>
    /// Determines whether the specified integer value falls within the range defined by the start and end values of the given range.
    /// </summary>
    /// <param name="range">The range that defines the start and end values.</param>
    /// <param name="value">The integer value to check.</param>
    /// <returns>
    /// <c>true</c> if the integer value is between the start and end values of the range; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetweenTwoInt(this Range range, int value) 
        => range.Start.Value <= value && value < range.End.Value;

    /// <summary>
    /// Determines whether the specified <see cref="DateOnly"/> value falls within the range defined by the start and end dates.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>
    /// <c>true</c> if the date is between the start and end dates; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetweenTwoDateOnly(this DateOnly date, DateOnly startDate, DateOnly endDate)
    {
        return date >= startDate && date <= endDate;
    }
    /// <summary>
    /// Determines whether a specified character value falls within the range defined by the start and end values of the given range.
    /// </summary>
    /// <param name="range">The range that defines the start and end values.</param>
    /// <param name="value">The character value to check.</param>
    /// <returns>
    /// <c>true</c> if the character value is between the start and end values of the range; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetweenTwoChar(this Range range, char value)
        => range.Start.Value <= value && value < range.End.Value;
}
