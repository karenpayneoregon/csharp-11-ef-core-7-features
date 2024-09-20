using AgeCalculator;

namespace QuestionOfTheDay.Extensions;
internal static class CustomExtensions
{
    public static Age CalculateAge(this DateOnly fromDate, DateTime toDate, bool isFeb28AYearCycleForLeapling = false)
    {
        var from = fromDate.ToDateTime(TimeOnly.Parse("00:00 AM"));

        if (from > toDate) throw new ArgumentOutOfRangeException(nameof(from),
            $"This {nameof(DateTime)} must be less or equal to '{nameof(toDate)}'.");

        return new Age(from, toDate, isFeb28AYearCycleForLeapling);
    }
}

