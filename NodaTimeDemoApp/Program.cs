using System.Linq.Expressions;
using System.Text.Json;
using NodaTimeDemoApp.Classes;
using NodaTimeLibrary.Classes;
using NodaTimeLibrary.Models;

using static NodaTimeDemoApp.Classes.SpectreConsoleHelpers;

namespace NodaTimeDemoApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        List<IndexContainer<string>> details = Helpers.AbbreviatedMonthNames();
        var exist = Helpers.Contains("Jan");
        var proper1 = "JAN".ProperCased();
        var proper2 = "jAn".ProperCased();
        var proper3 = "jan".ProperCased();

        var index = Helpers.GetNumberFromShortMonth("jun");

        
        var properName2 = "Hello john doe".ProperCased();

        Demo();
        UnitedStates us = new();
        
        AnsiConsole.MarkupLine($"[yellow]United States[/]");
        AnsiConsole.MarkupLine($"[cyan]  Eastern offset[/]: [b]{us.EastCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{us.EastCoast.DaylightSavingsSupported.ToYesNo()}[/]");

        AnsiConsole.MarkupLine($"[cyan]  Western offset[/]: [b]{us.WestCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{us.WestCoast.DaylightSavingsSupported.ToYesNo()}[/]");

        Console.WriteLine();

        Mexico mx = new();

        AnsiConsole.MarkupLine($"[yellow]Mexico[/]");
        AnsiConsole.MarkupLine($"[cyan]       Sea Coast[/]: [b]{mx.SeaCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{mx.SeaCoast.DaylightSavingsSupported.ToYesNo()}[/]");

        Console.WriteLine();

        GetYearsOld();

        Person person =  new Person()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1980, 1, 1)
        };

        //Utilities.UpdateView(() => person);


        ExitPrompt();
    }

    private static void GetYearsOld()
    {
        PrintCyan();

        DateOnly birthDate = Prompts.GetBirthDate();
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        var period = PeriodOperations.YearsOld(birthDate, today);
        AnsiConsole.MarkupLine($"[b]{period.Years}[/] years  " +
                               $"[b]{period.Months}[/] months " +
                               $"[b]{period.Days}[/] days");
    }

    private static void Demo()
    {
        string json =
            """
            [
                        {
                            "Date": "2013-01-07T00:00:00Z",
                            "Temperature": 23
                        },
                        {
                            "Date": "2013-01-08T00:00:00Z",
                            "Temperature": 28
                        },
                        {
                            "Date": "2013-01-14T00:00:00Z",
                            "Temperature": 8
                        }
                    ]
            """;

        var list = JsonSerializer.Deserialize<List<Result>>(json);

    }
}

public class Result
    {
    public DateTimeOffset Date { get; set; }
    public int Temperature { get; set; }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}


