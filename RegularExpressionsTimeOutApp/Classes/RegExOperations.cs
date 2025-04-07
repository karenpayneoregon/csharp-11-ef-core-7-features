using RegularExpressionsTimeOutApp.Models;

namespace RegularExpressionsTimeOutApp.Classes;

public class RegexOperations
{

    /// <summary>
    /// Retrieves the regular expression timeout value from the configuration.
    /// </summary>
    /// <returns>
    /// A <see cref="TimeSpan"/> representing the timeout value for regular expressions.
    /// </returns>
    /// <remarks>
    /// This method reads the "RegularExpressions" section from the configuration and returns the timeout value specified.
    /// </remarks>
    public static TimeSpan RegexTimeOut()
    {
        var timeOut = Configuration.ReadSection<RegularExpressions>(nameof(RegularExpressions));
        return timeOut.Timeout;
    }

    public static string _timeout => "REGEX_DEFAULT_MATCH_TIMEOUT";

    /// <summary>
    /// Sets the regular expression timeout value in the application domain data.
    /// </summary>
    /// <remarks>
    /// This method retrieves the timeout value from the configuration and sets it in the application domain data
    /// using a predefined key. The timeout value is used to limit the execution time of regular expressions.
    /// </remarks>
    public static void SetTimeout()
    {
        AppDomain.CurrentDomain.SetData(_timeout, TimeSpan.FromSeconds(RegexTimeOut().Seconds));
    }

    /// <summary>
    /// Retrieves the regular expression timeout value from the application domain data.
    /// </summary>
    /// <returns>
    /// A <see cref="TimeSpan"/> representing the timeout value if it is set; otherwise, <c>null</c>.
    /// </returns>
    public static TimeSpan? GetTimeout() 
        => (TimeSpan?)AppDomain.CurrentDomain.GetData(_timeout);
}