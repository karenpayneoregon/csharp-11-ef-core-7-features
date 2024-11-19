namespace KP_WindowsFormsNET9.Models;

/// <summary>
/// Represents an item within a folder, encapsulating its name and the date it was last modified.
/// </summary>
public class FolderItem(string name, DateTime lastModified)
{
    /// <summary>
    /// Gets the name of the folder item.
    /// </summary>
    /// <value>
    /// A string representing the name of the folder item.
    /// </value>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the date and time when the folder item was last modified.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> representing the last modification date and time of the folder item.
    /// </value>
    public DateTime LastModified { get; } = lastModified;
}