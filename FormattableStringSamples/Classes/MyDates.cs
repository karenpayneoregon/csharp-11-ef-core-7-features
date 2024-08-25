using System;

public static class MyDates
{
    public static (DateTime saturday, DateTime sunday) GetWeekendDates()
    {
        var today = DateTime.Today;
        var currentDayOfWeek = today.DayOfWeek;
        return (
            today.AddDays(((int)DayOfWeek.Saturday - (int)currentDayOfWeek + 7) % 7),
            today.AddDays(((int)DayOfWeek.Sunday - (int)currentDayOfWeek + 7) % 7)
        );
    }
}
