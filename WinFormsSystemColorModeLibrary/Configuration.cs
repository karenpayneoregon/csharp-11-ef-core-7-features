using System.Text.Json;
using WinFormsSystemColorModeLibrary.Models;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8618, CS9264

namespace WinFormsSystemColorModeLibrary;

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
    /// Gets or sets the text representation of the current color mode.
    /// </summary>
    /// <value>
    /// A string that represents the current color mode. Possible values are "Dark mode", "Light mode", and "System mode".
    /// </value>
    /// <remarks>
    /// This property is set based on the <see cref="ColorMode"/> property during the initialization of the <see cref="Configuration"/> class.
    /// </remarks>
    public string ModeText { get; set; }

    /// <summary>
    /// Gets or sets an array of mode names representing the different system color modes available.
    /// </summary>
    /// <value>
    /// An array of strings where each string is the name of a system color mode.
    /// </value>
    /// <remarks>
    /// This property is initialized with the names of the <see cref="SystemColorMode"/> enumeration values.
    /// </remarks>
    public string[] ModesArray { get; set; }

    /// <summary>
    /// Sets the mode text based on the specified <paramref name="mode"/> and updates the configuration file.
    /// </summary>
    /// <param name="mode">The system color mode to set.</param>
    /// <remarks>
    /// This method reads the current configuration from "appsettings.json", updates the visual configuration's system color mode,
    /// and writes the updated configuration back to the file.
    /// </remarks>
    public void SetModeText(SystemColorMode mode)
    {
        var json = File.ReadAllText("appsettings.json");
        ApplicationSetting? settings = JsonSerializer.Deserialize<ApplicationSetting>(json);
        settings!.VisualConfiguration.SystemColorMode = mode.ToString();
        File.WriteAllText("appsettings.json", JsonSerializer.Serialize(settings, Indented));
    }

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

        // for use in SettingsForm ComboBox
        ModesArray = Enum.GetValues(typeof(SystemColorMode))
            .Cast<SystemColorMode>()
            .Select(e => e.ToString())
            .ToArray();

        var json = File.ReadAllText("appsettings.json");

        try
        {
            /*
             * Read color mode, convert to enum and set ColorMode.
             * Note, SystemColorMode in appsettings is case-insensitive.
             * If the value is not a valid SystemColorMode, the ColorMode is set to System.
             */
            var settings = JsonSerializer.Deserialize<ApplicationSetting>(json)!.VisualConfiguration;
            var test = Enum.TryParse(settings.SystemColorMode, true, out SystemColorMode mode);
            ColorMode = test ? mode : SystemColorMode.System;
        }
        catch (Exception)
        {
            ColorMode = SystemColorMode.System;
        }

        ModeText = ColorMode switch
        {
            SystemColorMode.Dark => "Dark mode",
            SystemColorMode.Classic => "Light mode",
            SystemColorMode.System => "System mode",
            _ => ModeText
        };
    }

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}