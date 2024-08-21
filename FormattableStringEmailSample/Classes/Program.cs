using FormattableStringEmailSample.Classes;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using FormattableStringEmailSample.Models;

// ReSharper disable once CheckNamespace
namespace FormattableStringEmailSample;
internal partial class Program
{
    /// <summary>
    /// - Set title
    /// - Center window
    /// </summary>
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "FormattableString Email Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Retrieves an instance of the EmailService from the service provider.
    /// </summary>
    /// <returns>An instance of the EmailService.</returns>
    private static async Task<EmailService> GetEmailService()
    {
        IServiceCollection services = ApplicationConfiguration.ConfigureServices();
        await using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<EmailService>();
        return service;
    }
}
