using CalendarSqlQuerySample.Classes;
using CalendarSqlQuerySample.Data;
using Microsoft.EntityFrameworkCore;


namespace CalendarSqlQuerySample;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        
        await using var context = new Context();

        int year = DateTime.Now.Year;

        var currentYear = await Holidays(year);

        AnsiConsole.MarkupLine(ObjectDumper.Dump(currentYear).HolidayColors());

        ExitPrompt();
    }

    static async Task<IReadOnlyList<Holiday>> Holidays(int year)
    {
        await using var context = new Context();
        return [.. context.Database.SqlQuery<Holiday>(SqlStatements.GetHolidays(year))];
    }
}    