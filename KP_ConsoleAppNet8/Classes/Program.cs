using KP_ConsoleAppNet8.Classes;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace KP_ConsoleAppNet8;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}
