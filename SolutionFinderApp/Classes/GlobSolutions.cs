using Microsoft.Extensions.FileSystemGlobbing;
using SolutionFinderApp.Models;

namespace SolutionFinderApp.Classes;
internal class GlobSolutions
{
    public static List<Solutions> Solutions = [];

    /// <summary>
    /// Asynchronously retrieves and processes the names of solution files in the specified directory.
    /// </summary>
    /// <param name="path">The directory path to search for solution files.</param>
    public static async Task GetSolutionNames(string path)
    {
        await ProcessSolutionFolderAsync(path, ProcessFile);

    }

    /// <summary>
    /// Processes a matched file and appends its details to the internal StringBuilder.
    /// </summary>
    /// <param name="fileMatch">The matched file item to process.</param>
    /// <param name="solutionItem"></param>
    private static void ProcessFile(FileMatchItem fileMatch, string solutionItem)
    {
        
        var solution = Solutions.FirstOrDefault(x => x.Name == solutionItem);

        if (solution is not null)
        {
            solution.Projects.Add(fileMatch.FileName);
        }
        else
        {

            solution = new Solutions
            {
                Name = solutionItem,
                FileName = Path.GetFileName(solutionItem),
                Folder = Path.GetDirectoryName(solutionItem)
            };

            Solutions.Add(solution);

        }


    }


    /// <summary>
    /// Asynchronously processes solution files in the specified folder.
    /// </summary>
    /// <param name="folder">The folder to search for solution files.</param>
    /// <param name="foundAction">The action to perform when a solution file is found.</param>
    private static async Task ProcessSolutionFolderAsync(string folder, Action<FileMatchItem, string> foundAction)
    {
        Matcher matcher = new();
        matcher.AddInclude("**/*.sln");

        var files = matcher.GetResultsInFullPath(folder);
        var tasks = files.Select(async file =>
        {
            foundAction?.Invoke(new FileMatchItem(file), file);
            var list = await GetProjectFiles(Path.GetDirectoryName(file));
            foreach (var item in list)
            {
                foundAction?.Invoke(item, file);
            }
        });

        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Asynchronously retrieves a list of project files in the specified parent folder.
    /// </summary>
    /// <param name="parentFolder">The parent folder to search for project files.</param>
    /// <returns>The task result contains a list of <see cref="FileMatchItem"/> representing the project files found.</returns>
    public static async Task<List<FileMatchItem>> GetProjectFiles(string parentFolder)
    {
        List<FileMatchItem> list = [];
        Matcher matcher = new();
        matcher.AddIncludePatterns(["**/*.csproj"]);

        await Task.Run(() =>
        {
            foreach (var file in matcher.GetResultsInFullPath(parentFolder))
            {
                list.Add(new FileMatchItem(file));
            }
        });

        return list;
    }
}

