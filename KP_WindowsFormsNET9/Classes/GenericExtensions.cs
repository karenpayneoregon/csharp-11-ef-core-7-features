namespace KP_WindowsFormsNET9.Classes;

public static class GenericExtensions
{

    public static bool HasBannedWords(this ReadOnlySpan<char> text, SearchValues<string> bannedWords) =>
        text.ContainsAny(bannedWords);

    public static bool HasBannedWords(this string text, SearchValues<string> bannedWords) =>
        text.AsSpan().ContainsAny(bannedWords);

    /// <summary>
    /// Determines whether the specified text contains any of the banned words.
    /// </summary>
    /// <param name="text">The text to be checked for banned words.</param>
    /// <param name="bannedWords">An array of banned words to search for within the text.</param>
    /// <returns>
    /// <c>true</c> if the text contains any of the banned words; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasBannedWords(this string text, params string[] bannedWords) => 
        text.AsSpan().ContainsAny(SearchValues.Create(bannedWords, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Determines whether the specified text contains any of the given dates.
    /// </summary>
    /// <param name="text">The text to be checked for dates.</param>
    /// <param name="dates">An array of dates to search for within the text.</param>
    /// <returns>
    /// <c>true</c> if the text contains any of the specified dates; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasDates(this string text, params string[] dates) =>
        text.AsSpan().ContainsAny(SearchValues.Create(dates, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Determines whether the specified line contains a warning or error.
    /// </summary>
    /// <param name="line">The line of text to be checked for warnings or errors.</param>
    /// <returns>
    /// <c>true</c> if the line contains a warning or error; otherwise, <c>false</c>.
    /// </returns>
    public static bool LineHasWarningOrError(this string line)
    {
        string[] tokens = ["<type>Error</type>", "<type>Warning</type>"];
        return line.AsSpan().ContainsAny(SearchValues.Create(tokens, StringComparison.OrdinalIgnoreCase));
    }

    public static void WriteNumbers<T>(params IEnumerable<T> values) => Console.WriteLine("IEnumerable");
    public static void WriteNumbers<T>(params ReadOnlySpan<T> values) => Console.WriteLine("Span");
}
