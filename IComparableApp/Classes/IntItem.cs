namespace IComparableApp.Classes;
public class IntItem
{
    public int Start { get; set; }
    public int End { get; set; }
    public int Value { get; set; }
}

public class MockedInt
{
    public static List<IntItem> List =>
    [
        new() { Start = 5, End = 15, Value = 9 },
        new() { Start = 5, End = 15, Value = 15 },
        new() { Start = 5, End = 15, Value = 99 }
    ];
}