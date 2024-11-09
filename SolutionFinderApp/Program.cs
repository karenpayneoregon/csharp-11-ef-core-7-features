using System.Diagnostics;
using SolutionFinderApp.Classes;
using System.Text.Json;
using SolutionFinderApp.Models;

namespace SolutionFinderApp;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        const string path = @"C:\OED\DotnetLand\VS2022";

        if (!Directory.Exists(path))
        {
            AnsiConsole.MarkupLine($"[red]The specified path does not exist:[/] [yellow]{path}[/]");
            Console.ReadLine();
            return;
        }

        /*
         * Scan folder with a simple spinner to apse the user
         * KP alias is defined in the project file
         */
        using (var spinner = new KB.Spinner($"Scanning {path}"))
        {
            spinner.Start();
            await GlobSolutions.GetSolutionNames(path);
        }


        List<Solutions> data = GlobSolutions.Solutions;
  
        await File.WriteAllTextAsync("Results.json", JsonSerializer.Serialize(data,Options));
        Console.Clear();
        AnsiConsole.MarkupLine($"[cyan]Total solutions:[/] [yellow]{data.Count}[/] [cyan]in[/] [yellow]{path}[/]");
        
        var projectCount = data.Sum(solution => solution.Projects.Count);
        AnsiConsole.MarkupLine($"[cyan]Total projects:[/] [yellow]{projectCount}[/]");


        Console.ReadLine();
    }

    private static JsonSerializerOptions Options => new() { WriteIndented = true };
}