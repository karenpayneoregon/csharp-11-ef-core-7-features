using Serilog;
using Serilog.Events;
using SeriLogThemesLibrary;

namespace RazorHasData.Classes;
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
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }
}


