namespace PatternMatchingApp1.Classes;

public static class DateOnlyMethods
{

    public static List<DateOnly> GetMonthDays(int month, int year) =>
        Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateOnly(year, month, day))
            .ToList();
}