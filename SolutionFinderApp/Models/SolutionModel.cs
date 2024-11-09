namespace SolutionFinderApp.Models;
internal class SolutionModel
{
    public string Name { get; set; }
    public string Folder { get; set; }
    public string FileName { get; set; }
    public List<string> Projects { get; set; } = [];
}
