using Dumpify;
using System.Runtime.CompilerServices;
using Color = System.Drawing.Color;

// ReSharper disable once CheckNamespace
namespace ISetSamples;
internal partial class Program
{
    private static TableConfig _tableConfig = new() { ShowTableHeaders = false };

    [ModuleInitializer]
    public static void Init()
    {
        DumpConfig.Default.ColorConfig.TypeNameColor = new DumpColor(Color.Aqua);
        DumpConfig.Default.ColorConfig.NullValueColor = new DumpColor(Color.Red);
        DumpConfig.Default.ColorConfig.PropertyValueColor = new DumpColor(Color.DarkSalmon);
        DumpConfig.Default.ColorConfig.PropertyNameColor = new DumpColor(Color.DarkOrange);

        DumpConfig.Default.TypeNamingConfig.ShowTypeNames = false;

        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}

