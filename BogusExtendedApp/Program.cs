using BogusExtendedApp.Classes;
using BogusExtendedApp.DataSets;
using BogusExtendedApp.Models;
using static BogusExtendedApp.Classes.SpectreConsoleHelpers;
#pragma warning disable CA1416

namespace BogusExtendedApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        //SerializeFile();
        Other();
        MainExample();
        ExitPrompt();
    }

    private static void MainExample()
    {
        var contacts = BogusOperations.Contacts();
        Console.WriteLine(ObjectDumper.Dump(contacts));
    }

    private static void Other()
    {
        var table = CreateCategoryTable();
        for (int index = 0; index < 3; index++)
        {
            var category = NorthWind.SingleCategory();
            table.AddRow(category.CategoryID.ToString(), category.CategoryName, category.Description, category.Picture.Size.ToString());
        }

        AnsiConsole.Write(table);
    }


    private static void SerializeFile()
    {
        
        var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CommonLibrary.dll");

        List<Contact> contacts = BogusOperations.Contacts(1);

        CryptoSerializer<Contact> cryptoSerializer = new(Secrets.Key);

        using (FileStream fileStream = new(fileName, FileMode.OpenOrCreate))
        {
            cryptoSerializer.Serialize(contacts, fileStream);
        }

        DeserializeFile(fileName, cryptoSerializer);
    }

    private static void DeserializeFile(string fileName, CryptoSerializer<Contact> cryptoSerializer)
    {
        using FileStream fileStream = new(fileName, FileMode.Open);
        Contact contacts = cryptoSerializer.DeserializeSingle(fileStream);
    }


}