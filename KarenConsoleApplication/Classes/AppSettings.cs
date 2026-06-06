namespace KarenConsoleApplication.Classes;

/// <summary>
/// Represents application settings and provides static properties for accessing configuration keys.
/// </summary>
/// <remarks>
/// This class contains predefined keys used for retrieving specific configuration values, such as logging settings and database connection strings.
/// </remarks>
public class AppSettings
{
    /// <summary>
    /// Gets the configuration key for specifying the logging level in the application.
    /// </summary>
    public static string LogPath => "Logging:LogLevel";
    /// <summary>
    /// This property is used to determine the logging behavior of the application.
    /// </summary>
    public static string UseLogging => "Internal";
    /// <summary>
    /// Gets the name of the default database connection string used in the application.
    /// </summary>
    public static string DataBaseConnection => "DefaultConnection";

}