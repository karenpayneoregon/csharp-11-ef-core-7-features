using BogusExtendedApp.Classes;
using BogusExtendedApp.DataSets;
using BogusExtendedApp.Models;
using static BogusExtendedApp.Classes.SpectreConsoleHelpers;

namespace BogusExtendedApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        SerializeDeserialize();
        ExitPrompt();
    }

    private static void MainExample()
    {
        var contacts = BogusOperations.Contacts();
        Console.WriteLine(ObjectDumper.Dump(contacts));
    }

    private static void Other()
    {
        for (int index = 0; index < 3; index++)
        {
            var category = NorthWind.SingleCategory();
            Console.WriteLine($"{category.CategoryID,-4}{category.CategoryName,-30}{category.Description}");
   
        }
    }

    /// <summary>
    /// protobuf-net demo
    /// </summary>
    private static void SerializeDeserialize()
    {
        // give the file a name most users will not look at
        var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataLibrary.dll");

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        // generate a contact
        List<Contact> original = BogusOperations.Contacts(1);

        CryptoSerializer<Contact> cryptoSerializer = new(Secrets.Key);

        // serialize contact to file
        using (FileStream fileStream1 = new(fileName, FileMode.OpenOrCreate))
        {
            cryptoSerializer.Serialize(original, fileStream1);
        }
        // deserialize contact
        using FileStream fileStream = new(fileName, FileMode.Open);
        Contact readBack = cryptoSerializer.DeserializeSingle(fileStream);

        Console.WriteLine(ObjectDumper.Dump(readBack, DumpStyle.CSharp));
    }
}