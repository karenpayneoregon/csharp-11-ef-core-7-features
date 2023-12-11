namespace PatternMatchingApp1.Classes;
internal class DataService
{

    public static List<DateOnly> MonthList()
    {
        List<DateOnly> list = new List<DateOnly>();
        for (int index = 1; index < 5; index++)
        {
            list.AddRange(DateOnlyMethods.GetMonthDays(index, 2024));
        }

        return list;
    }

}