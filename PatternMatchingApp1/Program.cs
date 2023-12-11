using PatternMatchingApp1.Classes;

namespace PatternMatchingApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<DateOnly> months = DataService.MonthList();

        List<DateOnly> conferenceDays = months
            .Where(x => (x.Month is 1 && x.Day is 12 or 13 or 14) || (x.Month is 3 && x.Day is 8 or 9 or 10))
            .ToList();

        AnsiConsole.MarkupLine(conferenceDays.Count > 0
            ? "[yellow]Found conference days[/]"
            : "[yellow]No conference dates found[/]");

        Console.ReadLine();
    }
}

