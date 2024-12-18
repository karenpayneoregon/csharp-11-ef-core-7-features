namespace ForEachIndexing.Classes;
public static class GenericExtensions
{

    /// <summary>
    /// Enumerates a sequence and returns each element along with its index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to enumerate.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of tuples, where each tuple contains the index and the corresponding element from the source sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="source"/> is <c>null</c>.</exception>
    public static IEnumerable<(int Index, TSource Item)> Index<TSource>(this IEnumerable<TSource> source)
    {
        int index = -1;
        foreach (var element in source)
        {
            checked
            {
                index++;
            }

            yield return (index, element);
        }
    }


}

