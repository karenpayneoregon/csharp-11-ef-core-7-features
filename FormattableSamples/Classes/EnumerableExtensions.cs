namespace FormattableSamples.Classes;

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> sender) 
        => sender is ICollection<T> collection ? collection.Count == 0 : !sender.Any();
}