using BogusProperGenderEntityApp.Models;
using Microsoft.Extensions.DependencyInjection;

using ConsoleConfigurationLibrary.Classes;

namespace BogusProperGenderEntityApp.Classes;

/// <summary>
/// Configure services for obtaining database connection string and setting 
/// </summary>
internal class ApplicationConfiguration
{

    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Configuration.JsonRoot().GetSection(nameof(ConnectionStrings)));
            services.Configure<EntityConfiguration>(Configuration.JsonRoot().GetSection(nameof(EntityConfiguration)));

            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


