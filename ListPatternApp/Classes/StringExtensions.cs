using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ListPatternApp.Classes;

public static partial class StringExtensions
{

    [DebuggerStepThrough]
    public static string SplitCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    [DebuggerStepThrough]
    public static bool ValidatePassword(string password)
        => PasswordRegEx().IsMatch(password);

    [DebuggerStepThrough]
    public static string StringBetweenQuotes(this string sender)
    {
        var match = QuotedStringRegEx().Match(sender);

        return match.Success ? match.Groups[1].Value : sender;

    }

    [DebuggerStepThrough]
    public static string NextValue(string sender)
    {
        var value = NumericSuffixRegEx().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }

    public static string MaskCreditCardNumber(this string sender, char maskCharacter = 'X')
    {
        if (string.IsNullOrEmpty(sender))
        {
            return sender;
        }

        return CreditCardMaskRegEx().Replace(sender, match =>
        {
            string digits = string.Concat(match.Value.Where(char.IsDigit));

            return digits.Length is 16 or 15
                ? new string(maskCharacter, digits.Length - 4) + digits[^4..]
                : match.Value;
        });
    }


}