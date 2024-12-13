namespace GlobbingMyDocs.Models;

/// <summary>
/// Represents a file match item, encapsulating details about a file's folder and name.
/// </summary>
/// <remarks>
/// This class is designed to store and provide access to the folder and file name of a matched file.
/// It includes functionality to construct the full file path as a string.
/// </remarks>
public class FileMatchItem(string sender)
{
    public string? Folder { get; init; } = Path.GetDirectoryName(sender);
    public string FileName { get; init; } = Path.GetFileName(sender);
    public override string ToString() => $"{Folder}\\{FileName}";
}