using KP_WindowsFormsNET9.Models;

namespace KP_WindowsFormsNET9.Classes;
/// <summary>
/// Provides file operation utilities, specifically for handling Visual Studio activity logs.
/// </summary>
internal class FileOperations
{
    /// <summary>
    /// Retrieves the activity log from the most recently modified Visual Studio activity directory.
    /// </summary>
    /// <returns>
    /// A tuple containing an array of strings representing the lines of the activity log and a boolean indicating success.
    /// If the activity log file is found and read successfully, the boolean is <c>true</c> and the array contains the log lines.
    /// Otherwise, the boolean is <c>false</c> and the array is empty.
    /// </returns>
    public static (string[] lines, bool success) GetActivityLog()
    {
        var rootDirectory = VisualStudioRootActivityFolder(out var activityDirectory);

        if (activityDirectory == null) return ([], false);

        var path = Path.Combine(rootDirectory, activityDirectory.Name);
        var activityLogFileName = Path.Combine(path, "ActivityLog.xml");

        return File.Exists(activityLogFileName) ?
            (File.ReadAllLines(activityLogFileName), true) :
            ([], false)!;
    }

    /// <summary>
    /// Retrieves the root directory for Visual Studio activity logs and identifies the most recently modified subdirectory
    /// that starts with a digit.
    /// </summary>
    /// <param name="activityDirectory">The most recently modified subdirectory that starts with a digit, or <c>null</c> if no such directory exists.</param>
    /// <returns>The root directory path for Visual Studio activity logs.</returns>
    private static string VisualStudioRootActivityFolder(out FolderItem? activityDirectory)
    {
        var rootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "VisualStudio");
        var directories = Directory.GetDirectories(rootDirectory);

        /*
         * There may be multiple directories in the root directory e.g.17.0, 17.0_f56beab6
         * were we want the child directory that starts with a number.
         */
        activityDirectory = directories
            .Where(dir => char.IsDigit(Path.GetFileName(dir)[0]))
            .Select(dir => new FolderItem(Path.GetFileName(dir), Directory.GetLastWriteTime(dir)))
            .OrderByDescending(x => x.LastModified)
            .FirstOrDefault();

        return rootDirectory;
    }
}