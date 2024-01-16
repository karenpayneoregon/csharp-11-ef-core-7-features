namespace QuestionOfTheDay.Extensions;


    public static class CollectionExtensions
    {
        public static string JoinWithLastSeparator(this string[] sender, string token = "and")
            => string.Join(", ", sender.Take(sender.Length - 1)) + ((sender.Length <= 1) ? "" : $" {token} ") +
               sender.LastOrDefault();

        public static string JoinWithLastSeparator(this List<string> sender, string token = "and")
            => string.Join(", ", sender.Take(sender.Count - 1)) + (((sender.Count <= 1) ? "" : $" {token} ") +
                                                                    sender.LastOrDefault());

    // idea by @C8Luna modified as generic by @KarenPayneMVP via Twitter post
    public static string JoinWithLastSeparator1<T>(this List<T> sender, string token = "and") 
            => sender.Any() ? $"{string.Join(',', sender[..^1])} {token} {sender[^1]}" : "";
    }


