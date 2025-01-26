using Microsoft.Extensions.DependencyInjection;
using PayneServiceLibrary.Classes.Configuration;
using static PayneServiceLibrary.Classes.Configuration.ApplicationConfiguration;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace PayneServiceLibrary;
/// <summary>
/// Represents the main configuration class for the PayneServiceLibrary.
/// </summary>
/// <remarks>
/// This class is responsible for configuring and initializing the application's services and settings.
/// It provides methods to set up the dependency injection container and retrieve necessary configuration
/// details, such as connection strings and entity settings, ensuring the application is properly prepared
/// for execution.
/// </remarks>
public class MainConfiguration
{
    /// <summary>
    /// Configures and initializes the application's services and settings.
    /// </summary>
    /// <remarks>
    /// This method sets up the application's dependency injection container by configuring services
    /// and retrieving necessary configuration settings, such as connection strings and entity settings.
    /// It ensures that the application is properly initialized before execution.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation of setting up the application.
    /// </returns>
    public static async Task Setup()
    {
        var services = ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        var setupServices = serviceProvider.GetRequiredService<SetupServices>();
        setupServices.GetConnectionStrings();
        setupServices.GetEntitySettings();
    }

}
