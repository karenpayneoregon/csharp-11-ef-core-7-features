namespace SolutionFinderApp.Models;

/// <summary>
/// Represents a matched file item within a directory, including its folder and file name.
/// </summary>
public class FileMatchItem
{
    public FileMatchItem(string sender)
    {
        Folder = Path.GetDirectoryName(sender);
        FileName = Path.GetFileName(sender);
    }
    public string Folder { get; init; }
    public string FileName { get; init; }
    public override string ToString() => $"{Folder}\\{FileName}";
}