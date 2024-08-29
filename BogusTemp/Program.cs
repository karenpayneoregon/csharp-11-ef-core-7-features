using BogusTemp.Classes;

namespace BogusTemp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var customers1 = MockedData.GetCustomersTimeOnlySoon(5);
        var customers2 = MockedData.GetCustomersTimeOnlyRecent(5);
        var customers3 = MockedData.GetCustomersTimeOnlyRandom(5);
        var customers4 = MockedData.GetCustomersDateOnlyTimeOnlyRecent(5);
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}