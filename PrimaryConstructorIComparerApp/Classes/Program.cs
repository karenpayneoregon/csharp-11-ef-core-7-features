using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace PrimaryConstructorIComparerApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "IComparer Code sample";

        if (OperatingSystem.IsWindows())
        {
            Console.SetWindowSize(40, 20);
        }
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
