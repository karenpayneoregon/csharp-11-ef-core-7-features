using GeneratedRegexApp.Classes;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static GeneratedRegexApp.Classes.StringExtensions;


namespace GeneratedRegexApp;

internal partial class Program
{
    private static void Main(string[] args)
    {



        var invoices = DisplayInvoice1("ZZZ200");
        foreach (var (index, invoice) in invoices.Index())
        {
            Console.WriteLine($"{index, -5}{invoice}");
        }

        string test1 = "Hello123";
        string test2 = "Hello World";
        string test3 = "Test99";
        string test4 = "";
        string test5 = "123";

        Console.WriteLine(test1.EndsWithNumber2()); // True
        Console.WriteLine(test2.EndsWithNumber2()); // False
        Console.WriteLine(test3.EndsWithNumber2()); // True
        Console.WriteLine(test4.EndsWithNumber2()); // False
        Console.WriteLine(test5.EndsWithNumber2()); // True

        //var singleInvoice = Increment("ZZZ200");



        //Samples.CreditCardMask();
        //Samples.ValidatePassword();
        //Samples.NextValueExample();

        //Samples.ValidateString();

        SpectreConsoleHelpers.ExitPrompt();
        return;

        static int WithDefault(int addTo = 2) => addTo + 1;

        static string Checker(string sender, string value = "A1") => string.IsNullOrEmpty(sender) ? value : sender;
    }

    /// <summary>
    /// Generates a list of sequential invoice identifiers starting from the specified invoice.
    /// </summary>
    /// <param name="invoice">The initial invoice identifier to start the sequence.</param>
    /// <param name="count">The number of sequential invoice identifiers to generate. Defaults to 500.</param>
    /// <returns>A list of sequential invoice identifiers.</returns>
    /// <exception cref="FormatException">Thrown when the numeric suffix of the invoice cannot be parsed as a valid number.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the numeric suffix of the invoice is too large to be incremented within the bounds of a <see cref="long"/>.
    /// </exception>
    public static List<string> DisplayInvoice1(string invoice, int count = 500)
    {
        List<string> invoices = [];
        var value = invoice;
        for (var index = 0; index < count; index++)
        {
            value = NextValue(value);
            invoices.Add(value);
        }

        return invoices;
    }
    public static List<string> DisplayInvoice2(string invoice, int count = 500)
    {
        List<string> invoices = [];
        var value = invoice;
        for (var index = 0; index < count; index++)
        {
            value = Increment(value);
            invoices.Add(value);
        }

        return invoices;
    }

}

public partial class Samples
{
    // https://stackoverflow.com/questions/79021453/check-for-at-least-1-digit-and-1-letter-within-the-first-n-characters
    public static void ValidateString()
    {
        Console.WriteLine();
        SpectreConsoleHelpers.PrintCyan();

        List<string> list = ["QAA1A", "QAAQB", "QAA1C", "QAA1D", "QAA1"];

        foreach (var item in list)
        {
            Console.WriteLine($"{item,-10}{item.ValidateString().ToYesNo()}");
        }
    }
    public static void ValidatePassword()
    {
        Console.WriteLine();
        SpectreConsoleHelpers.PrintCyan();
        var password = SpectreConsoleHelpers.GetPassword("Enter a password");
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Aborted");
        }
        else
        {
            Console.WriteLine(password.ValidatePassword() ? "Valid" : "Invalid");
        }

    }
    public static void CreditCardMask()
    {
        SpectreConsoleHelpers.PrintCyan();

        string[] items =
        [
            "CC# 123456789012345",
            "Credit Card 123456 7890 123456",
            "Text 1234 5678 9012 3456 Text",
            "Something 123 456 789 012 3456",
            "Not a card (too long): 12345689123456789123",
            "Just a value 123"
        ];

        var result = string.Join(Environment.NewLine, items
            .Select(ccn => $"{ccn,45} => {ccn.MaskCreditCardNumber()}"));
        Console.WriteLine(result);

    }

    public static void NextValueExample()
    {
        Console.WriteLine();
        SpectreConsoleHelpers.PrintCyan();

        List<Invoice> invoices = JsonSerializer.Deserialize<List<Invoice>>(
            File.ReadAllText("Invoices.json"));
        



        for (int index = 0; index < invoices.Count; index++)
        {
            var newValue = NextValue(invoices[index].Number);
            invoices[index].Number = newValue;
        }

        List<Invoice> originals = JsonSerializer.Deserialize<List<Invoice>>(
            File.ReadAllText("Invoices.json"));

        for (int index = 0; index < invoices.Count; index++)
        {
            Console.WriteLine($"{originals[index].Number,-20}{invoices[index].Number,-12}");
        }
    }

    [GeneratedRegex("^(?=\\w{0,4}\\p{L})(?=\\w{0,4}\\d)\\w{5}")]
    private static partial Regex ValidateStringRegex();
}