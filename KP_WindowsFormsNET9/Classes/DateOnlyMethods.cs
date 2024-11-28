using System.Runtime.CompilerServices;

namespace KP_WindowsFormsNET9.Classes;

public static class DateOnlyMethods
{
    [OverloadResolutionPriority(2)]
    public static List<DateOnly> GetMonthDays(int month, int year) =>
        Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateOnly(year, month, day))
            .ToList();

    [OverloadResolutionPriority(-1)]
    public static List<DateOnly> GetMonthDays(int month) =>
        Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, month))
            .Select(day => new DateOnly(DateTime.Now.Year, month, day))
            .ToList();
}