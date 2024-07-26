using BogusProperGenderEntityApp.Models.Configurations;
using Microsoft.Extensions.DependencyInjection;

using static ConsoleConfigurationLibrary.Classes.Configuration;

namespace BogusProperGenderEntityApp.Classes.Configurations;

/// <summary>
/// Configure services for obtaining database connection string and setting
/// </summary>
internal class ApplicationConfiguration
{
    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <returns>The configured service collection.</returns>
    /// <remarks>
    /// <see cref="JsonRoot"/> reads data from appsettings.json
    /// </remarks>
    public static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

        static void ConfigureService(IServiceCollection services)
        {
            services.Configure<ConnectionStrings>(JsonRoot().GetSection(nameof(ConnectionStrings)));
            services.Configure<EntityConfiguration>(JsonRoot().GetSection(nameof(EntityConfiguration)));

            services.AddTransient<SetupServices>();
        }
    }
}


