using System.Globalization;
using System.Runtime.CompilerServices;
using FormattableSamples.Models;
using static FormattableSamples.Classes.SpectreConsoleHelpers;
using static FormattableSamples.Classes.UtilityExtensions;
using static System.FormattableString;

namespace FormattableSamples.Classes;
internal class Samples
{
    /// <summary>
    /// - Format a list in a specific format
    /// - Reference items in the FormattableString using extension methods and enums for positions 
    /// </summary>
    public static void CreateAndViewPeople()
    {

        PrintCyan();

        var list = SimulateFromDatabase();
        
        var items = list.Select(p => 
            FormattableStringFactory.Create("[lightslateblue]Id[/]: {0,-4} [lightslateblue]First[/]: " +
                                            "{1,-8} [lightslateblue]Last[/]: {2,-8} [lightslateblue]BirthDate:[/] {3}", 
                p.Id, p.FirstName, p.LastName, p.BirthDate));

        AnsiConsole.MarkupLine("[yellow]Dissect[/]");
        /*
         * Extract the properties from the FormattableString
         */
        foreach (var item in items)
        {
            Console.WriteLine($"    {item.FirstName(),-8}{item.LastName(),-8}{item.BirthDate()}");
        }

        AnsiConsole.MarkupLine("[yellow]Raw[/]");
        /*
         * Show as defined in original creation
         */
        foreach (var item in items)
        {
            AnsiConsole.MarkupLine($"    {item}");
        }

        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]Find by last name, get first name[/]");
        Console.WriteLine($"    {items.FirstOrDefault(x => x.LastName() == "Smith").FirstName()}");

