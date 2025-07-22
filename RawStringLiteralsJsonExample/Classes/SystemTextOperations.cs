using JsonExample.Models;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JsonExample.Classes;

/// <summary>
/// Code taken from https://code-maze.com/csharp-convert-json-to-xml-or-xml-to-json/
/// Karen added xml indenting
/// </summary>
internal class SystemTextOperations
{

    /// <summary>
    /// Deserializes the specified XML string into an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the object to deserialize the XML string into.
    /// </typeparam>
    /// <param name="xml">
    /// The XML string to be deserialized.
    /// </param>
    /// <returns>
    /// An object of type <typeparamref name="T"/> that represents the deserialized XML data.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the XML string cannot be deserialized into the specified type.
    /// </exception>
    private static T XmlToObject<T>(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        using var stringReader = new StringReader(xml);

        return (T)xmlSerializer.Deserialize(stringReader)!;
    }

    /// <summary>
    /// Converts an object of type <typeparamref name="T"/> to its XML representation as a string.
    /// </summary>
    /// <typeparam name="T">The type of the object to be converted to XML.</typeparam>
    /// <param name="obj">The object to be serialized into XML.</param>
    /// <returns>A string containing the XML representation of the object.</returns>
    /// <remarks>
    /// The method uses <see cref="XmlSerializer"/> for serialization and applies indentation to the resulting XML.
    /// </remarks>
    private static string ObjectToXml<T>(T obj)
    {
        XmlWriterSettings settings = new() { Indent = true };
        var xmlSerializer = new XmlSerializer(typeof(T));

        var sb = new StringBuilder();
        using var xmlWriter = XmlWriter.Create(sb,settings);

        var ns = new XmlSerializerNamespaces([XmlQualifiedName.Empty]);
        xmlSerializer.Serialize(xmlWriter, obj, ns);

        return sb.ToString();
    }
}