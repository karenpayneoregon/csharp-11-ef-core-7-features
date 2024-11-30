using BinaryFormatterAlternate.Models;
using System.Runtime.Serialization;
using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate.Classes;

/// <summary>
/// Provides operations for serializing and deserializing objects using the <inheritdoc cref="DataContractSerializer"/>.
/// </summary>
internal class DataContractSerializerOperations
{
    private static string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "person1.data");

    public static void SerializePeople()
    {

        PrintCyan();

        List<Person2> people = MockedData.GetPersons2();

        var text = DataContractSerializerHelpers.Serialize(people);
        File.WriteAllText(fileName,text);

        var list = DataContractSerializerHelpers.Deserialize(text, typeof(List<Person2>)) as List<Person2>;

        Console.WriteLine(list.Dump());
    }


}