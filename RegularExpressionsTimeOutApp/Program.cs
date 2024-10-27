using System.Text.RegularExpressions;
using RegularExpressionsTimeOutApp.Classes;

namespace RegularExpressionsTimeOutApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        // set regular expression timeout from appsettings.json
        RegularExpressionsOperations.SetTimeout();

        /*
         * If no timeout there is no default timeout for regular expression operations.
         */
        TimeSpan? time = RegularExpressionsOperations.GetTimeout();
        string formatted = $"{time?.Days:#0:;;\\}{time?.Hours:#0:;;\\}{time?.Minutes:00:}{time?.Seconds:00}";
        AnsiConsole.MarkupLine($"[yellow]Regular Expressions domain Timeout[/] " +
                               $"[white]{formatted}[/]");


        string input = "The English alphabet has 26 letters";
        
        try
        {
            bool result = NumberPatternRegex().IsMatch(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (RegexMatchTimeoutException ex)
        {
            AnsiConsole.MarkupLine("[red]Match timed out![/]");
            AnsiConsole.MarkupLine($"[white]- Timeout interval specified: {ex.MatchTimeout}[/]");
            AnsiConsole.MarkupLine($"[white]- Pattern: {ex.Pattern}[/]");
            AnsiConsole.MarkupLine($"[white]- Input: {ex.Input}[/]");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }

        SpectreConsoleHelpers.ExitPrompt();
    }

    [GeneratedRegex(@"\d+", RegexOptions.None)]
    private static partial Regex NumberPatternRegex();
}