using System.Text.RegularExpressions;

namespace AutoIncrementLibrary;

public class Helpers
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
    /// Given a string which ends with a number, increment the number by  <seealso cref="incrementBy"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="incrementBy">increment by</param>
    /// <returns>string with ending number incremented by <seealso cref="incrementBy"/></returns>
    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }
}