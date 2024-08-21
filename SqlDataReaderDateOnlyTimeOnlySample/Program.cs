using ConsoleConfigurationLibrary.Classes;
using SqlDataReaderDateOnlyTimeOnlySample.Classes;
using System.Data;
using System.Text.Json;

namespace SqlDataReaderDateOnlyTimeOnlySample;

internal partial class Program
{
    static async Task Main()
    {
        await RegisterConnectionServices.Configure();
        var people = await DataOperations.ReadPeople();
        AnsiConsole.MarkupLine($"[yellow]Count[/] {people.Count}");

        Console.ReadLine();
    }
}

