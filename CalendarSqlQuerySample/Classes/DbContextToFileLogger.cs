using System.Diagnostics;
using static System.DateTime;

namespace CalendarSqlQuerySample.Classes;

/// <summary>
/// For logging messages from DbContext.
/// 
/// Totally void of exception handling as this is for use by a developer on their machine
/// were they need the proper permissions to create and write to files.
/// </summary>
/// <remarks>
/// If a developer has many projects requiring logging than consider placing this class
/// into a separate class project and creating a local Nuget package for easy access.
///
/// IMPORTANT:
/// For any project using this class setup an action in the project file to create the folder
/// which is done in the project file for this sample. Search for MakeLogDir in the project file.
/// </remarks>
public class DbContextToFileLogger
{
    /// <summary>
    /// Log file name
    /// </summary>
    private readonly string _fileName = 
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "LogFiles", $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}", 
            "EF_Log.txt");

    /// <summary>
    /// Use to override log file name and path, file must exist
    /// </summary>
    /// <param name="fileName"></param>
    public DbContextToFileLogger(string fileName)
    {
        _fileName = fileName;
    }

    /// <summary>
    /// Setup to use default file name for logging
    /// </summary>
    public DbContextToFileLogger()
    {
        if (File.Exists(_fileName)) return;
        using (StreamWriter w = File.AppendText(_fileName)) ;
    }

    /// <summary>
    /// append message to the existing stream
    /// </summary>
    /// <param name="message"></param>
    [DebuggerStepThrough]
    public void Log(string message)
    {

        if (!File.Exists(_fileName))
        {
            File.CreateText(_fileName).Close();
        }

        StreamWriter streamWriter = new(_fileName, true);

        streamWriter.WriteLine(message);

        streamWriter.WriteLine(new string('-', 40));

        streamWriter.Flush();
        streamWriter.Close();
    }
}