using BinaryFormatterAlternate.Models;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

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

        var text = Serialize(people);
        File.WriteAllText(fileName,text);

        var list = Deserialize(text, typeof(List<Person2>)) as List<Person2>;

        Console.WriteLine(list.Dump());
    }

    /// <summary>
    /// Serializes the specified object to an XML string using the DataContractSerializer.
    /// </summary>
    /// <param name="obj">The object to serialize. It must be serializable by the DataContractSerializer.</param>
    /// <returns>A string containing the XML representation of the serialized object.</returns>
    public static string Serialize(object obj)
    {
        using MemoryStream memoryStream = new();
        DataContractSerializer serializer = new(obj.GetType());
        serializer.WriteObject(memoryStream, obj);
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    /// <summary>
    /// Deserializes the specified XML string to an object of the given type using the DataContractSerializer.
    /// </summary>
    /// <param name="xml">The XML string representing the serialized object.</param>
    /// <param name="toType">The <see cref="Type"/> to which the XML string should be deserialized.</param>
    /// <returns>An object of the specified type, deserialized from the XML string.</returns>
    public static object Deserialize(string xml, Type toType)
    {
        using MemoryStream memoryStream = new(Encoding.UTF8.GetBytes(xml));

        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, 
            new XmlDictionaryReaderQuotas(), null);

        DataContractSerializer serializer = new DataContractSerializer(toType);
        return serializer.ReadObject(reader);
    }
}
