namespace KarenConsoleApplication.Classes;

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