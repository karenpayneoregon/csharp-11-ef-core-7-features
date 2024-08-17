using System.Text.RegularExpressions;

namespace PropertyChangedApp1.Classes;
public static partial class Helpers
{
    public static string ProperCased(this string source)
        => SentenceCaseRegex()
            .Replace(source.ToLower(), s => s.Value.ToUpper());
    /// <summary>
    /// Represents a regular expression used for converting the first letter of each sentence
    /// in a string to uppercase.
    /// </summary>
    /// <returns>
    /// A regular expression for sentence casing.
    /// </returns>
    [GeneratedRegex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture)]
    private static partial Regex SentenceCaseRegex();
}
