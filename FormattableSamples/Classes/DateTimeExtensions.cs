namespace FormattableSamples.Classes;
public static class DateTimeExtensions
{
    /// <summary>
    /// Gets the weekend dates (Saturday and Sunday) for the specified date.
    /// </summary>
    /// <param name="date">The date for which to get the weekend dates.</param>
    /// <param name="startOfWeek">The start day of the week. Default is Sunday.</param>
    /// <returns>A tuple containing the DateOnly representation of the Saturday and Sunday dates.</returns>
    public static (DateOnly saturday, DateOnly sunday) GetWeekendDates(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Sunday)
    {
        var weekStart = date.AddDays(-(int)date.DayOfWeek + (int)startOfWeek);

        var saturday = weekStart.AddDays(5);
        var sunday = weekStart.AddDays(6);

        return (DateOnly.FromDateTime(saturday), DateOnly.FromDateTime(sunday));

    }
}