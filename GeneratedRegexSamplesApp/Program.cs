using GeneratedRegexSamplesApp.Classes;
using System.Text.RegularExpressions;

namespace GeneratedRegexSamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[yellow]Original string[/]: 07th December 2022 08 December 2024 01st December 2022");
        foreach (var date in RegularExpressionHelpers.ParseDates("07th December 2022 08 December 2024 01st December 2022"))
        {
            AnsiConsole.MarkupLine($"    [green]{date.ToShortDateString()}[/]");
        }

        Console.WriteLine();

        var index = RegularExpressionHelpers.GetNumberFromShortMonth("dec");
        AnsiConsole.MarkupLine($"[yellow]Dec index[/] [cyan]{index}[/]");


        AnsiConsole.MarkupLine($"[yellow]Next value[/][cyan] Q12Q34[/]: [green]{RegularExpressionHelpers.NextValue("Q12Q34")}[/]");

        AnsiConsole.MarkupLine($"[yellow]Is valid SSN[/] [cyan]305-99-2345[/]: [green]{RegularExpressionHelpers.IsValidSocialSecurityNumber("305992345")}[/] ");

        var bunched = "KarenPayne";
        AnsiConsole.MarkupLine($"[yellow]'{bunched}'[/] [cyan]->[/] [green]'{bunched.SplitCamelCase()}'[/]");

        Console.WriteLine();
        Examples.MatchProducts();

        Console.WriteLine();
        Examples.ExtractDates();

        Console.WriteLine();
        Console.WriteLine(Examples.MaskCreditCardNumber("123456789012345"));


        Console.WriteLine();
        Console.WriteLine("This   is     my test.".RemoveExtraSpaces());

        SpectreConsoleHelpers.ExitPrompt();
    }
}