using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.Configuration;

namespace RegularExpressionsTimeOutApp.Classes;

/// <summary>
/// Provides configuration-related functionalities for the RegularExpressionsTimeOutApp.
/// </summary>
/// <remarks>
/// JsonRoot() requires NuGet package ConsoleConfigurationLibrary
/// </remarks>
public static class Configuration
{
    /// <summary>
    /// Reads a configuration section and converts it to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the configuration section will be converted.</typeparam>
    /// <param name="sectionName">The name of the configuration section to read.</param>
    /// <returns>An instance of <typeparamref name="T"/> representing the configuration section.</returns>
    public static T ReadSection<T>(string sectionName)
        => JsonRoot().GetSection(sectionName).Get<T>();
}
