using System.Text.RegularExpressions;

namespace QuestionOfTheDay.Extensions;



public static class StringExtensions
{
    // remove double spaces
    public static string RemoveExtraSpaces(this string sender, bool trimEnd = false)
    {
        const RegexOptions options = RegexOptions.None;
        var regex = new Regex("[ ]{2,}", options);
        var result = regex.Replace(sender, " ");

        return trimEnd ? result.TrimEnd() : result;

    }

    // trim end for specific character
    public static string TrimLastCharacter(this string sender)
        => string.IsNullOrWhiteSpace(sender) ?
            sender :
            sender[..^1];



    // replace last occurrence with replacement.
    public static string ReplaceLastOccurrence(this string sender, string find, string replace)
    {
        int place = sender.LastIndexOf(find, StringComparison.Ordinal);
        return place == -1 ?
            sender :
            sender.Remove(place, find.Length)
                .Insert(place, replace);
    }
}



