using System.Text.RegularExpressions;
using RegularExpressionsTimeOutApp.Classes;

namespace RegularExpressionsTimeOutApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        RegularExpressionsOperations.SetTimeout();

        /*
         * If timeout there is no default timeout for regular expression operations.
         */
        AnsiConsole.MarkupLine($"[yellow]Regular Expressions domain Timeout[/] " +
                               $"[white]{RegularExpressionsOperations.GetTimeout()}[/]");

        string input = "The English alphabet has 26 letters";
        
        try
        {
            bool result = NumberPatternRegex().IsMatch(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (RegexMatchTimeoutException ex)
        {
            Console.WriteLine("Match timed out!");
            Console.WriteLine("- Timeout interval specified: " + ex.MatchTimeout);
            Console.WriteLine("- Pattern: " + ex.Pattern);
            Console.WriteLine("- Input: " + ex.Input);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        SpectreConsoleHelpers.ExitPrompt();
    }

    [GeneratedRegex(@"\d+", RegexOptions.None)]
    private static partial Regex NumberPatternRegex();
}