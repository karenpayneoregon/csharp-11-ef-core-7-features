using System.Linq.Expressions;
using System.Text.Json;
using NodaTime.Text;
using NodaTime;
using NodaTimeDemoApp.Classes;
using NodaTimeLibrary.Classes;
using NodaTimeLibrary.Models;

using static NodaTimeDemoApp.Classes.SpectreConsoleHelpers;

namespace NodaTimeDemoApp;

internal partial class Program
{
    static void Main(string[] args)
    {

     UnitedStates us = new();



        AnsiConsole.MarkupLine($"[yellow]United States[/]");
        AnsiConsole.MarkupLine($"[cyan]  Eastern offset[/]: [b]{us.EastCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{us.EastCoast.DaylightSavingsSupported.ToYesNo()}[/]");
        AnsiConsole.MarkupLine($"[cyan]        TimeSpan:[/] [b]{us.EastCoast.GetTimeSpan().Hours}[/]");

        AnsiConsole.MarkupLine($"[cyan]  Western offset[/]: [b]{us.WestCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{us.WestCoast.DaylightSavingsSupported.ToYesNo()}[/]");
        AnsiConsole.MarkupLine($"[cyan]        TimeSpan:[/] [b]{us.WestCoast.GetTimeSpan().Hours}[/]");

        Console.WriteLine();

        Mexico mx = new();

        AnsiConsole.MarkupLine($"[yellow]Mexico[/]");
        AnsiConsole.MarkupLine($"[cyan]       Sea Coast[/]: [b]{mx.SeaCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{mx.SeaCoast.DaylightSavingsSupported.ToYesNo()}[/]");

        Console.WriteLine();

        GetYearsOld();


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




