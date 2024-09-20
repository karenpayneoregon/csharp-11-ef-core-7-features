namespace QuestionOfTheDay.Classes;

public class QuestionOfTheDay
{
    public static List<T> Method1<T>() => Enumerable.Empty<T>().ToList();
    public static List<T> Method2<T>() => Array.Empty<T>().ToList();
    public static List<T> Method3<T>() => new(0);
    public static List<T> Method4<T>() => [];
    public static List<T>? Method5<T>() => null;
    public static IEnumerable<T> Method6<T>()
    {
        yield break;
    }
}