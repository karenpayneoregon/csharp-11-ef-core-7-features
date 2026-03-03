namespace IndexMonths.Models;

public partial class ElementContainer<T>
{
    public T Value { get; set; }
    public Index StartIndex { get; set; }
    public Index EndIndex { get; set; }
    public int Index { get; set; }

}