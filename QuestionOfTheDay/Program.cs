using System.Security.Cryptography.X509Certificates;
using Bogus;
using QuestionOfTheDay.Classes;
using QuestionOfTheDay.Extensions;
using QuestionOfTheDay.Models;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {
        string sentence = "Hello    World  nice to be   here      ";
        Console.WriteLine($"'{sentence}'");
        Console.WriteLine($"'{sentence.RemoveExtraSpaces().TrimLastCharacter()}'");
        Console.WriteLine($"'{sentence.RemoveExtraSpaces().ReplaceLastOccurrence(" ", "!!!")}'");
        
        ExitPrompt();
    }
}