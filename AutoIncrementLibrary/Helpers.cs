using System.Text.RegularExpressions;

namespace AutoIncrementLibrary;

public partial class Helpers
{

    /// <summary>
    /// Wrapper for NextValue as some may like this name
    /// </summary>
    public static string NextInvoiceNumber(string sender)
        => NextValue(sender);


    /// <summary>
    /// Wrapper for NextValue as some may like this name
    /// </summary>
    public static string NextInvoiceNumber(string sender, int incrementBy)
        => NextValue(sender, incrementBy);


    /// <summary>
    /// Generates the next value for the given ASD123 which then be ASD124.
    /// </summary>
    /// <param name="sender">The sender value.</param>
    /// <param name="incrementBy">The value to increment by (default is 1).</param>
    /// <returns>The next value for the given sender.</returns>
    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    /// <summary>
    /// Gets the regular expression pattern for matching numbers at the end of a string.
    /// </summary>
    /// <returns>The regular expression pattern.</returns>
    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}
