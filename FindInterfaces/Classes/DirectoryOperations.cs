#nullable disable

namespace FindInterfaces.Classes;
internal class DirectoryOperations
{
    /// <summary>
    /// Get <see cref="DirectoryInfo"/> for a solution folder
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static DirectoryInfo GetSolutionInfo(string path = null!)
    {
        DirectoryInfo directory = new(path ?? Directory.GetCurrentDirectory());
        while (directory is not null && directory.GetFiles("*.sln").Length == 0)
        {
            directory = directory.Parent;
        }
        return directory;
    }
    /// <summary>
    /// Get current solution path
    /// </summary>
    /// <returns></returns>
    public static string SolutionName()
    {
        return Path.GetFileName(Directory
            .GetFiles(GetSolutionInfo().FullName, "*.sln")
            .FirstOrDefault()!);
    }
}