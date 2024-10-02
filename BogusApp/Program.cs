using BogusApp.Classes;

namespace BogusApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var list = BogusOperations.Items(10);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }


        AnsiConsole.MarkupLine("[yellow]Press a key...[/]");

        Console.ReadLine();
    }

}