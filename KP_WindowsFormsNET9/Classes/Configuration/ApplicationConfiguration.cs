using KP_WindowsFormsNET9.Models.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace KP_WindowsFormsNET9.Classes.Configuration;
internal class ApplicationConfiguration
{

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Config.Configuration.JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.Configure<EntityConfiguration>(Config.Configuration.JsonRoot()
                .GetSection(nameof(EntityConfiguration)));

            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


