using GitHubCopilotPlayground.Classes;


namespace GitHubCopilotPlayground;

internal partial class Program
{
    static void Main(string[] args)
    {
        decimal number = 123.4521234m;
        Console.WriteLine(number.Left());
        Console.WriteLine(number.RemainderAsInt());
        Console.WriteLine(number.RemainderAsDecimal());



        var test = number.GetScale();
        
        Console.WriteLine(test);
        Console.WriteLine(number.GetScaleAsInt());

    
        Console.ReadLine();
    }



}