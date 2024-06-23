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
        await PeopleExample();
        ExitPrompt();
    }

    public static int[] GetRandomIntegers(params int[] listNumbers) 
        => Random.Shared.GetItems(listNumbers, listNumbers.Length);

    public static int[] GetRandomIntegers1(params int[] listNumbers)
        => listNumbers.OrderBy(x => Random.Shared.Next()).ToArray();

    private static async Task PeopleExample()
    {
        List<Human> people = BogusOperations
            .People(100)
            .OrderBy(x => x.LastName)
            .ToList();

        for (int index = 0; index < 10; index++)
        {
            AnsiConsole.MarkupLine($"[cyan]Pass[/] [yellow]{index +1}[/]");

            List<Human> items = Random.Shared
                .GetItems<Human>(CollectionsMarshal.AsSpan(people), 3)
                .ToList();

            await Task.Delay(300);

            foreach (var human in items)
            {
                Console.WriteLine($"{human.Id,-5}{human.FirstName,-15}{human.LastName}");
            }

            Console.WriteLine();
        }
    }
}



