namespace IndexMonths.Models;
public partial class ElementContainer<T>
{
    public string[] ItemArray =>
    [
        Value.ToString(),
        Index.ToString(),
        StartIndex.ToString(),
        EndIndex.ToString()
    ];
}
