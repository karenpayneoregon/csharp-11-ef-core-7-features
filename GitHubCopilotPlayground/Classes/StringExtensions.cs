using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GitHubCopilotPlayground.Classes;

/// <summary>
/// Code which I first asked GitHub Copilot to write then asked Copilot to document some
/// of the methods.
///
/// I modified some of the generated code but beforehand the code worked as what was asked.
/// </summary>
internal static partial class StringExtensions
{

    /// <summary>
    /// Regular expression pattern for matching camel case words.
    /// </summary>
    private static readonly Regex CamelCaseRegex = CasingRegex();

    /// <summary>
    /// Splits a camel case string into separate words.
    /// </summary>
    /// <param name="sender">The string to split.</param>
    /// <returns>A string with the words separated by spaces.</returns>
    [DebuggerStepThrough]
    public static string SplitCamelCase1(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));

    /// <summary>
    /// Split text at each capital letter
    /// </summary>
    /// <param name="input">string to work on</param>
    /// <returns>
    /// <para>An empty string, if the input is null or empty.</para>
    /// <para>Same as original if nothing affected</para>
    /// <para>String split on each uppercase token</para>
    /// <para>SSMS would become S S M S</para>
    /// </returns>
    [DebuggerStepThrough]
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
    /// Remove extra whitespace and trim whitespace from start and end of the string
    /// </summary>
    /// <param name="input">string to work on</param>
    /// <returns>
    /// The string with extra whitespace removed and whitespace trimmed from start and end
    /// </returns>
    [DebuggerStepThrough]
    public static string RemoveExtraWhitespace(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length];
        var resultIndex = 0;
        var isWhitespace = false;

        foreach (var currentChar in input)
        {
            if (char.IsWhiteSpace(currentChar))
            {
                if (!isWhitespace)
                {
                    result[resultIndex++] = ' ';
                    isWhitespace = true;
                }
            }
            else
            {
                result[resultIndex++] = currentChar;
                isWhitespace = false;
            }
        }

        return result[..resultIndex].ToString().Trim();
    }

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CasingRegex();
}
