using System.Text.RegularExpressions;

namespace GeneratedRegexApp.Classes;
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
}
