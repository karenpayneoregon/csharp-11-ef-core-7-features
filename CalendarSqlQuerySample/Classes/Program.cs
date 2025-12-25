using CalendarSqlQuerySample.Classes.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

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

        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        Console.InputEncoding = Encoding.UTF8;
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
