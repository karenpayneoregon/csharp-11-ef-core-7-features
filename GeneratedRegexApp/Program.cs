using GeneratedRegexApp.Classes;
using System.Text.Json;
using System.Text.RegularExpressions;
using StringExtensions = GeneratedRegexApp.Classes.StringExtensions;


namespace GeneratedRegexApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Samples.CreditCardMask();
        Samples.ValidatePassword();
        Samples.NextValueExample();

        Samples.ValidateString();

        SpectreConsoleHelpers.ExitPrompt();
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
            var newValue = StringExtensions.NextValue(invoices[index].Number);
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