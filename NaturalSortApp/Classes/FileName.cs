using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;

public static partial class Extensions
{
    // Cache regex instance
    private static readonly Regex _digitPatternRegex = DigitPatternRegex(); 

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
