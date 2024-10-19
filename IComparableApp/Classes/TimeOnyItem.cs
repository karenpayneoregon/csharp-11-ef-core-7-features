namespace IComparableApp.Classes;
public class TimeOnyItem
{
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public TimeOnly Value { get; set; }
}

public class MockedTimeOnlyItem
{
    public static List<TimeOnyItem> List =>
    [
        new() { Start = new(14, 0, 0), End = new(16, 0, 0), Value = new(15, 0, 0) },
        new() { Start = new(14, 0, 0), End = new(16, 0, 0), Value = new(19, 0, 0) },
        new() { Start = new(14, 0, 0), End = new(16, 0, 0), Value = new(15, 0, 0) }
    ];
}
