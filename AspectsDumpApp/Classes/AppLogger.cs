#nullable disable
using AspectsDumpApp;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace AspectsDumpApp.Classes;

public sealed class AppLogger
{
    private static readonly Lazy<AppLogger> Lazy = new(() => new());
    public static AppLogger Instance => Lazy.Value;
    private static Logger _logger;
    public Logger Logger => _logger;
    private AppLogger()
    {
        // setup to read setting from Serilog.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Serilog.json", true, true)
            .Build();

        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

    }
}