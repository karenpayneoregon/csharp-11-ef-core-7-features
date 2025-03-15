using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;

public static partial class Extensions
{
    public static IEnumerable<T> NaturalOrderBy<T>(this IEnumerable<T> items, Func<T, string> selector, StringComparer stringComparer = null)
    {
        var regex = DigitPatternRegex();

        int maxDigits = items
            .SelectMany(value => regex.Matches(selector(value))
                .Select(digitChunk => (int?)digitChunk.Value.Length)).Max() ?? 0;

        return items.OrderBy(value => regex.Replace(selector(value),
                match => match.Value.PadLeft(maxDigits, '0')),
            stringComparer ?? StringComparer.CurrentCulture);
    }

    [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
    private static partial Regex DigitPatternRegex();
}