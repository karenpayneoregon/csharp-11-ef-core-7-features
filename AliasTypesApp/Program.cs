namespace AliasTypesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        ExistSamples();
        GetFiles();

        Console.ReadLine();
    }

    internal static readonly string[] fileExtensions = [".mdf", ".bak"];
    private static void GetFiles()
    {
        string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        CurrentUserFileList fileList = Directory.GetFiles(userProfile, "*.*", SearchOption.TopDirectoryOnly)
            .Where(file => fileExtensions.Contains(Path.GetExtension(file)))
            .ToList();
    }

    private static void ExistSamples()
    {
        FileExist exist = Operations.FileExists("appsettings.json");
        Console.WriteLine(exist ? "Found" : "Not found");

        DirectoryExist directoryExist = Operations.DirectoryExists("C:\\Temp");
        Console.WriteLine(directoryExist ? "Found" : "Not found");
    }
}
public class Operations
{
    public static FileExist FileExists(string fileName) => File.Exists(fileName);
    public static DirectoryExist DirectoryExists(string fileName) => Directory.Exists(fileName);
}