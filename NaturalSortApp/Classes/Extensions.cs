using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;
public static partial class Extensions
{

    /// <summary>
    /// Orders the elements of a sequence of strings in a natural sort order, 
    /// where numeric substrings are compared based on their numeric values.
    /// </summary>
    /// <param name="items">The sequence of strings to be ordered.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of strings ordered in natural sort order.</returns>
    public static IEnumerable<string> NaturalOrderBy(this IEnumerable<string> items) =>
        items.OrderBy(x => NumbersRegex()
            .Replace(x, m => m.Value.PadLeft(50, '0')));

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

}
