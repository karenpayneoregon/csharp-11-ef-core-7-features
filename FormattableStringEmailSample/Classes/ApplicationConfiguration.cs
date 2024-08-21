using Microsoft.Extensions.DependencyInjection;

namespace FormattableStringEmailSample.Classes;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Configures the services for the application, here is just <see cref="EmailService"/>
    /// </summary>
    /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddTransient<EmailService>();
        return services;
    }
}


