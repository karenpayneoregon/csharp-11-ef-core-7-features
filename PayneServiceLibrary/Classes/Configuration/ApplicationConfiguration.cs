using Microsoft.Extensions.DependencyInjection;
using PayneServiceLibrary.Models.Configuration;

namespace PayneServiceLibrary.Classes.Configuration;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Configures and initializes the application's service collection.
    /// </summary>
    /// <remarks>
    /// This method sets up the dependency injection container by configuring services related to 
    /// connection strings and entity settings, and registering necessary services for the application.
    /// </remarks>
    /// <returns>
    /// A <see cref="ServiceCollection"/> instance containing the configured services.
    /// </returns>
    public static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

        static void ConfigureService(IServiceCollection services)
        {
            // [Config] is an alias setup in the project file
            services.Configure<ConnectionStrings>(Config.Configuration.JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            if (JsonHelpers.EntityConfigurationSectionExists())
            {
                services.Configure<EntityConfiguration>(Config.Configuration.JsonRoot()
                    .GetSection(nameof(EntityConfiguration)));
            }


            services.AddScoped<SetupServices>();
        }
    }
}


