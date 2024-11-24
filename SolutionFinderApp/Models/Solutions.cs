namespace SolutionFinderApp.Models;

/// <summary>
/// Represents a collection of solutions, each containing details about its name, folder, file name, and associated projects.
/// </summary>
internal class Solutions
{
    /// <summary>
    /// Get/set the name of the solution.
    /// </summary>
    /// <value>
    /// The name of the solution.
    /// </value>
    public string Name { get; set; }
    /// <summary>
    /// Get/set the folder path where the solution is located.
    /// </summary>
    public string Folder { get; set; }
    /// <summary>
    /// Get/set the file name of the solution.
    /// </summary>
    /// <value>
    /// A string representing the name of the solution file.
    /// </value>
    public string FileName { get; set; }
    /// <summary>
    /// Get/set the list of project file names associated with the solution.
    /// </summary>
    /// <value>
    /// A list of project file names w/o path.
    /// </value>
    public List<string> Projects { get; set; } = [];
}