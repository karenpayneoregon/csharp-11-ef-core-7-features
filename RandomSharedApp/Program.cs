using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RandomSharedApp.Classes;
using RandomSharedApp.Models;
// ReSharper disable MethodOverloadWithOptionalParameter

namespace RandomSharedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        OverloadResolutionPriorityDemo.DisplayInvoice("ABC0");
        
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
            AnsiConsole.MarkupLine($"[cyan]Pass[/] [yellow]{index + 1}[/]");

            Human[] items = Random.Shared.GetItems<Human>(CollectionsMarshal.AsSpan(people), 3);


            await Task.Delay(300);

            foreach (var human in items)
            {
                Console.WriteLine($"{human.Id,-5}{human.FirstName,-15}{human.LastName}");
            }

            Console.WriteLine();

        }




    }


}





public static class MathHelper
{
    [OverloadResolutionPriority(1)] // This overload will have a lower priority
    public static void Calculate(double number = 2)
    {
        Console.WriteLine("Double overload called with value: " + number);
    }

    [OverloadResolutionPriority(2)] // This overload will be favored when both match
    public static void Calculate(int number = 10)
    {
        Console.WriteLine("Integer overload called with value: " + number);
    }
}