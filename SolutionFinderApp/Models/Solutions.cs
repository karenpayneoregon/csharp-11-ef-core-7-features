namespace SolutionFinderApp.Models;

/// <summary>
/// Represents a collection of solutions, each containing details about its name, folder, file name, and associated projects.
/// </summary>
internal class Solutions
{
    public string Name { get; set; }
    public string Folder { get; set; }
    public string FileName { get; set; }
    public List<string> Projects { get; set; } = [];
}
