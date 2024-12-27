// ReSharper disable RedundantIfElseBlock
using System.Text.RegularExpressions;

namespace NewStuffApp.Classes;


public static partial class StringExtensions
{
    public static string UpToFirstPeriodOrThreeWords(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var periodIndex = input.IndexOf('.');

        if (periodIndex >= 0)
        {
            return input[..(periodIndex + 1)];
        }
        else
        {
            var words = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words.Take(3));
        }
    }
    /// <summary>
    /// Removes the surrounding double quotes from the specified string, if present.
    /// </summary>
    /// <param name="input">The input string to process.</param>
    /// <returns>
    /// A string with the surrounding double quotes removed if they exist; 
    /// otherwise, the original string.
    /// </returns>
    public static string RemoveQuotes1(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input is ['"', _, ..] && input[^1] == '"')
            return input.Substring(1, input.Length - 2);

        return input;
    }

    public static string RemoveQuotes(this string input)
    {
        return string.IsNullOrEmpty(input) ? 
            input : 
            RemoveQuotesRegex().Replace(input, "$1");
    }

    [GeneratedRegex("^\"(.*)\"$")]
    private static partial Regex RemoveQuotesRegex();

}

