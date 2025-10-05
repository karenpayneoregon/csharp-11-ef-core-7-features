namespace ForEachIndexing.Classes;
public static class Extensions
{

    /// <summary>
    /// Returns an enumerator that iterates through the span.
    /// </summary>
    /// <typeparam name="T">The type of elements in the span.</typeparam>
    /// <param name="sender">The span to iterate through.</param>
    /// <returns>An enumerator that can be used to iterate through the span.</returns>
    public static Span<T>.Enumerator Enumerator<T>(this Span<T> sender)
        => sender.GetEnumerator();


    public static List<T> Times<T>(this int sender, T item)
        => Enumerable.Range(0, sender).Select(x => item).ToList();

}

