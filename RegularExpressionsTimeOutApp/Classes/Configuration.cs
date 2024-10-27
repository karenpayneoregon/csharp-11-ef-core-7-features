using Microsoft.Extensions.Configuration;

namespace RegularExpressionsTimeOutApp.Classes;
public static class Configuration
{
    /// <summary>
    /// Builds and returns the application's configuration root.
    /// </summary>
    /// <returns>An <see cref="IConfigurationRoot"/> object representing the application's configuration.</returns>
    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    /// <summary>
    /// Reads a configuration section and converts it to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the configuration section will be converted.</typeparam>
    /// <param name="sectionName">The name of the configuration section to read.</param>
    /// <returns>An instance of <typeparamref name="T"/> representing the configuration section.</returns>
    public static T ReadSection<T>(string sectionName)
        => ConfigurationRoot().GetSection(sectionName).Get<T>();
}
