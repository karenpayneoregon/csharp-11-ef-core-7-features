namespace QuestionOfTheDay.Extensions;


public static class CollectionExtensions
{
    public static string JoinWithLastSeparator(this string[] sender, string token = "and")
        => string.Join(", ", sender.Take(sender.Length - 1)) + (((sender.Length <= 1) ? "" : $" {token} ") +
                                                                sender.LastOrDefault());

    public static string JoinWithLastSeparator(this List<string> sender, string token = "and")
        => string.Join(", ", sender.Take(sender.Count - 1)) + (((sender.Count <= 1) ? "" : $" {token} ") +
                                                                sender.LastOrDefault());
}
