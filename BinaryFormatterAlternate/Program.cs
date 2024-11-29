using BinaryFormatterAlternate.Classes;
using BinaryFormatterAlternate.Models;
using MessagePack;
using ProtoBuf;
using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate;

internal partial class Program
{
    static void Main(string[] args)
    {
        //SerializeFile();
        //DeserializeFile();

        MessagePackOperations.SingleFriend();
        ExitPrompt();
    }

    private static string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.bin");
    private static void SerializeFile()
    {
        List<Person> people = MockedData.GetPersons();
        
        using var file = File.Create(fileName);
        Serializer.Serialize(file, people);
    }

    private static void DeserializeFile()
    {
        using var file = File.OpenRead(fileName);
        var people = Serializer.Deserialize<List<Person>>(file);

        AnsiConsole.MarkupLine($"{BeautifyDump(people.Dump())}");
    }
}