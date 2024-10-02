using Bogus;
using Bogus.Bson;
using BogusApp.DataSets;

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


        AnsiConsole.MarkupLine("[yellow]Hello[/]");

        Console.ReadLine();
    }

}

public record FileContainer
{
    public string FileName { get; set; }
    public sealed override string ToString() => FileName;
}

internal class BogusOperations
{
    public static List<FileContainer> Items(int count = 10)
    {
        return Folders.File().Generate(count);
    }
}