using System.Globalization;
using System.Text.RegularExpressions;
using static GeneratedRegexSamplesApp.Classes.SpectreConsoleHelpers;

namespace GeneratedRegexSamplesApp.Classes;
internal static partial class Examples
{
    /// <summary>
    /// - Get items with a product in the URL, ignore items with invoice in the URL.
    /// - Get the product id from the URL.
    /// </summary>
    /// <remarks>
    /// Not useful in a real-world scenario, but demonstrates how to use a generated regex.
    /// </remarks>
    public static void MatchProducts()
    {

        PrintCyan();

        const string items = """


                                 http://customdomain.com/product/123  *new product*
                                 https://customdomain.com/invoice/987
                                 https://customdomain.com/product/45 (product to remove)
                                 https://customdomain.com/product/999 
                                 http://customdomain.com/invoice/741


                                 """;


        MatchCollection matches = ProductUrlRegex().Matches(items);

        foreach (Match m in matches)
        {

            Console.WriteLine($"{m.Groups["scheme"].Value}" +
                              $"{m.Groups["host"].Value}" +
                              $"{m.Groups["path"].Value} - " +
                              $"{m.Groups["pid"].Value}");

        }

    }

    public static void ExtractDates()
    {

        PrintCyan();

        string input = @"\\SomeServer\HTTP\demo1\index.html 4 KB HTML File 2/19/2019 3:48:21 PM 2/19/2019 1:05:53 PM 2/19/2019 1:05:53 PM 5";

        const string format = "M/d/yyyy h:mm:ss tt";

        MatchCollection matches = DateRegex().Matches(input);

        foreach (Match match in matches)
        {
            var dateTime = DateTime.ParseExact(match.Value, format, CultureInfo.InvariantCulture);
            Console.WriteLine(dateTime);
        }
    }

    /// <summary>
    /// Masks the credit card number in the given text.
    /// </summary>
    /// <param name="text">The text containing the credit card number.</param>
    /// <returns>The text with the credit card number masked of the last four digits.</returns>
    public static string MaskCreditCardNumber(string text)
    {

        PrintCyan();

        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return CreditCardRegex().Replace(text, match =>
        {
            var digits = string.Concat(match.Value.Where(char.IsDigit));

            return digits.Length is 16 or 15
                ? new string('X', digits.Length - 4) + digits[^4..]
                : match.Value;
        });
    }

    /// <summary>
    /// Removes extra spaces from the specified string.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="trimEnd"></param>
    /// <returns></returns>
    public static string RemoveExtraSpaces(this string sender, bool trimEnd = false)
    {

#if DEBUG
        PrintCyan();
#endif

        var result = MultipleSpacesRegex().Replace(sender, " ");
        return trimEnd ? result.TrimEnd() : result;

    }

    [GeneratedRegex(@"(?<scheme>.+?://)(?<host>[0-9a-z\-\.]+)(?<path>/product/(?<pid>\d+))", 
        RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex ProductUrlRegex();

    [GeneratedRegex(@"\d{1,2}/\d{1,2}/\d{4} \d{1,2}:\d{2}:\d{2} [AP]M")]
    private static partial Regex DateRegex();

    [GeneratedRegex("[0-9][0-9 ]{13,}[0-9]")]
    private static partial Regex CreditCardRegex();
    [GeneratedRegex("[ ]{2,}", RegexOptions.None)]
    private static partial Regex MultipleSpacesRegex();
}
