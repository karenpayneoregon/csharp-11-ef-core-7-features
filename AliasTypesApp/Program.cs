namespace AliasTypesApp;




internal partial class Program
{
    static void Main(string[] args)
    {
        FileExist exist = Operations.FileExists("appsettings.json");
        Console.WriteLine(exist ? "Found" : "Not found");

        DirectoryExist directoryExist = Operations.DirectoryExists("C:\\Temp");
        Console.WriteLine(directoryExist ? "Found" : "Not found");

        string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        CurrentUserFileList fileList = Directory.GetFiles(userProfile, "*.*", SearchOption.TopDirectoryOnly)
            .Where(file => new[] { ".mdf", ".bak" }
                .Contains(Path.GetExtension(file)))
            .ToList();

        Console.ReadLine();
    }

}

public class Operations
{
    public static FileExist FileExists(string fileName) => File.Exists(fileName);
    public static DirectoryExist DirectoryExists(string fileName) => Directory.Exists(fileName);
}