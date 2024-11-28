using System.Text.RegularExpressions;

namespace Net9Features;

internal class Program
{
    static void Main(string[] args)
    {

        const string sentence = "a b c d the";
        Console.WriteLine(Helpers.ContainsFiveCharWord(sentence));
 
        Console.ReadLine();
    }
}

public static partial class Helpers
{
    /// <summary>
    /// Determines whether the specified input string contains a word with exactly five characters.
    /// </summary>
    /// <param name="input">The input string to be checked for a five-character word.</param>
    /// <returns>
    /// <c>true</c> if the input string contains a word with exactly five characters; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsFiveCharWord(string input) => 
        !string.IsNullOrEmpty(input) && FiveCharWord().IsMatch(input);


    [GeneratedRegex(@"^\s*\b\w+\b(\s+\b\w+\b){4}\s*$")]
    private static partial Regex FiveCharWord();
}