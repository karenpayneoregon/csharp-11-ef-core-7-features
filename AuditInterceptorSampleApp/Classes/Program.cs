using Serilog;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace AuditInterceptorSampleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()

            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "EF-Log.txt"),
                rollingInterval: RollingInterval.Minute,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        Console.Title = "Code sample: SaveChangesInterceptor";

        try
        {
            // may not work for everyone.
            Console.SetWindowSize(185, 40);
        }
        catch
        {
            // ignored
        }

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

    }
}
