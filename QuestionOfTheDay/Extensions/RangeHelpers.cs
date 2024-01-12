using QuestionOfTheDay.Models;

namespace QuestionOfTheDay.Extensions;

public static class RangeHelpers
{

    public static List<Container<T>> Get<T>(this List<T> sender) =>
        sender.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(sender.Count - index - 1, true),
            MonthIndex = index + 1
        }).ToList();

    public static List<Container<T>> Get<T>(this T[] sender) =>
        sender.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(sender.Length - index - 1, true),
            MonthIndex = index + 1
        }).ToList();
}