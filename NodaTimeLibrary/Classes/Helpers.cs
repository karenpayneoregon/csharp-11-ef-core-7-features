using System.Text.RegularExpressions;
using static System.Globalization.DateTimeFormatInfo;

namespace NodaTimeLibrary.Classes;
public static partial class Helpers
{
    /// <summary>
    /// Returns a list of <see cref="IndexContainer{T}"/> objects containing
    /// the elements of the array along with their corresponding indexes.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="sender">The array to be indexed.</param>
    /// <returns>
    /// A list of <see cref="IndexContainer{T}"/> objects containing
    /// the elements of the array along with their corresponding indexes.
    /// </returns>
    public static List<IndexContainer<T>> Indexed<T>(this T[] sender) =>
        sender.Select((element, index) => new IndexContainer<T>
        {
            Value = element,
            Index = index + 1
        }).ToList();

    /// <summary>
    /// Returns a list of <see cref="IndexContainer{T}"/> objects containing
    /// the elements of the array along with their corresponding indexes.
    /// </summary>
    /// <returns>
    /// A list of <see cref="IndexContainer{T}"/> objects containing
    /// the elements of the array along with their corresponding indexes.
    /// </returns>
    public static List<IndexContainer<string>> AbbreviatedMonthNames()
        => CurrentInfo!.AbbreviatedMonthNames[..^1].Indexed();

    /// <summary>
    /// Determines whether the specified month is contained in the abbreviated month names.
    /// </summary>
    /// <param name="month">The month to check.</param>
    /// <returns>
    ///   <c>true</c> if the specified month is contained in the
    /// abbreviated month names; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains(string month)
        => CurrentInfo!.AbbreviatedMonthNames.Contains(month,
            StringComparer.CurrentCultureIgnoreCase);

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

    
    /// <summary>
    /// Gets the index corresponding to the specified short month name.
    /// </summary>
    /// <param name="month">The short month name.</param>
    /// <returns>The index corresponding to the short month name.</returns>
    public static int GetNumberFromShortMonth(string month)
        => Array.IndexOf(CurrentInfo!.AbbreviatedMonthNames[..^1], month.ProperCased()) + 1;

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
public class IndexContainer<T>
{
    /// <summary>
    /// Gets or sets the value of the container.
    /// </summary>
    public required T Value { get; init; }

    /// <summary>
    /// Gets or sets the index of the container.
    /// </summary>
    public int Index { get; init; }
}

