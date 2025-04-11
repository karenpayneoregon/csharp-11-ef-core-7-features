using System.Text.RegularExpressions;

namespace FieldKeywordSample.Classes;
public static partial class StringExtensions
{

    /// <summary>
    /// Capitalizes the first letter of the given string.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>A new string with the first letter capitalized. If the input is null or empty, the original string is returned.</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;

        return char.ToUpper(input[0]) + input.AsSpan(1).ToString();
    }


    /// <summary>
    /// Trims the last character from the given string.
    /// </summary>
    /// <param name="sender">The string from which to trim the last character.</param>
    /// <returns>A new string with the last character removed, or the original string if it is null or whitespace.</returns>
    public static string TrimLastCharacter(this string sender)
        => string.IsNullOrWhiteSpace(sender) ?
            sender :
            sender[..^1];

    /// <summary>
    /// Removes extra spaces from the given string, optionally trimming the end.
    /// </summary>
    /// <param name="source">The string from which to remove extra spaces.</param>
    /// <param name="trimEnd">If set to <c>true</c>, trims the end of the resulting string.</param>
    /// <returns>A new string with extra spaces removed.</returns>
    public static string RemoveExtraSpaces(this string source, bool trimEnd = false)
    {
        var result = ExtraSpacesRegex().Replace(source, " ");
        return trimEnd ? result.TrimEnd() : result;
    }

    /// <summary>
    /// Replaces the last occurrence of a specified string within the given string.
    /// </summary>
    /// <param name="source">The string to search within.</param>
    /// <param name="find">The string to find case-sensitive.</param>
    /// <param name="replace">The string to replace the found string with.</param>
    /// <returns>A new string with the last occurrence of the specified string replaced.</returns>
    public static string ReplaceLast(this string source, string find, string replace)
    {
        var index = source.LastIndexOf(find, StringComparison.OrdinalIgnoreCase);
        return index == -1 ?
            source :
            source.Remove(index, find.Length).Insert(index, replace);
    }

    /// <summary>
    /// Provides a regular expression to match sequences of two or more whitespace characters.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object that matches sequences of two or more whitespace characters.</returns>
    /// <remarks>
    /// Pattern:<br/>
    /// <code>\s{2,}</code><br/>
    /// Explanation:<br/>
    /// <code>
    /// ○ Match a whitespace character atomically at least twice.<br/>
    /// </code>
    /// </remarks>
    [GeneratedRegex(@"\s{2,}", RegexOptions.None)]
    private static partial Regex ExtraSpacesRegex();
}
