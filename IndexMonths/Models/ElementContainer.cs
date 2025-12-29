namespace IndexMonths.Models;

public class ElementContainer<T>
{
    public T Value { get; set; }
    public Index StartIndex { get; set; }
    public Index EndIndex { get; set; }
    public int MonthIndex { get; set; }
    public string[] ItemArray => new[]
    {
        Value.ToString(),
        MonthIndex.ToString(),
        StartIndex.ToString(),
        EndIndex.ToString()
    };
}