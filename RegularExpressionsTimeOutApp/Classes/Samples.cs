using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Serilog;

namespace RegularExpressionsTimeOutApp.Classes;
public  partial class Samples
{
    /// <summary>
    /// Determines whether the default timeout for regular expression operations is set to infinite.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the default timeout is infinite; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsDefaultTimeout()
    {
        return Regex.InfiniteMatchTimeout.Milliseconds == -1;
    }
    /// <summary>
    /// Demonstrates the use of regular expressions with an optional timeout setting.
    /// </summary>
    /// <param name="setTimeout">Indicates whether to set a timeout for regular expression operations.</param>
    /// <param name="seconds">The timeout duration in seconds if <paramref name="setTimeout"/> is true.</param>
    /// <remarks>
    /// If <paramref name="setTimeout"/> is true, the method sets a default timeout for regular expression operations
    /// in the current application domain. It then creates a regular expression to match vowels and displays the pattern
    /// and the timeout interval for the regex.
    ///
    /// Original code
    /// https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matchtimeout?view=net-8.0
    /// Modified by Karen Payne
    /// </remarks>
    public static void MicrosoftExample(bool setTimeout, int seconds)
    {
        void SetRegexTimeout(int seconds)
        {
            AppDomain domain = AppDomain.CurrentDomain;
            // Set a timeout interval of 2 seconds.
            domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(seconds));
            var timeout = domain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT");
            Console.WriteLine($"Default regex match timeout: {timeout ?? "<null>"}");
        }

        if (setTimeout)
        {
            SetRegexTimeout(seconds);
        }

        Regex rgx = new Regex("[aeiouy]");
        Console.WriteLine("Regular expression pattern: {0}", rgx.ToString());
        Console.WriteLine("Timeout interval for this regex: {0} seconds",
            rgx.MatchTimeout.TotalSeconds);

    }

    public static void NormalUse()
    {
        string input = @"\\SomeServer\HTTP\demo1\index.html 4 KB HTML File 2/19/2019 3:48:21 PM 2/19/2019 1:05:53 PM 2/19/2019 1:05:53 PM 5";

        const string format = "M/d/yyyy h:mm:ss tt";

        MatchCollection matches = DatesRegex().Matches(input);

        foreach (Match match in matches)
        {
            var dateTime = DateTime.ParseExact(match.Value, format, CultureInfo.InvariantCulture);
            Console.WriteLine(dateTime);
        }
    }

    public static void HandleRegexTimeout()
    {
        // set regular expression timeout from appsettings.json
        RegexOperations.SetTimeout();

        /*
         * If no timeout there is no default timeout for regular expression operations.
         */
        TimeSpan? time = RegexOperations.GetTimeout();
        string formatted = $"{time?.Days:#0:;;\\}{time?.Hours:#0:;;\\}{time?.Minutes:00:}{time?.Seconds:00}";
        AnsiConsole.MarkupLine($"[yellow]Regular Expressions domain Timeout[/] " +
                               $"[white]{time.Value.Format()}[/]");


        string input = "The English alphabet has 26 letters";

        try
        {
            bool result = NumberPatternRegex().IsMatch(input);
            AnsiConsole.MarkupLine($"[cyan]Success?[/] [white]{result.ToYesNo()}[/]");
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
    }

    public static void BadSample()
    {
        //AppDomain.CurrentDomain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(1));

        try
        {
            // Takes more than 10s
            var isMatch = EmailRegex().IsMatch("t@t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.c%20");
        }
        catch (RegexMatchTimeoutException ex)
        {
            AnsiConsole.MarkupLine($"[red]Regex Timeout for[/] {ex.Message} after [cyan]{ex.MatchTimeout}[/] elapsed.");
            AnsiConsole.MarkupLine("[red]Pattern[/]");
            Console.WriteLine(ex.Pattern);
            Log.Error(ex,nameof(BadSample));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            Log.Error(ex, nameof(BadSample));
        }
    }

    public static void BadSampleRaw()
    {
        var timer = new Stopwatch();
        timer.Start();

        var isMatch = EmailRegex().IsMatch("t@t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.t.c%20");

        timer.Stop();

        TimeSpan timeTaken = timer.Elapsed;

        Console.WriteLine(isMatch.ToYesNo());
        Console.WriteLine($"Time taken: {timeTaken:m\\:ss\\.fff}");
    }
}
