using System.Diagnostics;

namespace FormattableSamples.Classes;
public static class UtilityExtensions
{
    [DebuggerStepThrough]
    public static string ToYesNo(this bool value)
        => value ? "Yes" : "No";

    [DebuggerStepThrough]
    public static string SplitCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();
    }

    [DebuggerStepThrough]
    public static string StatementColors(string sql)
    {
        return sql.Replace("INSERT INTO", "[green]INSERT INTO[/]")
            .Replace("VALUES", "[green]VALUES[/]")
            .Replace("CAST", "[yellow]CAST[/]")
            .Replace("SELECT", "[green]SELECT[/]");
    }

    [DebuggerStepThrough]
    public static bool IsBetween<T>(this T value, T start, T end) where T : IComparable<T>
    {
        return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
    }
}

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> sender) 
        => sender is ICollection<T> collection ? collection.Count == 0 : !sender.Any();
}

public static class DateOnlyExtensions
{
    public static bool IsBetween(this DateOnly date, DateOnly startDate, DateOnly endDate)
    {
        return date >= startDate && date <= endDate;
    }
}
