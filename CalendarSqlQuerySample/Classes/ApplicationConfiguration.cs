using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarSqlQuerySample.Classes;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Read sections from appsettings.json
    /// </summary>
    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(ConfigurationRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


