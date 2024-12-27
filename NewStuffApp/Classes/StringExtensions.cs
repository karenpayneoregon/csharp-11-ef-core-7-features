// ReSharper disable RedundantIfElseBlock
namespace NewStuffApp.Classes;


public static class StringExtensions
{
    public static string UpToFirstPeriodOrThreeWords(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var periodIndex = input.IndexOf('.');

        if (periodIndex >= 0)
        {
            return input[..(periodIndex + 1)];
        }
        else
        {
            var words = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words.Take(3));
        }
    }
}

