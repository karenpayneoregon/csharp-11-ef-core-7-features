using System.Text.Json;

namespace PayneServiceLibrary.Classes;
/// <summary>
/// Provides utility methods for validating the presence of specific sections 
/// in the "appsettings.json" configuration file.
/// </summary>
/// <remarks>
/// This class is designed to assist in ensuring that critical configuration 
/// sections, such as "EntityConfiguration" and "ConnectionStrings", are  present in
/// the application's configuration file. These checks are  essential for maintaining
/// the integrity of application setup and  preventing runtime errors due to missing configurations.
/// </remarks>
public class JsonHelpers
{
    /// <summary>
    /// Gets the name of the configuration file used for validating the presence of specific sections.
    /// </summary>
    /// <value>
    /// The name of the configuration file, which is "appsettings.json" or this can be changed to a development version.
    /// </value>
    /// <remarks>
    /// This property provides the default file name for the application's configuration file, 
    /// which is utilized by methods in the <see cref="JsonHelpers"/> class to perform validation checks.
    /// </remarks>
    private static string FileName => "appsettings.json";

    /// <summary>
    /// Determines whether the "EntityConfiguration" section exists in the "appsettings.json" file.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the "EntityConfiguration" section exists; otherwise, <c>false</c>.
    /// </returns>
    public static bool EntityConfigurationSectionExists()
    {
        string jsonContent = File.ReadAllText(FileName);
        using JsonDocument doc = JsonDocument.Parse(jsonContent);

        return doc.RootElement.TryGetProperty("EntityConfiguration", out _);
    }

    /// <summary>
    /// Determines whether the "ConnectionStrings" section exists in the "appsettings.json" file.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the "ConnectionStrings" section exists; otherwise, <c>false</c>.
    /// </returns>
    public static bool ConnectionStringsSectionExists()
    {
        string jsonContent = File.ReadAllText(FileName);
        using JsonDocument doc = JsonDocument.Parse(jsonContent);

        return doc.RootElement.TryGetProperty("ConnectionStrings", out _);
    }

    /// <summary>
    /// Determines whether the "MainConnection" entry exists within the "ConnectionStrings" 
    /// section of the "appsettings.json" file.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the "MainConnection" entry exists within the "ConnectionStrings" section; 
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method is useful for verifying the presence of a specific database connection 
    /// configuration, ensuring that the required "MainConnection" entry is available before 
    /// proceeding with application logic.
    /// </remarks>
    public static bool MainConnectionExists()
    {
        string jsonContent = File.ReadAllText(FileName);
        using JsonDocument doc = JsonDocument.Parse(jsonContent);
        return doc.RootElement.TryGetProperty("ConnectionStrings", out JsonElement connectionStrings) && 
               connectionStrings.TryGetProperty("MainConnection", out _);
    }
}
