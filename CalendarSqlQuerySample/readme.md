# About

Provides a basic example for EF Core [Raw SQL queries for unmapped types](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#raw-sql-queries-for-unmapped-types).

##  Article

https://dev.to/karenpayneoregon/ef-core-queries-for-unmapped-types-20o3

## SQL Statement

```sql
internal class SqlStatements
{
    public static FormattableString GetHolidaysByMonth(int year) => 
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
```

## Code


```csharp
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await using var context = new Context();

        int year = DateTime.Now.Year;
        var list = await context.Database.SqlQuery<Holiday>(SqlStatements.GetHolidaysByMonth(year)).ToListAsync();
        AnsiConsole.MarkupLine(ObjectDumper.Dump(list).Replace("{Holiday}", "[yellow]{[/][lightskyblue3]Holiday[/][yellow]}[/]"));

        ExitPrompt();
    }
}    
```