namespace CalendarSqlQuerySample.Classes;
internal class SqlStatements
{

    /// <summary>
    /// Retrieves holidays for a given year.
    /// </summary>
    /// <param name="year">The year for which to retrieve holidays.</param>
    /// <returns>A <see cref="FormattableString"/> representing the SQL query to retrieve holidays for EF Core.</returns>
    public static FormattableString GetHolidays(int year) => 
        $"""
         SELECT CalendarDate,
               CalendarDateDescription AS [Description],
               CalendarMonth,
               DATENAME(MONTH, DATEADD(MONTH, CalendarMonth, -1)) AS [Month],
               CalendarDay AS [Day],
               DayOfWeekName,
               IIF(BusinessDay = 0, 'No', 'Yes') AS BusinessDay,
               IIF(Weekday = 0, 'No', 'Yes') AS [Weekday]
          FROM DateTimeDatabase.dbo.Calendar
         WHERE CalendarYear = {year}
           AND Holiday      = 1;
         """;
}
