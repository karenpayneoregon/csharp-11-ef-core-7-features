using System.Diagnostics;
using GlobbingMyDocs.Classes;
using GlobbingMyDocs.Models;

using Meziantou.Framework.Globbing;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GlobbingMyDocs;

[SuppressMessage("ReSharper", "AsyncVoidMethod")]
public partial class MainForm : Form
{
    public delegate void OnTraverseMatch(FileMatchItem sender);
    public static event OnTraverseMatch? TraverseMatch;
    public MainForm()
    {
        InitializeComponent();

        //GetExcelFilesUnderMyDocuments();

        TraverseMatch += MainForm_TraverseSolutionMatch;
    }

    private void MainForm_TraverseSolutionMatch(FileMatchItem sender)
    {
        listBox1.InvokeIfRequired(lb => lb.Items.Add(sender));
    }

    public static void GetExcelFilesUnderMyDocuments()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var options = new EnumerationOptions()
        {
            AttributesToSkip = FileAttributes.Hidden | FileAttributes.System,
            RecurseSubdirectories = true,
            IgnoreInaccessible = true
        };

        var source = new DirectoryInfo(folder);
        foreach (var subfolder in source.EnumerateDirectories("*", options))
        {
            foreach (var file in subfolder.EnumerateFiles("*.xlsx", options))
            {
                Debug.WriteLine($"File: {file.FullName}");
            }
        }

    }

    /// <summary>
    /// Asynchronously retrieves all matching solution files from the user's "My Documents" folder.
    /// </summary>
    /// <remarks>
    /// This method searches for files with extensions ".docx" and ".xlsx" in the "My Documents" folder
    /// using globbing patterns. It invokes the <see cref="TraverseMatch"/> event for each matching file.
    /// </remarks>
    public static async Task GetSolutionFilesAsync()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        await Task.Run(() =>
        {
            /*
             * match all .docx and .xlsx files in the MyDocuments folder
             */

            var glob = Glob.Parse("/**/*.{docx,xlsx}", GlobOptions.None);

            var enumerationOptions = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                AttributesToSkip = FileAttributes.Hidden,
            };
            foreach (var file in glob.EnumerateFiles(folder, enumerationOptions))
            {
                TraverseMatch?.Invoke(new FileMatchItem(file));
            }
        });

    }

    public static async IAsyncEnumerable<FileMatchItem> GetFilesAsync(string[] extensions, string token)
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var globPattern = $"/**/*.{{{string.Join(",", extensions)}}}";
        var glob = Glob.Parse(globPattern, GlobOptions.None);
        var enumerationOptions = new EnumerationOptions { IgnoreInaccessible = true, AttributesToSkip = FileAttributes.Hidden };

        await foreach (var file in GetFilesAsync(glob, folder, enumerationOptions).WithCancellation(CancellationToken.None))
        {
            if (file == token)
            {
                yield break;
            }
            yield return new FileMatchItem(file);
        }
    }

    private static async IAsyncEnumerable<string> GetFilesAsync(Glob glob, string folder, EnumerationOptions options)
    {
        foreach (var file in glob.EnumerateFiles(folder, options))
        {
            yield return file;
            await Task.Yield();
        }
    }



    private async void ExecuteButton_Click(object sender, EventArgs e)
    {
        await GetSolutionFilesAsync();
    }

    private async void OtherButton_Click(object sender, EventArgs e)
    {
        string[] extensions = ["docx", "xlsx"]; 
        await foreach (var fileMatch in GetFilesAsync(extensions, "Firewall rule for FTP for Web Developers.docx"))
        {
            Debug.WriteLine(fileMatch.FileName);
        }
    }
}