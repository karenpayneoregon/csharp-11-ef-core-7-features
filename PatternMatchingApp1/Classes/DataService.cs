namespace PatternMatchingApp1.Classes;
internal class DataService
{

    public static List<DateOnly> MonthList()
    {
        List<DateOnly> list = new();
        for (int index = 1; index < 5; index++)
        {
            list.AddRange(DateOnlyMethods.GetMonthDays(year: 2024, month: index));
        }

        return list;
    }

}