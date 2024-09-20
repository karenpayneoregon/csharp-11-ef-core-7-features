#nullable enable
using QuestionOfTheDay;

namespace QuestionOfTheDay.Models;

public class Container<T>
{
    public T? Value { get; set; }
    public Index StartIndex { get; set; }
    public int Index { get; set; }
    public Index EndIndex { get; set; }
}