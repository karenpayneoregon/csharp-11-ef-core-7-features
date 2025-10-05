using System.Text.RegularExpressions;

namespace ExperimentsApp;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> items = ["Item001", "Item002", "Item009", "Item010", "Item099"];

        foreach (var item in items)
        {
            string next = Helpers.NextValue1(item);
            Console.WriteLine($"{item} -> {next}");
        }

        Console.ReadLine();
    }
}

/// <summary>
/// Provides helper methods for generating the next value in a sequence.
/// </summary>
/// <remarks>
/// Both methods have prechecks to ensure the input is valid and not null or empty.
/// </remarks>
public static partial class Helpers
{
    public static string NextValue1(string sender, int incrementBy = 1)
    {
        var index = sender.Length - 1;
        while (index >= 0 && char.IsDigit(sender[index]))
            index--;

        if (index == sender.Length - 1)
            return sender + incrementBy.ToString();

        var numberPart = sender[(index + 1)..];
        var prefix = sender[..(index + 1)];

        var number = long.Parse(numberPart);
        var incremented = number + incrementBy;

        var resultNumber = incremented.ToString().PadLeft(numberPart.Length, '0');

        return prefix + resultNumber;
    }

    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;

        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}
