using Bogus;

namespace BogusApp.DataSets;

public class Folders : DataSet
{
    

    /// <summary>
    /// Gets an array of predefined folder names, which are dynamically generated 
    /// using the <see cref="Bogus.DataSets.System.FileName"/> method.
    /// </summary>
    /// <remarks>
    /// The folder names include paths such as "C:\Work", "C:\Windows", 
    /// "C:\Test", "C:\Web", "C:\Desktop", "C:\Databases", "C:\Images", and "C:\Documents".
    /// </remarks>
    private static string[] _fileNames  => [
        @$"C:\Work\{_dataSet.FileName(_extension)}", 
        @$"C:\Work\Files\{_dataSet.FileName(_extension)}", 
        @$"C:\Windows\{_dataSet.FileName(_extension)}", 
        @$"C:\Work\Data\{_dataSet.FileName(_extension)}", 
        @$"C:\Dotnet\VS2022\Projects\Console1\{_dataSet.FileName(_extension)}", 
        @$"C:\Dotnet\VS2019\Projects\BlazorApp{_dataSet.FileName(_extension)}", 
        @$"C:\Web\{_dataSet.FileName(_extension)}", 
        @$"C:\Web\Projects\{_dataSet.FileName(_extension)}", 
        @$"C:\Desktop\{_dataSet.FileName(_extension)}", 
        @$"C:\Databases\SQL-Server\{_dataSet.FileName(_extension)}", 
        @$"C:\Databases\Scripts\{_dataSet.FileName(_extension)}", 
        @$"C:\Databases\Local\{_dataSet.FileName(_extension)}", 
        @$"C:\Images\{_dataSet.FileName(_extension)}", 
        @$"C:\Documents\{_dataSet.FileName(_extension)}", 
    ];

    public string FolderName() => Random.ArrayElement(_fileNames);
    private static readonly Bogus.DataSets.System _dataSet = new();
    private static string _extension;
    /// <summary>
    /// Generates a single fake <see cref="FileContainer"/> with a specified file extension.
    /// </summary>
    /// <param name="extension">The file extension to be used for the generated item. Defaults to "txt".</param>
    /// <returns>A <see cref="Faker{Item}"/> instance configured to generate an <see cref="FileContainer"/> with the specified file extension.</returns>
    public static Faker<FileContainer> File(string extension = "txt")
    {
        _extension = extension;
        
        return new Faker<FileContainer>()
            .RuleFor(p => p.FileName, f 
                => f.ItemHelper().FolderName());
    }
}