namespace MemoryConfigurationSourceRazorPages.Models;

/// <summary>
/// Represents a layout model used in Razor Pages, containing properties such as title.
/// </summary>
/// <remarks>
/// This class is designed to map configuration data from the application's settings file (e.g., appsettings.json).
/// It is primarily used to provide layout-related information, such as the page title, to Razor Pages.
/// </remarks>
public class Layout
{
    public string Title { get; set; } = string.Empty;
}