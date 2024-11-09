using SolutionFinderApp.Classes;
using System.Text.Json;
using SolutionFinderApp.Models;

namespace SolutionFinderApp;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        var path = @"C:\OED\DotnetLand\VS2022";

        if (!Directory.Exists(path))
        {
            AnsiConsole.MarkupLine($"[red]The specified path does not exist:[/] [yellow]{path}[/]");
            Console.ReadLine();
            return;
        }

        using (var spinner = new KB.Spinner($"Scanning {path}"))
        {
            spinner.Start();
            await SolutionExamples.GetSolutionNames(path);
            spinner.Succeed("Done");
        }

        List<SolutionModel> data = SolutionExamples.Solutions;
        await File.WriteAllTextAsync("Results.json", JsonSerializer.Serialize(data,Options));
        Console.Clear();
        AnsiConsole.MarkupLine($"[cyan]Total solutions:[/] [yellow]{data.Count}[/] [cyan]in[/] [yellow]{path}[/]");
        Console.ReadLine();
    }

    private static JsonSerializerOptions Options => new() { WriteIndented = true };
}