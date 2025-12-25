using CalendarSqlQuerySample.Classes.SQL;
using CalendarSqlQuerySample.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;


namespace CalendarSqlQuerySample;
internal partial class Program
{
    /// <summary>
    /// This method initializes the application, retrieves holiday data for the current year,
    /// formats it into a table, and displays it in the console.
    /// </summary>
    static async Task Main(string[] args)
    {
        await Setup();

        await using var context = new Context();

        var currentYearHolidays = await Holidays(DateTime.Now.Year);

        var table = CreateTable();

        foreach (var holiday in currentYearHolidays)
        {
            // check if emoji exists for holiday
            var emoji = GetHolidayEmojis().TryGetValue(holiday.Description, out var value) ? 
                $"{holiday.Description} {value}" : 
                holiday.Description;

            table.AddRow(
                holiday.CalendarDate.ToString("yyyy-MM-dd"),
                holiday.DayOfWeekName,
                emoji
            );
        }

        AnsiConsole.Write(table);

        ExitPrompt();
    }

    /// <summary>
    /// Creates and configures a table to display holiday information.
    /// </summary>
    /// <returns>
    /// A <see cref="Table"/> object with predefined columns and styling for displaying holiday data.
    /// </returns>
    private static Table CreateTable()
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.LightCyan1)
            .Alignment(Justify.Center)
            .Title($"[yellow]Holidays for {DateTime.Now.Year}[/]");

        // Define columns
        table.AddColumn("[b]Date[/]");
        table.AddColumn("[b]Day[/]");
        table.AddColumn("[b]Holiday[/]");
        return table;
    }

    /// <summary>
    /// Retrieves a read-only dictionary mapping holiday descriptions to their corresponding emoji representations.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlyDictionary{TKey, TValue}"/> where the key is the holiday description 
    /// and the value is the associated emoji.
    /// </returns>
    private static ReadOnlyDictionary<string, string> GetHolidayEmojis()
    {
        var dict = new Dictionary<string, string>
        {
            { "Christmas Day", ":santa_claus:" },
            { "Easter", ":sunflower:" },
            { "Independence Day", ":statue_of_liberty:" },
            { "Thanksgiving", ":rooster:" },
            { "President's Day", ":person_in_tuxedo:" },
            { "New Year's Day", ":clinking_glasses:" }
        };
        
        return new ReadOnlyDictionary<string, string>(dict);
    }

    /// <summary>
    /// Retrieves a list of holidays for the specified year from the database.
    /// </summary>
    /// <param name="year">The year for which to retrieve holiday data.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a read-only list of 
    /// <see cref="Holiday"/> objects representing the holidays for the specified year.
    /// </returns>
    /// <remarks>
    /// This method uses an SQL query to fetch holiday data from the database.
    /// Ensure that the database connection is properly configured before calling this method.
    /// </remarks>
    private static async Task<IReadOnlyList<Holiday>> Holidays(int year)
    {
        await using var context = new Context();
        return [.. context.Database.SqlQuery<Holiday>(SqlStatements.GetHolidays(year))];
    }
}