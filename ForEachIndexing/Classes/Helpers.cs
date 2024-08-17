using System.Text.RegularExpressions;
using static System.Globalization.DateTimeFormatInfo;

namespace ForEachIndexing.Classes;
public static partial class Helpers
{
    public static int GetNumberFromShortMonth(string month)
        => Array.IndexOf(CurrentInfo!.AbbreviatedMonthNames[..^1], month.ProperCased()) + 1;

    /// <summary>
    /// Converts the first letter of each sentence in the string to uppercase,
    /// while keeping the rest of the string in lowercase.
    /// Came from https://stackoverflow.com/a/3141467/5509738
    /// </summary>
    /// <param name="source">The string to be properly cased.</param>
    /// <returns>The properly cased string.</returns>
    public static string ProperCased(this string source)
        => SentenceCaseRegex()
            .Replace(source.ToLower(), s => s.Value.ToUpper());

    [GeneratedRegex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture)]
    private static partial Regex SentenceCaseRegex();
}
