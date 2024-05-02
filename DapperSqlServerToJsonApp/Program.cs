
using DapperSqlServerToJsonApp.Classes;

namespace DapperSqlServerToJsonApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        CustomersOperations operations = new();
        operations.ToJson();
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}