using ProtoBuf;
using BinaryFormatterAlternate.Models;
using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate.Classes;
/// <summary>
/// Provides operations for serializing and deserializing data using Protocol Buffers.
///
/// To keep easy to following no error handling is included in the methods and no encryption is used
/// as each developer will have their own requirements for error handling and encryption.
/// </summary>
internal class ProtobufOperations
{
    private static string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.bin");
    public static void SerializePeople()
    {

        PrintCyan();

        List<Person> people = MockedData.GetPersons();

        using var file = File.Create(fileName);
        Serializer.Serialize(file, people);
    }

    public static void DeserializePeople()
    {

        PrintCyan();

        using var file = File.OpenRead(fileName);
        var people = Serializer.Deserialize<List<Person>>(file);

        AnsiConsole.MarkupLine($"{BeautifyPersonDump(people.Dump())}");
    }
}
