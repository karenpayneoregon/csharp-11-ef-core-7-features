using NorthWind2023App.Classes;

namespace NorthWind2023App;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        // known to exists
        var order = await NorthOperations.GetOrder(10251);
        Console.WriteLine($"{order.OrderDate}");
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}