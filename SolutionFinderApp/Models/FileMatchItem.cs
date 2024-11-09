namespace SolutionFinderApp.Models;

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