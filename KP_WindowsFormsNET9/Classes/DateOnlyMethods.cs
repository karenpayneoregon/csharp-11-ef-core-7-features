using System.Runtime.CompilerServices;

namespace KP_WindowsFormsNET9.Classes;

/// <summary>
/// Provides utility methods for working with <see cref="DateOnly"/> objects, 
/// including retrieving days of a specific month and year.
/// </summary>
/// <remarks>
/// This class includes methods with the <see cref="OverloadResolutionPriorityAttribute"/> applied. 
/// The <see cref="OverloadResolutionPriorityAttribute"/> is used to influence the method overload resolution process.
/// Higher priority values indicate a higher preference during overload resolution.
/// </remarks>
public static class DateOnlyMethods
{
    /// <summary>
    /// Retrieves a list of all days in the specified month and year.
    /// </summary>
    /// <param name="month">The month for which to retrieve the days (1 through 12).</param>
    /// <param name="year">The year for which to retrieve the days.</param>
    /// <returns>A list of <see cref="DateOnly"/> objects representing each day in the specified month and year.</returns>
    [OverloadResolutionPriority(2)]
    public static List<DateOnly> GetMonthDays(int month, int year) =>
        Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateOnly(year, month, day))
            .ToList();
    /// <summary>
    /// Retrieves a list of all days in the specified month of the current year.
    /// </summary>
    /// <param name="month">The month for which to retrieve the days (1 through 12).</param>
    /// <returns>A list of <see cref="DateOnly"/> objects representing each day in the specified month of the current year.</returns>
    [OverloadResolutionPriority(-1)]
    public static List<DateOnly> GetMonthDays(int month) =>
        Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, month))
            .Select(day => new DateOnly(DateTime.Now.Year, month, day))
            .ToList();
}