using FormattableStringsSamplesApp.Data;
using FormattableStringsSamplesApp.Models;
using Microsoft.EntityFrameworkCore;
using static FormattableStringsSamplesApp.Classes.SpectreConsoleHelpers;

namespace FormattableStringsSamplesApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        MultiUseToStringSample();

        await EntityFrameworkCoreStoredProcedureSample();

        ExitPrompt();
    }

    private static void EntityFrameworkCoreSample()
    {
        PrintCyan();
        using var context = new Context();
        var holidays = context.Calendar.FromSql(GetHolidaysStatement).ToList();
        if (holidays.Any())
        {
            foreach (var holiday in holidays)
            {
                Console.WriteLine($"{holiday.CalendarDate,-12}{holiday.DayOfWeekName,-12}{holiday.Description}");
            }
        }
        else
        {
            Console.WriteLine("No holidays found");
        }
    }

    /// <summary>
    /// Executes the Entity Framework Core stored procedure sample.
    /// </summary>
    /// <remarks>
    /// This method calls the stored procedure <c>usp_HolidaysForMonthYearAsync</c> on the <c>Procedures</c>
    /// property of the <c>Context</c> object.
    /// It retrieves a list of holidays for the current month and year and prints the holiday information to the console.
    /// </remarks>
    private static async Task EntityFrameworkCoreStoredProcedureSample()
    {
        PrintCyan();
        await using var context = new Context();
        List<usp_HolidaysForMonthYearResult> holidays = await context.Procedures.usp_HolidaysForMonthYearAsync();
        if (holidays.Any())
        {
            foreach (var holiday in holidays)
            {
                Console.WriteLine($"{holiday.CalendarDate,-12}{holiday.DayOfWeekName,-12}{holiday.Description}");
            }
        }
        else
        {
            Console.WriteLine("No holidays found");
        }
    }

    private static FormattableString GetHolidaysStatement =>
        $"""
         SELECT CalendarDate,
                CalendarYear,
                CalendarDay,
                CalendarMonth,
                DayOfWeekName,
                FirstDateOfWeek,
                LastDateOfWeek,
                FirstDateOfMonth,
                LastDateOfMonth,
                FirstDateOfQuarter,
                LastDateOfQuarter,
                FirstDateOfYear,
                LastDateOfYear,
                BusinessDay,
                NonBusinessDay,  
                Holiday,     
                Weekday,
                Weekend,
                CalendarDateDescription
         FROM dbo.Calendar
         WHERE CalendarMonth = MONTH(GETDATE())
         AND CalendarYear = CAST(YEAR(GETDATE()) AS INT)
         AND Holiday = 1;
         """;
    private static void MultiUseToStringSample()
    {
        PrintCyan();

        var temperature = new TemperatureFormat(20.0);
        var formattedKelvins = $"Temperature: {temperature:K}";
        Console.WriteLine(formattedKelvins);
        var formattedFahrenheit = $"Temperature: {temperature:F}";
        Console.WriteLine(formattedFahrenheit);
        var formattedCelsius = $"Temperature: {temperature}";
        Console.WriteLine(formattedCelsius);
    }
}