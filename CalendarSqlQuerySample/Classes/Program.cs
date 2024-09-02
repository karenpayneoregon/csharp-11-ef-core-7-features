using CalendarSqlQuerySample.Classes;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace CalendarSqlQuerySample;

internal partial class Program
{
    /// <summary>
    /// Initializes the program.
    /// </summary>
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Sets up service for connection string.
    /// </summary>
    private static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}
