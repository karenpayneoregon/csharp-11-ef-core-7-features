using Net9Features.Classes;

namespace Net9Features;

using static System.Globalization.DateTimeFormatInfo;
internal partial class Program
{
    static void Main(string[] args)
    {
        EvaluatePersonLeadStatus();
        Console.ReadLine();
    }

    private static void EvaluatePersonLeadStatus()
    {
        var person = MockedData.InitializePersonWithOrganization();
        if (person.IsLead())
        {
            AnsiConsole.MarkupLine("[cyan]Is Lead[/]");
        }
        else
        {
            Console.WriteLine("[red]Is not lead[/]");
        }
    }



    public static List<string> Months => CurrentInfo.MonthNames[..^1].ToList();
}