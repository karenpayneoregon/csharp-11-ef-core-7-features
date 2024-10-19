namespace IComparableApp.Classes;
public class DateTimeItem
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime Value { get; set; }
}

public class MockedDateTimes
{
    public static List<DateTimeItem> List =>
    [
        new()
        {
            Start = new(2023, 11, 1, 14, 0, 0), 
            End = new(2023, 11, 22, 16, 0, 0), 
            Value = new(2023, 11, 22, 15, 0, 0)
        },
        new()
        {
            Start = new(2024, 9, 1, 14, 0, 0),
            End = new(2024, 9, 22, 16, 0, 0),
            Value = new(2024, 9, 23, 15, 0, 0)
        },
        new()
        {
            Start = new(2023, 11, 1, 14, 0, 0),
            End = new(2023, 11, 22, 16, 0, 0),
            Value = new(2023, 11, 22, 15, 0, 0)
        }
    ];
}
