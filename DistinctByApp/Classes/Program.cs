using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace DistinctByApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "DistinctBy code samples";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
