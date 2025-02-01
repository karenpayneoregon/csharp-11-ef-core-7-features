using Microsoft.Extensions.Options;
using PayneServiceLibrary.Models.Configuration;

namespace PayneServiceLibrary.Classes.Configuration;
/// <summary>
/// Provides functionality to configure and manage application services related to 
/// connection strings and entity settings.
/// </summary>
/// <remarks>
/// This class is responsible for initializing and retrieving configuration settings 
/// from the application's configuration files, such as appsettings.json. It utilizes 
/// dependency injection to access the required configuration options.
/// </remarks>
internal class SetupServices
{
    private readonly EntityConfiguration _settings;
    private readonly ConnectionStrings _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SetupServices"/> class.
    /// </summary>
    /// <param name="options">
    /// An instance of <see cref="IOptions{TOptions}"/> containing the application's connection strings.
    /// </param>
    /// <param name="settings">
    /// An instance of <see cref="IOptions{TOptions}"/> containing the entity configuration settings.
    /// </param>
    /// <remarks>
    /// This constructor uses dependency injection to retrieve configuration settings for connection strings 
    /// and entity-specific settings. The provided options are extracted and stored for further use within 
    /// the class.
    /// </remarks>
    public SetupServices(IOptions<ConnectionStrings> options, IOptions<EntityConfiguration> settings)
    {
        _options = options.Value;
        _settings = settings.Value;
    }
    /// <summary>
    /// Retrieves and assigns the main connection string from the application's configuration.
    /// </summary>
    /// <remarks>
    /// This method reads the main connection string from the <see cref="ConnectionStrings"/> 
    /// configuration and assigns it to the singleton instance of <see cref="DataConnections"/>. 
    /// It ensures that the application has access to the required database connection string 
    /// for its operations.
    /// </remarks>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
        DataConnections.Instance.SecondaryConnection = _options.SecondaryConnection;
    }
    /// <summary>
    /// Indicates if a database should populate tables with HasData for EF Core
    /// </summary>
    /// <remarks>
    /// This method retrieves the entity configuration settings from the application's 
    /// configuration and assigns them to the singleton instance of <see cref="EntitySettings"/>. 
    /// It ensures that the application uses the latest configuration values for entity-related 
    /// operations.
    /// </remarks>
    public void GetEntitySettings()
    {
        if (JsonHelpers.EntityConfigurationSectionExists())
        {
            EntitySettings.Instance.CreateNew = _settings.CreateNew;
        }
        else
        {
            EntitySettings.Instance.CreateNew = false;
        }
        
    }
}
