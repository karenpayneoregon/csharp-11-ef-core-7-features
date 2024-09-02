using System.Diagnostics;

namespace FormattableSamples.Classes;
public static class UtilityExtensions
{
    [DebuggerStepThrough]
    public static string ToYesNo(this bool value)
        => value ? "Yes" : "No";

    [DebuggerStepThrough]
    public static string SplitCase(this string input)
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
    /// Colorize keywords Spectre.Console
    /// </summary>
    /// <param name="sql">String which is a SQL statement</param>
    /// <returns>Formatted string</returns>
    [DebuggerStepThrough]
    public static string StatementColors(string sql) =>
        sql.Replace("INSERT INTO", "[green]INSERT INTO[/]")
            .Replace("VALUES", "[green]VALUES[/]")
            .Replace("CAST", "[yellow]CAST[/]")
            .Replace("SELECT", "[green]SELECT[/]")
            .Replace("scope_identity()", "[green]scope_identity()[/]");

    [DebuggerStepThrough]
    public static bool IsBetween<T>(this T value, T start, T end) where T : IComparable<T>
    {
        return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
    }
}