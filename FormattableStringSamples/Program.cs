using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using FormattableStringSamples.Classes;
using FormattableStringSamples.Models;
#pragma warning disable IDE0059

namespace FormattableStringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        //AnsiConsole.MarkupLine("[yellow]Hello[/]");
        //CodeSamples.FormatDates("MM/dd/yyyy", [new DateOnly(2000, 1, 1), new DateOnly(1999, 12, 9)]);

        var sql = InsertStatementExample1("Karen", "Payne", new DateOnly(1960, 12, 25));
        var (sqlFormat, parameters) = sql.ToParameters(DatabaseType.SqlServer);
        Console.WriteLine(sqlFormat);

        foreach (KeyValuePair<string, object> kp in parameters)
        {
            var (parameterName, parameterValue) = kp.Deconstruct();
            Console.WriteLine($"{parameterName, -10}{parameterValue}");
        }

        Console.WriteLine();

        Dictionary<SourceType, Dictionary<Title, Author>> dictionary = new()
        {
            {
                "Books", new()
                {
                    { "Professional C# 7 and .NET Core 2.0", "Christian Nagel" },
                    { "Professional C# 8 and .NET 5", "Christian Nagel" }
                }
            },
            {
                "Magazines", new()
                {
                    { "MSDN Magazine", "Various" },
                    { "Visual Studio Magazine", "Various" }
                }
            }
        };

        foreach (var dict in dictionary)
        {
            Console.WriteLine($"{dict.Key}");
            foreach (var d in dict.Value)
            {
                Console.WriteLine($"    {d.Key, -40}{d.Value}");
            }
        }

        //PersonFormat();
        //DayOfWeekExample();
        //InsertStatementExample();


        Console.ReadLine();
    }


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
