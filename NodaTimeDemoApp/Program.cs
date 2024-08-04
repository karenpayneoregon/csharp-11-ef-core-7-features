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

        AnsiConsole.MarkupLine($"[cyan]  Western offset[/]: [b]{us.WestCoast.Offset}[/]");
        AnsiConsole.MarkupLine($"[cyan]Daylight savings:[/] [b]{us.WestCoast.DaylightSavingsSupported.ToYesNo()}[/]");

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
}