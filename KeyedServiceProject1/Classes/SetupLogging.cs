using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using SeriLogThemesLibrary;
using static System.DateTime;

namespace KeyedServiceProject1.Classes;
/// <summary>
/// For setting up SeriLog to keep Program.Main clean and allows code to be easily copied to other projects.
/// </summary>
public class SetupLogging
{
    /// <summary>
    /// Configure SeriLog
    /// </summary>
    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Extensions.Hosting", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.Hosting", LogEventLevel.Information)
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}


