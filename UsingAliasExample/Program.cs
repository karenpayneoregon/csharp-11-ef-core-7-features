using UsingAliasExample.Classes;
using UsingAliasExample.Models;

namespace UsingAliasExample;

internal partial class Program
{
    static void Main(string[] args)
    {
        Baggage storage = new()
        {
            Type = UserType.Developer,
            People = MockedData.FromDataSource()
        };

        DumpBaggage(storage);

        ExitPrompt();
    }
    private static void DumpBaggage(Baggage item)
    {
        Console.WriteLine(item.Type);
        foreach (var person in item.People)
        {
            Console.WriteLine($"   {person.Value}");
        }
    }
}