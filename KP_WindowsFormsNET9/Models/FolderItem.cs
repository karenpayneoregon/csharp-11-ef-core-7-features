namespace KP_WindowsFormsNET9.Models;

/// <summary>
/// Represents an item within a folder, encapsulating its name and the date it was last modified.
/// </summary>
public class FolderItem(string name, DateTime lastModified)
{
    public string Name { get; } = name;
    public DateTime LastModified { get; } = lastModified;
}