        Console.WriteLine();
    }
    private static List<Person> SimulateFromDatabase()
    {
        List<Person> list =
        [
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new(1962, 12, 7) },
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new(1972, 1, 15) },
            new() { Id = 3, FirstName = "Lucy", LastName = "Adams", BirthDate = new(1982, 2, 25) }
        ];
        return list;
    }

    public static void UpdateProperties()
    {

        PrintCyan();

        Person person = new()
        {
            Id = 1, 
            FirstName = "Karen",
            LastName = "Payne", 
            BirthDate = new DateOnly(1956,9,24)
        };
        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2} Birth {3}",
            person.Id, person.FirstName, person.LastName, person.BirthDate);
        
        AnsiConsole.MarkupLine($"[cyan]Format[/]      : {format.Format}");
        AnsiConsole.MarkupLine($"[cyan]# Arguments[/] : {format.ArgumentCount}");

        AnsiConsole.MarkupLine("[yellow]Original[/]");
        // join the arguments with a comma
        Console.WriteLine($"    {format.ArgumentsJoined()}");

        format.UpdateFirstName("Anne");
        AnsiConsole.MarkupLine("[yellow]Updated[/]");
        // join the arguments with a space (could also overload ArgumentsJoined)
        Console.WriteLine($"    {format.ItemsCombined()}");

        Console.WriteLine();
    }

    public static void UpdatePerson()
    {
        Person person = new()
        {
            Id = 1,
            FirstName = "Karen",
            LastName = "Payne",
            BirthDate = new DateOnly(1956, 9, 24)
        };

        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2} Birth {3}",
            person.Id, person.FirstName, person.LastName, person.BirthDate);

        if (format.FirstName() == "Karen")
        {
            format.UpdateFirstName("Anne");
        }
        

    }

    public static string CreateTemplate(string name, string team, string position) =>
        FormattableStringFactory
            .Create("""
                    My name is {0}
                    and I am working in the
                    {1}
                    team\\n as a {2}
                    """, 
                name,
                team, 
                position).ToString();

    public static void TheWeekend()
    {

        PrintCyan();

        var name = "Karen";
        var (saturday, sunday) = DateTime.Now.GetWeekendDates();
        FormattableString template = FormattableStringFactory
            .Create("{0} [green]{1}[/], this weekend dates are [lightslateblue]{2} {3}[/]",
                Greetings.TimeOfDay(), name, saturday, sunday);

        AnsiConsole.MarkupLine($"{template}");

        foreach (var item in template.GetArguments())
        {
            if (item is DateOnly date)
            {
                Console.WriteLine($"    {date}");
            }
        }

        Console.WriteLine();

    }

    public static void TheWeekend1()
    {
        PrintCyan();

        var name = "Karen";
        var (saturday, sunday) = DateTime.Now.GetWeekendDates();
        FormattableString template = 
            $"{Greetings.TimeOfDay()} [green]{name}[/], this weekend dates are [lightslateblue]{saturday} {sunday}[/]";

        AnsiConsole.MarkupLine($"{template}");

        foreach (var item in template.GetArguments())
        {
            if (item is DateOnly date)
            {
                Console.WriteLine($"    {date}");
            }
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Using a FormattableString which represents a INSERT INTO SQL statement,
    /// break apart the statement and parameters
    /// </summary>
    /// <remarks>
    /// For demonstration only, not to be used in a real project scope_identity()
    /// </remarks>
    public static void SqlStatementExample()
    {

        PrintCyan();

        var sql = InsertStatementExample1("Karen", "Payne", new DateOnly(1960, 12, 25));
        var (sqlFormat, parameters) = sql.ToParameters(DatabaseType.SqlServer);
        AnsiConsole.MarkupLine(StatementColors(sqlFormat));
        AnsiConsole.MarkupLine("[yellow]Parameters[/]");
        foreach (KeyValuePair<string, object> kp in parameters)
        {
            var (parameterName, parameterValue) = kp.Deconstruct();
            AnsiConsole.MarkupLine($"    [b]{parameterName,-8}[/][lightslateblue]{parameterValue}[/]");
        }

        Console.WriteLine();

    }
    private static FormattableString InsertStatementExample1(string firstName, string lastName, DateOnly birthDate) =>
        $"""
         INSERT INTO dbo.Person
         (
             FirstName,
             LastName,
             BirthDate
         )
         VALUES
         ({firstName}, {lastName}, {birthDate});
         SELECT CAST(scope_identity() AS int);
         """;

    public static void DateTimeCulture()
    {

        PrintCyan();

        var uk = CultureInfo.CreateSpecificCulture("en-GB");
        Thread.CurrentThread.CurrentCulture = uk;

        var germany = CultureInfo.CreateSpecificCulture("de-DE");
        string now = $"[cyan]Default: it is now[/] [yellow]{DateTime.UtcNow}[/]";
        AnsiConsole.MarkupLine($"[yellow]UK[/]: {now}");

        IFormattable first = $"[cyan]Specific: It is now[/] [yellow]{DateTime.UtcNow}[/]";
        AnsiConsole.MarkupLine($"[yellow]Germany[/]: {first.ToString("ignored", germany)}");
        FormattableString second = $"FormattableString: It is now {DateTime.UtcNow}";
        Console.WriteLine(FormattableString.Invariant(second));
        
        // Via using static
        Console.WriteLine(Invariant($"It is now {DateTime.UtcNow}"));

        Console.WriteLine();

    }

    public static void VersionFormat()
    {

        PrintCyan();

        Version version = new(1, 2, 3, 4);
        FormattableString template = FormatVersion(version);
        //AnsiConsole.MarkupLine($"[white on blue]{template}[/]");

        DeconstructVersion(template);

        Console.WriteLine();
    }


    public static void DeconstructVersion(FormattableString sender)
    {
        AnsiConsole.MarkupLine(
            $"[yellow]Major[/] {sender.Major()} " +
            $"[yellow]Major[/] {sender.Minor()} " +
            $"[yellow]Build[/] {sender.Build()} " +
            $"[yellow]Revision[/] {sender.Revision()}");
    }

    public static FormattableString FormatVersion(Version version) =>
        FormattableStringFactory.Create("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
}
