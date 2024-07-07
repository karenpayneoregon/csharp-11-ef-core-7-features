using Microsoft.Extensions.DependencyInjection;
using StringSyntaxWithEntityFrameworkCore.Models.Configuration;


namespace StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Sets up the services for connection string and should mock data be used
    /// </summary>
    /// <returns>ServiceCollection</returns>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Config.Configuration.JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.Configure<EntityConfiguration>(Config.Configuration.JsonRoot()
                .GetSection(nameof(EntityConfiguration)));

            services.Configure<ApplicationSetting>(Config.Configuration.JsonRoot()
                .GetSection(nameof(ApplicationSetting)));

            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


