using System.Text.Json;

namespace KP_WindowsFormsNET9.Classes.Configuration;

/// <summary>
/// Represents the configuration settings for the application.
/// This class is implemented as a singleton to ensure a single instance of the configuration is used throughout the application.
/// </summary>
public sealed class Configuration
{
    private static readonly Lazy<Configuration> Lazy = new(() => new Configuration());
    public static Configuration Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets the color mode for the application.
    /// </summary>
    /// <value>
    /// A <see cref="SystemColorMode"/> value that indicates the current color mode of the application.
    /// </value>
    public SystemColorMode ColorMode { get; set; }

    /// <summary>
    /// Gets a value indicating whether the application is in dark mode.
    /// </summary>
    /// <value>
    /// <c>true</c> if the application is in dark mode; otherwise, <c>false</c>.
    /// </value>
    public bool IsDarkMode => ColorMode == SystemColorMode.Dark;


    /// <summary>
    /// Initializes a new instance of the <see cref="Configuration"/> class.
    /// This constructor reads the configuration settings from the "appsettings.json" file and sets the <see cref="ColorMode"/> property.
    /// </summary>
    /// <remarks>
    /// The constructor is private to enforce the singleton pattern. It reads the JSON configuration file, deserializes it to retrieve the
    /// visual configuration settings, and sets the <see cref="ColorMode"/> property based on the deserialized value.
    /// </remarks>
    private Configuration()
    {

        var json = File.ReadAllText("appsettings.json");

        try
        {
            var settings = JsonSerializer.Deserialize<ApplicationSetting>(json)!.VisualConfiguration;
            var test = Enum.TryParse(settings.SystemColorMode, true, out SystemColorMode mode);
            ColorMode = test ? mode : SystemColorMode.System;
        }
        catch (Exception)
        {
            ColorMode = SystemColorMode.System;
        }
    }
}