using System.Diagnostics;
using static System.DateTime;

namespace NorthWind2023Library.Classes;

/// <summary>
/// For logging messages from DbContext.
/// 
/// DO NOT use in production, only development environment
/// 
/// Totally void of exception handling as this is for use by a developer on their machine
/// were they need the proper permissions to create and write to files.
/// 
/// </summary>
public class DbContextToFileLogger
{
    /// <summary>
    /// Log file name
    /// </summary>
    private readonly string _fileName = 
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", 
            "EF_Log.txt");

    /// <summary>
    /// Use to override log file name and path, file must exists
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
        var dir = Path.GetDirectoryName(_fileName);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (!File.Exists(_fileName))
        {
            using (StreamWriter w = File.AppendText(_fileName)) ;
        }
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