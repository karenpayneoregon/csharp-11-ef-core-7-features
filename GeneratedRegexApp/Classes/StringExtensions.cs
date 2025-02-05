using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GeneratedRegexApp.Classes;

public static partial class StringExtensions
{
    /// <summary>
    /// Splits the given string into separate words based on the case of the letters.
    /// </summary>
    /// <param name="sender">The string to split.</param>
    /// <returns>A new string with the words separated by spaces.</returns>
    [DebuggerStepThrough]
    public static string SplitCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    /// <summary>
    /// Validates the password based on a regular expression pattern.
    /// </summary>
    /// <param name="password">The password to validate.</param>
    /// <returns>True if the password is valid, otherwise false.</returns>
    [DebuggerStepThrough]
    public static bool ValidatePassword(this string password)
        => PasswordRegEx().IsMatch(password);

    public static bool ValidateString(this string input) 
        => ValidateStringRegex().IsMatch(input);


    /// <summary>
    /// Generates the next sequential value by incrementing the numeric suffix of the given string.
    /// </summary>
    /// <param name="sender">The input string containing a numeric suffix to be incremented.</param>
    /// <returns>A new string with the numeric suffix incremented by one, preserving the original length of the numeric part.</returns>
    /// <exception cref="FormatException">Thrown when the numeric suffix cannot be parsed as a valid number.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the numeric suffix is too large to be incremented within the bounds of a <see cref="long"/>.
    /// </exception>
    [DebuggerStepThrough]
    public static string NextValue(string sender)
    {
        var value = NumericSuffixRegEx().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }

  
    /// <summary>
    /// Increments the last alphanumeric segment of the specified input string.
    /// </summary>
    /// <param name="input">The input string containing the segment to increment.</param>
    /// <returns>
    /// A new string where the last alphanumeric segment is incremented. 
    /// If the segment is a letter, it is replaced with the next letter in the alphabet. 
    /// If the segment is a number, it is incremented by 1.
    /// </returns>
    /// <remarks>
    /// This method uses a regular expression to identify the last alphanumeric segment 
    /// in the input string. If no such segment is found, the input string remains unchanged.
    /// </remarks>
    public static string Increment(string input) =>
        IncrementSuffixRegex().Replace(input, m => char.IsLetter(m.Value[0])
            ? ((char)(m.Value[0] + 1)).ToString()
            : (int.Parse(m.Value) + 1).ToString());


    /// <summary>
    /// Masks the credit card number in the given string by replacing the digits with a specified mask character.
    /// </summary>
    /// <param name="sender">The string containing the credit card number.</param>
    /// <param name="maskCharacter">The character used as a mask. Default is 'X'.</param>
    /// <returns>A new string with the credit card number masked.</returns>
    public static string MaskCreditCardNumber(this string sender, char maskCharacter = 'X')
    {
        if (string.IsNullOrEmpty(sender))
        {
            return sender;
        }

        return CreditCardMaskRegEx().Replace(sender, match =>
        {
            var digits = string.Concat(match.Value.Where(char.IsDigit));

            return digits.Length is 16 or 15
                ? new string(maskCharacter, digits.Length - 4) + digits[^4..]
                : match.Value;
        });
    }


}