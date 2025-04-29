using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;

public static partial class Extensions
{
    // Cache regex instance
    private static readonly Regex _digitPatternRegex = DigitPatternRegex(); 
    /// <summary>
    /// Orders the elements of a sequence in a natural sort order, which takes numeric values within strings into account.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <param name="items">The sequence of items to be ordered.</param>
    /// <param name="selector">
    /// A function to extract the string representation of each element, which will be used for sorting.
    /// </param>
    /// <param name="stringComparer">
    /// An optional <see cref="StringComparer"/> to use for comparing strings. If not provided, the current culture's comparer is used.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the elements of the input sequence, ordered naturally.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="items"/> or <paramref name="selector"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<T> NaturalOrderBy<T>(this IEnumerable<T> items, Func<T, string> selector, StringComparer stringComparer = null)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        // Find maxDigits efficiently
        int maxDigits = items
            .Select(selector)
            .SelectMany(value => _digitPatternRegex
                .Matches(value)
                .Select(m => m.Length))
            .DefaultIfEmpty(0)
            .Max();

        // Order items naturally
        return items.OrderBy(value => _digitPatternRegex.Replace(selector(value),
                match => match.Value.PadLeft(maxDigits, '0')),
            stringComparer ?? StringComparer.CurrentCulture);
    }

    [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
    private static partial Regex DigitPatternRegex();
}
