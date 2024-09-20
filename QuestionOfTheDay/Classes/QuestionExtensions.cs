namespace QuestionOfTheDay.Classes;

static class QuestionExtensions
{
    public static List<T>? NullIfEmpty<T>(this List<T>? list) 
        => list!.Any() ? list : null;
    public static List<T>? ToListOrNullIfEmpty<T>(this IEnumerable<T> collection) 
        => collection.Any() ? collection.ToList() : null;
}