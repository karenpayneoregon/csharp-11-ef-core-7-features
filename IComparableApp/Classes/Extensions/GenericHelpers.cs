
namespace IComparableApp.Classes.Extensions;

public static class GenericsExtensions
{
    /// <summary>
    /// Enumerates a sequence of elements, yielding each element along with its index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <param name="source">The sequence of elements to enumerate.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of tuples, where each tuple contains the index and the element.</returns>
    /// <remarks>
    /// https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/libraries#linq
    /// https://stackoverflow.com/questions/43021/how-do-you-get-the-index-of-the-current-iteration-of-a-foreach-loop?rq=2
    /// https://github.com/dotnet/runtime/pull/95947/files#diff-12d771219a25123dfc8964ed48a5e2fad41aa1c6a0e85fe1122fb8197dd57691R24-R36
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
}

