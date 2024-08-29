using FindInterfaces.Classes;
using Spectre.Console;

namespace FindInterfaces;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = "Find Interfaces in Solution";

        AnsiConsole.MarkupLine("[green]Working...[/]");
        
        var list = await Helpers.FindInterfacesInSolution();

        foreach (var file in list)
        {
            if (file is null)
                continue;

            var parts = file.SplitStringOnLastBackslash();
            if (parts.Length == 2)
            {
                AnsiConsole.MarkupLine($"    [skyblue3]{parts[0]}[/]\\[orchid]{parts[1]}[/]");
            }
        }

        AnsiConsole.MarkupLine("[green]Done[/]");
        Console.ReadLine();
    }
}
