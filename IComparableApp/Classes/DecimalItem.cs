namespace IComparableApp.Classes;
public class DecimalItem
{
    public decimal Start { get; set; }
    public decimal End { get; set; }
    public decimal Value { get; set; }
}
public class MockedDecimals
{
    public static List<DecimalItem> List =>
    [
        new() { Start = 5.5m, End = 15.5m, Value = 9.9m },
        new() { Start = 5.5m, End = 15.5m, Value = 15.5m },
        new() { Start = 5.5m, End = 15.5m, Value = 99.9m }
    ];
}
