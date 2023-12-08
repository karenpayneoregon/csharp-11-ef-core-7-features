using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace NaturalSortApp;
internal partial class Program
{

    private static string _filesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
    [ModuleInitializer]
    public static void Init()
    {

        if (!Directory.Exists(_filesFolder))
        {
            Directory.CreateDirectory(_filesFolder);
        }

        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static void CleanUp()
    {
        var list = Directory.GetFiles(_filesFolder).ToList();
        if (list.Count > 0)
        {
            foreach (var fileName in list)
            {
                File.Delete(fileName);
            }
        }
    }
}
