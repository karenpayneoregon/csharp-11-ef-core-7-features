using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.FileSystemGlobbing;
using SolutionFinderApp.Models;

namespace SolutionFinderApp.Classes;
internal class SolutionExamples
{
    private static StringBuilder _sb = new();
    public static List<SolutionModel> Solutions = new();

    /// <summary>
    /// Asynchronously retrieves and processes the names of solution files in the specified directory.
    /// </summary>
    /// <param name="path">The directory path to search for solution files.</param>
    public static async Task GetSolutionNames(string path)
    {
        //Console.WriteLine($"Traversing {path}...");
        await FilesAsync(path, ProcessFile,"");
    }

    /// <summary>
    /// Processes a matched file and appends its details to the internal StringBuilder.
    /// </summary>
    /// <param name="fileMatch">The matched file item to process.</param>
    /// <param name="solutionItem"></param>
    /// <param name="isProject"></param>
    private static void ProcessFile(FileMatchItem fileMatch, string solutionItem, bool isProject)
    {
        var solution = Solutions.FirstOrDefault(x => x.Name == solutionItem);
        if (solution is not null)
        {
            solution.Projects.Add(fileMatch.FileName);
        }
        else
        {
            solution = new SolutionModel
            {
                Name = solutionItem, 
                FileName = Path.GetFileName(solutionItem),
                Folder = Path.GetDirectoryName(solutionItem)
            };
            Solutions.Add(solution);
        }


    }

    /// <summary>
    /// Completes the processing of solution files and writes file names and total count of file names.
    /// </summary>
    private static void Done()
    {
        Console.WriteLine($"Total solutions {Solutions.Count}");
    }

    /// <summary>
    /// Asynchronously processes solution files in the specified folder.
    /// </summary>
    /// <param name="folder">The folder to search for solution files.</param>
    /// <param name="foundAction">The action to perform when a solution file is found.</param>
    /// <param name="empty"></param>
    private static async Task FilesAsync(string folder, Action<FileMatchItem, string, bool> foundAction, string empty)
    {
        int count = 0;
        
        Matcher matcher = new();
        matcher.AddIncludePatterns(["**/*.sln"]);

        await Task.Run(async () =>
        {
            foreach (var file in matcher.GetResultsInFullPath(folder))
            {
                foundAction?.Invoke(new FileMatchItem(file),file ,false);
                var list = await GetProjectFiles(Path.GetDirectoryName(file));
                foreach (var item in list)
                {
                    foundAction?.Invoke(item,file,true);
                }
                count++;
            }
        });
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
            foreach (string file in matcher.GetResultsInFullPath(parentFolder))
            {
                list.Add(new FileMatchItem(file));
            }
        });

        return list;
    }
}
