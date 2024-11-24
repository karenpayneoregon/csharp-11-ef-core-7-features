using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SolutionFinderApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Visual Studio scan for warnings";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
