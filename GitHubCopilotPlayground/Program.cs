using GitHubCopilotPlayground.Classes;


namespace GitHubCopilotPlayground;

internal partial class Program
{
    static void Main(string[] args)
    {
        decimal number = 123.4521234m;
        Console.WriteLine(number.Left());
        Console.WriteLine(number.RightAsInt());
        Console.WriteLine(number.RightAsDecimal());



        var test = number.GetScale1();
        
        Console.WriteLine(test);
        Console.WriteLine(number.GetScale2());

    
        Console.ReadLine();
    }



}