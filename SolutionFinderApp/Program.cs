using SolutionFinderApp.Classes;
using System.Text.Json;
using SolutionFinderApp.Models;

namespace SolutionFinderApp;

internal partial class Program
{

    private static async Task Main(string[] args)
    {
        /*
         * Set this to a path with one or more Visual Studio solutions
         */
        const string path = @"C:\DotnetLand\VS2022";

        const ScanOptions option = ScanOptions.WarningsOnly;

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
        using (var spinner = new KB.Spinner($"Scanning {path} for warnings"))
        {
            spinner.Start();
            await GlobSolutions.GetSolutionNames(path, option);
        }


        List<Solutions> data = GlobSolutions.Solutions;

        var noWarnings = data.Where(x => x.Projects.Count > 0).ToList();

        if (option == ScanOptions.All)
        {
            await File.WriteAllTextAsync("Results.json", JsonSerializer.Serialize(data,Options));
        }
        else
        {
            await File.WriteAllTextAsync("NoWarnings.json", JsonSerializer.Serialize(noWarnings, Options));
        }
        
        Console.Clear();
        AnsiConsole.MarkupLine($"[cyan]Total solutions:[/] [yellow]{data.Count}[/] [cyan]in[/] [yellow]{path}[/]");
        
        var projectCount = data.Sum(solution => solution.Projects.Count);
        AnsiConsole.MarkupLine($"[cyan]Total projects :[/] [yellow]{projectCount}[/][cyan] needing attention[/]");


        Console.ReadLine();
    }

    /// <summary>
    /// Gets the options for JSON serialization, configured to format the JSON output with indentation.
    /// </summary>
    /// <value>
    /// The <see cref="JsonSerializerOptions"/> instance configured with <c>WriteIndented</c> set to <c>true</c>.
    /// </value>
    private static JsonSerializerOptions Options => new() { WriteIndented = true };
}