using System.Text.Json;
using ReadEntitySettings.Models;

namespace ReadEntitySettings.Classes;

/// <summary>
/// Provides functionality for managing entity settings, including reading configuration
/// from the "appsettings.json" file to determine whether a new entity should be created.
/// </summary>
public sealed class EntitySettings
{
    private static readonly Lazy<EntitySettings> Lazy = new(() => new EntitySettings());
    public static EntitySettings Instance => Lazy.Value;

    public bool GenerateData { get; set; }
    private EntitySettings()
    {
        GenerateData = CreateNew();
    }
    /// <summary>
    /// Reads the "appsettings.json" file and determines whether a new entity should be created
    /// based on the "CreateNew" property in the "EntityConfiguration" section.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the "CreateNew" property in the "EntityConfiguration" section is set to <c>true</c>;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown when the "EntityConfiguration" section is not found in the "appsettings.json" file.
    /// </exception>
    private static bool CreateNew()
    {

        string json = File.ReadAllText("appsettings.json");
        using JsonDocument doc = JsonDocument.Parse(json);

        JsonElement root = doc.RootElement;

        if (root.TryGetProperty(nameof(EntityConfiguration), out var entityConfig))
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var settings = JsonSerializer.Deserialize<EntityConfiguration>(entityConfig.GetRawText(), options);
            return settings.CreateNew;
        }

        throw new Exception($"{nameof(EntityConfiguration)} section not found in appsettings.json");

    }
}