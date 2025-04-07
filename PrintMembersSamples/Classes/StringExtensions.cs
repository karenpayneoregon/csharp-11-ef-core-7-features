namespace PrintMembersSamples.Classes;

public static class StringExtensions
{
    /// <summary>
    /// Masks a Social Security Number (SSN) by replacing all but the last few digits with a specified mask character.
    /// </summary>
    /// <param name="ssn">The Social Security Number to be masked. It should be a 9-digit string, optionally containing dashes.</param>
    /// <param name="digitsToShow">The number of digits to leave unmasked at the end of the SSN. Defaults to 3.</param>
    /// <param name="maskCharacter">The character used to mask the SSN. Defaults to 'X'.</param>
    /// <returns>
    /// A masked SSN string in the format "XXX-XX-1234", where the masked portion is replaced by the specified mask character.
    /// If the input is null, empty, or not a valid 9-digit SSN, the original input is returned.
    /// </returns>
    public static string MaskSsn(this string ssn, int digitsToShow = 3, char maskCharacter = 'X')
    {
        if (string.IsNullOrWhiteSpace(ssn)) return string.Empty;
        if (ssn.Contains(value: "-")) ssn = ssn.Replace("-", string.Empty);
        if (ssn.Length != 9) return ssn;

        const int ssnLength = 9;
        const string separator = "-";

        int maskLength = ssnLength - digitsToShow;
        int output = int.Parse(ssn.Replace(separator, string.Empty).Substring(maskLength, digitsToShow));

        var format = string.Empty;
        for (var index = 0; index < maskLength; index++)
        {
            format += maskCharacter;
        }

        for (var index = 0; index < digitsToShow; index++)
        {
            format += "0";
        }

        format = format.Insert(3, separator).Insert(6, separator);
        format = $"{{0:{format}}}";

        return string.Format(format, output);

    }
}