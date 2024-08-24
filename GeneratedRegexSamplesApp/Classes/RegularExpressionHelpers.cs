using System.Globalization;
using System.Text.RegularExpressions;
using static System.Globalization.DateTimeFormatInfo;

namespace GeneratedRegexSamplesApp.Classes;
public static partial class RegularExpressionHelpers
{

    public static IEnumerable<DateTime> ParseDates(string input)
    {
        var matches = DatesRegex().Matches(input);
        var result = new List<DateTime>(matches.Count);
        var culture = new CultureInfo("en-US");

        foreach (Match match in matches)
        {
            var day = match.Groups["day"].Value;
            var month = match.Groups["month"].Value;
            var year = match.Groups["year"].Value;
            var date = DateTime.ParseExact($"{day}-{month}-{year}", "d-MMMM-yyyy", culture);

            result.Add(date);
        }

        return result;
    }

    /// <summary>
    /// Gets the index corresponding to the specified short month name.
    /// </summary>
    /// <param name="month">The short month name.</param>
    /// <returns>The index corresponding to the short month name.</returns>
    public static int GetNumberFromShortMonth(string month)
        => Array.IndexOf(CurrentInfo!.AbbreviatedMonthNames[..^1], month.ProperCased()) + 1;

    /// <summary>
    /// Generates the next value based on the given value and increment.
    /// </summary>
    /// <param name="value">The current value.</param>
    /// <param name="incrementBy">The increment value (default is 1).</param>
    /// <returns>The next value.</returns>
    public static string NextValue(string value, int incrementBy = 1)
    {
        var current = NumbersPatternRegex().Match(value).Value;
        return value[..^current.Length] + (long.Parse(current) + incrementBy)
            .ToString().PadLeft(current.Length, '0');
    }

    /// <summary>
    /// Is a valid SSN
    /// </summary>
    /// <returns>True if valid, false if invalid SSN</returns>
    /// <remarks>
    /// 
    /// Guaranteed to never be an empty string or null, client code handles this. 
    /// 
    /// ^                                       #Start of expression
    /// (?!\b(\d)\1+-(\d)\1+-(\d)\1+\b)         #Don't allow all matching digits for every field
    /// (?!123-45-6789|219-09-9999|078-05-1120) #Don't allow "123-45-6789", "219-09-9999" or "078-05-1120"
    /// (?!666|000|9\d{2})\d{3}                 #Don't allow the SSN to begin with 666, 000 or anything between 900-999
    /// -                                       #A dash (separating Area and Group numbers)
    /// (?!00)\d{2}                             #Don't allow the Group Number to be "00"
    /// -                                       #Another dash (separating Group and Serial numbers)
    /// (?!0{4})\d{4}                           #Don't allow last four digits to be "0000"
    /// $                                       #End of expression
    /// </remarks>
    public static bool IsValidSocialSecurityNumber(string value) => SSNValidationRegex().IsMatch(value.Replace("-", ""));

    
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));
    

    public static string SplitCamelCase2(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();
    }


    /// <summary>
    /// Regular expression pattern for matching camel case words.
    /// </summary>
    private static readonly Regex CamelCaseRegex = CasingRegex();

    [GeneratedRegex("^(?!\\b(\\d)\\1+\\b)(?!123456789|219099999|078051120)(?!666|000|9\\d{2})\\d{3}(?!00)\\d{2}(?!0{4})\\d{4}$")]
    private static partial Regex SSNValidationRegex();

    [GeneratedRegex(@"(?<day>\d{1,2})((st)|(nd)|(rd)|(th))? (?<month>[A-Za-z]+) (?<year>\d{4})")]
    private static partial Regex DatesRegex();

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CasingRegex();

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPatternRegex();
}