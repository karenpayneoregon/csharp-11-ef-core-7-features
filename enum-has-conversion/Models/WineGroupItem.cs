namespace EnumHasConversion.Models;

public class WineGroupItem
{
    public WineType Key { get; }
    public List<Wine> List { get; }

    public WineGroupItem(WineType key, List<Wine> list)
    {
        Key = key;
        List = list;
    }
}