using System.Globalization;
using IndexMonths.Models;

namespace IndexMonths.Classes;

class Helpers
{
    public static List<string> MonthNames() => 
        DateTimeFormatInfo.CurrentInfo!.MonthNames[..^1].ToList();

    public static List<ElementContainer<T>> RangeDetails<T>(List<T> list) =>
        list.Select((element, index) => new ElementContainer<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index], true),
            MonthIndex = index + 1
        }).ToList();



}

