using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace PrintMembersSamples;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Records Print Members Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
