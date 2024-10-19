using QuestionOfTheDay.Models;

namespace QuestionOfTheDay.Extensions;

public static class RangeHelpers
{

    public static List<Container<T>> Get<T>(this List<T> sender) =>
        sender.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new(index),
            EndIndex = new(sender.Count - index - 1, true),
            Index = index + 1
        }).ToList();

    public static List<Container<T>> Get<T>(this T[] sender) =>
        sender.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new(index),
            EndIndex = new(sender.Length - index - 1, true),
            Index = index + 1
        }).ToList();
}