using System.Text.RegularExpressions;

namespace GeneratedRegexSamplesApp.Classes;
public static partial class Helpers
{
    /// <summary>
    /// Converts the first letter of each sentence in the string to uppercase,
    /// while keeping the rest of the string in lowercase.
    /// </summary>
    /// <param name="source">The string to be properly cased.</param>
    /// <returns>The properly cased string.</returns>
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
