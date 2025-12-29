using System.Globalization;
using IndexMonths.Models;

namespace IndexMonths.Classes;

public class Helpers
{
    public static List<string> MonthNames() => 
        DateTimeFormatInfo.CurrentInfo!.MonthNames[..^1].ToList();

    public static List<ElementContainer<T>> RangeDetails<T>(List<T> list) =>
        list.Select((element, index) => new ElementContainer<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(list.Count - index - 1, true),
            Index = index + 1
        }).ToList();
}

