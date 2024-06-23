namespace ForEachIndexing.Classes;
public static class Extensions
{
    public static Span<T>.Enumerator Enumerator<T>(this Span<T> sender)
        => sender.GetEnumerator();
}

