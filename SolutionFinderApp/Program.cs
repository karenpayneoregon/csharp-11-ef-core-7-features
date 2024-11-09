using SolutionFinderApp.Classes;
using System.Text.Json;

namespace SolutionFinderApp;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        var path = @"C:\OED\DotnetLand\VS2022";
        using (var spinner = new KB.Spinner($"Scanning {path}"))
        {
            spinner.Start();
            await SolutionExamples.GetSolutionNames(path);
            spinner.Succeed("Done");
        }

        var data = SolutionExamples.Solutions;
        await File.WriteAllTextAsync("Results.json", JsonSerializer.Serialize(data,Options));
        Console.Clear();
        Console.WriteLine(data.Count);
        Console.ReadLine();
    }

    private static JsonSerializerOptions Options =>
        new()
        {
            WriteIndented = true
        };
}