using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormattableStringApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[cyan]Person[/]");
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2}",
            person.Id, person.FirstName, person.LastName);

        FormatPerson(format);
        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]Change table name[/]");
        SqlStatementExample();
        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]SQL Insert parameters[/]");
        var sql = InsertStatementExample1("Karen", "Payne", new DateOnly(1960, 12, 25));
        var (sqlFormat, parameter) = sql.ToParameter(DatabaseType.SqlServer);
        Console.WriteLine(sqlFormat);


        Console.ReadLine();
    }

    private static void FormatPerson(FormattableString sender)
    {
        Console.WriteLine($"# Arguments : {sender.ArgumentCount}");
        Console.WriteLine($"Properties  : {sender.ArgumentsJoined()}");

        if (sender.LastName() == "Payne")
        {
            sender.UpdateLastName("Adams");
        }

        Console.WriteLine($"Changed     : {sender.ArgumentsJoined()}");
    }

    static void SqlStatementExample()
    {
        FormattableString sql = InsertStatementExample("People");
        Console.WriteLine(sql.TableName());
    }
    private static FormattableString InsertStatementExample(string tableName)
    {
        if (tableName == "People")
        {
            tableName = "Customers";
        }

        return $"""
                INSERT INTO dbo.{tableName} ([FirstName], [LastName], [BirthDate])
                VALUES
                ( N'Benny', N'Anderson', N'2005-05-27' ),
                ( N'Teri', N'Schaefer', N'2002-12-19' ),
                ( N'Clint', N'Mate', N'2005-09-15' ),
                ( N'Drew', N'Green', N'2002-01-08' ),
                ( N'Denise', N'Schrader', N'2001-01-08' )
                """;
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
}

public static class Extensions
{
    public static string TableName(this FormattableString sender)
        => (string)sender.GetArguments()[0];

    public static string ArgumentsJoined(this FormattableString sender)
        => string.Join(",", sender.GetArguments());

    public static string FirstName(this FormattableString sender)
        => (string)sender.GetArguments()[1];

    public static string LastName(this FormattableString sender)
        => (string)sender.GetArguments()[2];

    public static void UpdateFirstName(this FormattableString sender, string value)
    {
        sender.GetArguments()[1] = value;
    }
    public static void UpdateLastName(this FormattableString sender, string value)
    {
        sender.GetArguments()[2] = value;
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public enum DatabaseType
{
    [Description("SqlServer")] SqlServer = 0,
    [Description("MySql")] MySql = 1,
    [Description("Oracle")] Oracle = 2,
    [Description("Sqlite")] Sqlite = 3,
    [Description("PostgreSql")] PostgreSql = 4
}

public static class DatabaseHelper
{
    public static (string sqlFormat, Dictionary<string, object> parameter) ToParameter(
        this FormattableString sql,
        DatabaseType databaseType)
    {
        ArgumentNullException.ThrowIfNull(sql);

        var sqlFormat = sql.Format;
        var parameter = new Dictionary<string, object>();
        var arguments = sql.GetArguments();

        if (sql.ArgumentCount <= 0)
        {
            return (sqlFormat, parameter);
        }

        var prefix = databaseType switch
        {
            DatabaseType.Sqlite => "@",
            DatabaseType.SqlServer => "@",
            DatabaseType.MySql => "?",
            DatabaseType.Oracle => ":",
            DatabaseType.PostgreSql => ":",
            _ => "",
        };

        for (int index = 0; index < sql.ArgumentCount; index++)
        {
            var name = $"{prefix}p__{index + 1}";

            sqlFormat = sqlFormat.Replace($"{{{index}}}", name);

            parameter[name] = arguments[index];
        }

        return (sqlFormat, parameter);
    }
}

