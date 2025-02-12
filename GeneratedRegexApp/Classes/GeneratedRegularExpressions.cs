using System.Text.RegularExpressions;

namespace GeneratedRegexApp.Classes;

// file: GeneratedRegularExpressions.cs
public static partial class StringExtensions
{
    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex PasswordRegEx();

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumericSuffixRegEx();

    [GeneratedRegex("[0-9][0-9 ]{13,}[0-9]")]
    private static partial Regex CreditCardMaskRegEx();

    [GeneratedRegex(@"^(?=\w{0,4}\p{L})(?=\w{0,4}\d)\w{5}")]
    private static partial Regex ValidateStringRegex();

    [GeneratedRegex(@"([A-Z]|[0-9]+)\z")]
    private static partial Regex IncrementSuffixRegex();

    [GeneratedRegex(@"\d+$")]
    private static partial Regex EndsWithNumberRegex();

}
