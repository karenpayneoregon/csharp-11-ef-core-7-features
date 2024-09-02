using System.Runtime.CompilerServices;
using FormattableStringSamples.Classes;
using FormattableStringSamples.Models;
using static FormattableStringSamples.Classes.Helpers;

// ReSharper disable ConvertToLocalFunction
// ReSharper disable ConvertClosureToMethodGroup
#pragma warning disable IDE0059

namespace FormattableStringSamples;

internal partial class Program
{
    private static void Main()
    {


        var name = "Karen";
        var (saturday, sunday) = DateTime.Now.GetWeekendDates();
        FormattableString weekend = FormattableStringFactory.Create("{0} the week {1} {2}", name, saturday, sunday);

        //Console.WriteLine(weekend);

        foreach (var item in weekend.GetArguments())
        {
            if (item is DateOnly date)
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine($"Name is {item}");
            }

        }




        var nextInvoice = (string invoice, int increment = 1)
            => NextValue(invoice, increment);

        var nextInvoiceValue1 = nextInvoice(arg1: "A100", arg2: 2);
        var nextInvoiceValue2 = NextValue(value: "A100", incrementBy: 2);



        Console.WriteLine(nextInvoiceValue1);
        Console.WriteLine(nextInvoiceValue2);



        Dictionary<string, DateOnly> dictDates = new()
        {
            { "H4", new(2017,1,1) },
            { "H5", new(2017,1,2) },
            { "H6", new(2017,1,3) },
            { "H7", new(2017,1,4)}
        };

        foreach (KeyValuePair<string, DateOnly> kvp in dictDates)
        {
            var (cell, date) = kvp.Deconstruct();
            Console.WriteLine($"{cell,-3}{date}");
        }
        Console.ReadLine();

    }


    private static void FromMain()
    {
        //AnsiConsole.MarkupLine("[yellow]Hello[/]");
        //CodeSamples.FormatDates("MM/dd/yyyy", [new DateOnly(2000, 1, 1), new DateOnly(1999, 12, 9)]);

        var sql = InsertStatementExample1("Karen", "Payne", new DateOnly(1960, 12, 25));
        var (sqlFormat, parameters) = sql.ToParameters(DatabaseType.SqlServer);
        Console.WriteLine(sqlFormat);

        foreach (KeyValuePair<string, object> kp in parameters)
        {
            var (parameterName, parameterValue) = kp.Deconstruct();
            Console.WriteLine($"{parameterName,-10}{parameterValue}");
        }

        Console.WriteLine();

        Dictionary<string, Dictionary<Title, Author>> dictionary = GetASD();

        foreach (var dict in dictionary)
        {
            Console.WriteLine($"{dict.Key}");
            foreach (var d in dict.Value)
            {
                Console.WriteLine($"    {d.Key,-40}{d.Value}");
            }
        }

        //PersonFormat();
        //DayOfWeekExample();
        //InsertStatementExample();
    }

    private static Dictionary<SourceType, Dictionary<Title, Author>> GetASD() => new()
        {
            {
                "Books", new Dictionary<Title, Author>
                {
                    { "Professional C# 7 and .NET Core 2.0", "Christian Nagel" },
                    { "Professional C# 8 and .NET 5", "Christian Nagel" }
                }
            },
            {
                "Magazines", new Dictionary<Title, Author>
                {
                    { "MSDN Magazine", "Various" },
                    { "Visual Studio Magazine", "Various" }
                }
            }
        };


    


private static void DayOfWeekExample()
    {

        FormattableString format = FormattableStringFactory.Create("The weekend {0} {1} {2}",
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday);

        Console.WriteLine($"Format      : {format.Format}");
        Console.WriteLine($"# Arguments : {format.ArgumentCount}");
        Console.WriteLine($"Arguments   : {string.Join(",", format.GetArguments())}");

        format.GetArguments()[2] = DayOfWeek.Monday;

        Console.WriteLine($"Changed     : {string.Join(",", format.GetArguments())}");
        Console.WriteLine(format.ToString());

        Console.WriteLine("");

        for (int index = 0; index < format.ArgumentCount; index++)
        {
            Console.WriteLine($"{index,-4}{format.GetArguments()[index]}");
        }
    }
    private static void PersonExample()
    {
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2}",
            person.Id, person.FirstName, person.LastName);

        Console.WriteLine($"Last name null {(format.LastName() is null).ToYesNo()}");

        Console.WriteLine($"Format      : {format.Format}");
        Console.WriteLine($"# Arguments : {format.ArgumentCount}");

        Console.WriteLine(format.ArgumentsJoined());

        GetPropertyValues(format);
        UpdatePropertyValues(format);
        GetPropertyValues(format);

        Console.WriteLine(format.ToString());

        var hello = (FormattableString)$"{Howdy.TimeOfDay()}, {person.FirstName}!";
        Console.WriteLine(hello);

        for (int index = 0; index < format.ArgumentCount; index++)
        {
            Console.WriteLine($"{format.GetArgument(index)}");

        }
    }

    static void GetPropertyValues(FormattableString sender)
    {
        Console.WriteLine($"Id: {sender.Id()} First {sender.FirstName()} Last {sender.LastName()}");
    }
    static void UpdatePropertyValues(FormattableString sender)
    {
        sender.UpdateFirstName("Anne");
        sender.UpdateLastName("Adams");
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

public static class DateTimeExtensions
{
    public static (DateOnly saturday, DateOnly sunday) GetWeekendDates(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Sunday)
    {
        var weekStart = date.AddDays(-(int)date.DayOfWeek + (int)startOfWeek);

        var saturday = weekStart.AddDays(5);
        var sunday = weekStart.AddDays(6);

        return (DateOnly.FromDateTime(saturday), DateOnly.FromDateTime(sunday));

    }
}