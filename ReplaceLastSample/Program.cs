using ReplaceLastSample.Classes;

namespace ReplaceLastSample;

internal partial class Program
{
    static void Main(string[] args)
    {

        var paragraph = """
                   Unlike your console application, The host builder will register user secrets 
                   only if your application runs in development mode. Developers like you don’t usually 
                   use user secrets outside local development scenarios. There are other mechanisms to 
                   provide secrets to your application that are easier to manage in a production environment.
                   """;
        //                    ^
        //                    |
        //                    |

        // replace last occurrence of secrets
        var result = paragraph.ReplaceLast("secrets", "SECRETS");

        // use color to easily see the change
        result = result.ReplaceLast("SECRETS", "[cyan]SECRETS[/]");
        AnsiConsole.MarkupLine(result);
        Console.WriteLine();

        var sentence = "This is a     test          sentence.";
        Console.WriteLine(sentence);
        Console.WriteLine($"'{sentence.RemoveExtraSpaces()}'");

        Console.ReadLine();
    }
}