using RandomSharedApp.Classes;
using static RandomSharedApp.Classes.SpectreConsoleHelpers;

namespace RandomSharedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await PeopleArrayExample();
        ExitPrompt();
    }

    public static int[] GetRandomIntegers(params int[] listNumbers) 
        => Random.Shared.GetItems(listNumbers, listNumbers.Length);

    public static int[] GetRandomIntegers1(params int[] listNumbers)
        => listNumbers.OrderBy(x => Random.Shared.Next()).ToArray();

    private static async Task PeopleArrayExample()
    {
        var people = BogusOperations
            .People(100)
            .OrderBy(x => x.LastName)
            .ToArray();

        for (int index = 0; index < 10; index++)
        {
            AnsiConsole.MarkupLine($"[cyan]Pass[/] " +
                                   $"[yellow]{index +1}[/]");
            var items = Random.Shared.GetItems(people, 3);
            await Task.Delay(500);
            foreach (var human in items)
            {
                Console.WriteLine($"{human.Id,-5}{human.FirstName,-20}" +
                                  $"{human.LastName}");
            }

            Console.WriteLine();
        }
    }
}
