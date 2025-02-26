using GlobbingImages.Classes;
using GlobbingImages.Models;
using static System.Net.Mime.MediaTypeNames;

namespace GlobbingImages;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await ProcessAndDisplayImages();

        ExitPrompt();
    }

    private static async Task ProcessAndDisplayImages()
    {
        // patterns to include 
        string[] include = ["**/Ri*.png", "**/Bl*.png"];

        // patterns to exclude
        string[] exclude = ["**/blog*.png", "**/black*.png", "**/*arrow_16*.png"];

        var folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Snagit";

        if (Directory.Exists(folder))
        {
            // used to reduce the number of parameters passed to the method GetImagesNamesAsync
            MatcherParameters matcherParameters = new()
            {
                Patterns = include,
                ExcludePatterns = exclude,
                ParentFolder = folder
            };

            var imageNames = await Globbing.GetImagesNamesAsync(matcherParameters).ConfigureAwait(false);

            foreach (var image in imageNames())
            {
                Console.WriteLine($"{Path.GetDirectoryName(image)?.Replace(folder, "").TrimStart('\\'),-15}{Path.GetFileName(image)}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"Folder [hotpink]{folder}[/] not found");
        }
    }
}

