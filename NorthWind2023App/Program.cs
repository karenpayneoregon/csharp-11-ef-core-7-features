using NorthWind2023App.Classes;

namespace NorthWind2023App;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        // known to exists
        var order = await NorthOperations.GetOrder(10251);
        Console.WriteLine($"{order.OrderDate}");
        var customers = await NorthOperations.GetCustomers();

        DumpOptions options = new DumpOptions
        {
            DumpStyle = DumpStyle.CSharp,
            //MaxLevel = 2
        };
        Console.WriteLine(ObjectDumper.Dump(customers, DumpStyle.CSharp));

        await File.WriteAllTextAsync("Dump.txt", ObjectDumper.Dump(customers, DumpStyle.CSharp));

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        //Console.ReadLine();
    }
}