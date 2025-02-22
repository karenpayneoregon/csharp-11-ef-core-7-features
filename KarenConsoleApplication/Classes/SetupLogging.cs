using System;
using System.IO;
using Serilog;

namespace KarenConsoleApplication.Classes;

#pragma warning disable CS8602
public class SetupLogging
{
    /// <summary>
    /// Configures and initializes the logging system for the application.
    /// </summary>
    /// <remarks>
    /// This method sets up a logger using Serilog with a verbose logging level.
    /// Logs are written to a file located in the "LogFiles" directory within the application's base directory.
    /// The log file is named based on the current date and includes a custom output template.
    /// </remarks>  
    public static void Initialize()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month:D2}-{DateTime.Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}