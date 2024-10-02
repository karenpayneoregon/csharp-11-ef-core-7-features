using System.Runtime.InteropServices;
using RandomSharedApp.Classes;
using RandomSharedApp.Models;

namespace RandomSharedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Example();
        Console.ReadLine();
    }
    /// <summary>
    /// Executes an example asynchronous operation that generates a list of people,
    /// selects random items from the list, and prints their details to the console.
    /// </summary>
    private static async Task Example()
    {
        List<Human> people = BogusOperations.People(100);

        for (var index = 0; index < 10; index++)
        {
            AnsiConsole.MarkupLine($"[cyan]Pass[/] [yellow]{index +1}[/]");

            var items = Random.Shared.GetItems<Human>(CollectionsMarshal.AsSpan(people), 3);

            
            await Task.Delay(300);

            foreach (var human in items)
            {
                Console.WriteLine($"{human.Id,-5}{human.FirstName,-15}{human.LastName}");
            }

            Console.WriteLine();
        }
    }
}



