using System.ComponentModel;
using System.Runtime.InteropServices;
using RandomSharedApp.Classes;
using RandomSharedApp.Models;
using static RandomSharedApp.Classes.SpectreConsoleHelpers;
// ReSharper disable SuggestVarOrType_Elsewhere
#pragma warning disable IDE0305


namespace RandomSharedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Example();
        ExitPrompt();
    }
    private static async Task Example()
    {
        List<Human> people = BogusOperations.People(100);

        for (int index = 0; index < 10; index++)
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



