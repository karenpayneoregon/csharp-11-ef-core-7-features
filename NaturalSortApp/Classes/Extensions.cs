using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;
public static class Extensions
{
    public static IEnumerable<T> NaturalOrderBy<T>(this IEnumerable<T> items, Func<T, string> selector, StringComparer stringComparer = null)
    {
        var regex = new Regex(@"\d+", RegexOptions.Compiled);

        int maxDigits = items
            .SelectMany(value => regex.Matches(selector(value))
                .Select(digitChunk => (int?)digitChunk.Value.Length)).Max() ?? 0;

        return items.OrderBy(value => regex.Replace(selector(value), 
            match => match.Value.PadLeft(maxDigits, '0')), 
            stringComparer ?? StringComparer.CurrentCulture);
    }


}
