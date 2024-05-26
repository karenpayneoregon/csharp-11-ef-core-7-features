using GitHubCopilotPlayground.Classes;


namespace GitHubCopilotPlayground;

internal partial class Program
{
    static void Main(string[] args)
    {
        decimal number = 123.4521234m;
        Console.WriteLine(number.DecimalRemainder());

        var test = number.GetScale();
        //AnsiConsole.MarkupLine($"[yellow]After decimal[/] {valueAfterDecimalSeparator}");
        Console.WriteLine(test);

        Console.ReadLine();
    }



}