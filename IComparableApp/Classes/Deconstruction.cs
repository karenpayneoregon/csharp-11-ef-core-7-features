namespace IComparableApp.Classes;

public class Deconstruction
{
    private static ItemContainer[] _responseKeys =
    [
        new ItemContainer(1, "A", "Yes"),
        new ItemContainer(2, "B", "No"),
        new ItemContainer(3, "C", "Yes"),
        new ItemContainer(4, "A", "No")
    ];

    private static ItemsContainer[] _responseKeys2 =
    [
        new ItemsContainer(1, "A", "Yes"),
        new ItemsContainer(2, "B", "No"),
        new ItemsContainer(3, "C", "Yes"),
        new ItemsContainer(4, "A", "No")
    ];


    public static ItemContainer Demo1(int id)
        => _responseKeys.FirstOrDefault(x => x.Id == id);

    public static ItemsContainer Demo2(int id)
        => _responseKeys2.FirstOrDefault(x => x.Id == id);

    public static (int id, string contentId, string answer) Conventional(int id)
    {
        var item = _responseKeys.FirstOrDefault(x => x.Id == id);
        return (item.Id, item.ContentId, item.Answer);
    }

}