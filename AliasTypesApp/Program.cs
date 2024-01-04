namespace AliasTypesApp;

    internal partial class Program
    {
        static void Main(string[] args)
        {
            FileExist exist = FileOperations.FileExists("appsettings.json");
            if (exist)
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not found");
            }

            Console.ReadLine();
        }


    }

    public class FileOperations
    {
        public static FileExist FileExists(string fileName) => File.Exists(fileName);
    }