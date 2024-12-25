using System.Diagnostics;

namespace GlobbingMyDocs.Classes;


public static class FileFinder
{
    public static async Task GetMyDocumentsAsync()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var options = new EnumerationOptions()
        {
            AttributesToSkip = FileAttributes.Hidden | FileAttributes.System,
            RecurseSubdirectories = true
        };

        var source = new DirectoryInfo(folder);

        await Task.Run(() =>
        {
            Parallel.ForEach(source.EnumerateDirectories("*", options), subfolder =>
            {
                foreach (FileInfo file in subfolder.EnumerateFiles("*.xlsx", options))
                {
                    Debug.WriteLine($"File: {file.FullName}");
                }
            });
        });
    }
}
