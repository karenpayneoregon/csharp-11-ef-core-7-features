namespace EnumHasConversion.Models;

public class WineGroupItem
{
    public WineType Type { get; }
    public List<Wine> List { get; }

    public WineGroupItem(WineType key, List<Wine> list)
    {
        Type = key;
        List = list;
    }
}