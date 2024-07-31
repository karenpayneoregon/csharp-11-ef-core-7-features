using BogusProperGenderEntityApp.Models.Configurations;
using Microsoft.Extensions.Options;

namespace BogusProperGenderEntityApp.Classes.Configurations;

/// <summary>
/// Represents a class that sets up services for the application.
/// </summary>
internal class SetupServices
{
    private readonly EntityConfiguration _settings;
    private readonly ConnectionStrings _options;


    /// <summary>
    /// Initializes a new instance of the <see cref="SetupServices"/> class.
    /// </summary>
    /// <param name="options">Used to retrieve configured <see cref="ConnectionStrings"/> instance.</param>
    /// <param name="settings">Used to retrieve configured <see cref="EntityConfiguration"/> instance.</param>
    public SetupServices(IOptions<ConnectionStrings> options, IOptions<EntityConfiguration> settings)
    {
        _options = options.Value;
        _settings = settings.Value;
    }

    /// <summary>
    /// Reads the application data connection string from appsettings.
    /// </summary>
    /// <remarks>
    /// Karen's NuGet package can handle up to three connections from appsettings.json.
    /// </remarks>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
    }

    /// <summary>
    /// Gets the entity settings from configuration.
    /// </summary>
    public void GetEntitySettings()
    {
        EntitySettings.Instance.CreateNew = _settings.CreateNew;
    }
}
