using System.Text.RegularExpressions;

namespace DistinctByApp.LanguageExtensions;
public static partial class GenericsExtensions
{
    /// <summary>
    /// Enumerates the elements of a sequence, returning each element along with its index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to enumerate.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of tuples where each tuple contains the index and the element from the source sequence.</returns>
    /// <remarks>
    /// See also Microsoft's documentation on <see href="https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.index?view=net-6.0">Enumerable.Index&lt;TSource&gt;</see>.
    /// </remarks>
    public static IEnumerable<(int Index, TSource Item)> Index<TSource>(this IEnumerable<TSource> source)
    {
        int index = -1;
        foreach (TSource element in source)
        {
            checked
            {
                index++;
            }

            yield return (index, element);
        }
    }

    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));

    /// <summary>
    /// Regular expression pattern for matching camel case words.
    /// </summary>
    private static readonly Regex CamelCaseRegex = CasingRegex();
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CasingRegex();
}
