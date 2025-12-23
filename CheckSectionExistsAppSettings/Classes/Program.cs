using System.Runtime.CompilerServices;
using CheckSectionExistsAppSettings.Classes;

// ReSharper disable once CheckNamespace
namespace CheckSectionExistsAppSettings;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        SetupLogging.Development();
    }
}
