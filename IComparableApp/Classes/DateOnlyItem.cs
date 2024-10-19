using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableApp.Classes;
public class DateOnlyItem
{
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    public DateOnly Value { get; set; }
}

public class MockedDateOnlyItem
{
    public static List<DateOnlyItem> List =>
    [
        new() { Start = new(2023, 11, 1), End = new(2023, 11, 22), Value = new(2023, 11, 22) },
        new() { Start = new(2024, 9, 1), End = new(2024, 9, 22), Value = new(2024, 9, 23) },
        new() { Start = new(2023, 11, 1), End = new(2023, 11, 22), Value = new(2023, 11, 22) }
    ];
}
