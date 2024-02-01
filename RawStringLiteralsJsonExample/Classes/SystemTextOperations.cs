using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace JsonExample.Classes;

/// <summary>
/// Code taken from https://code-maze.com/csharp-convert-json-to-xml-or-xml-to-json/
/// Karen added xml indenting
/// </summary>
internal class SystemTextOperations
{
    public static string XmlToJson(string xml)
    {
        var obj = XmlToObject<SquidGame>(xml);

        return JsonSerializer.Serialize(new RootObject { SquidGame = obj });
    }

    static T XmlToObject<T>(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        using var stringReader = new StringReader(xml);

        return (T)xmlSerializer.Deserialize(stringReader)!;
    }
    public static string JsonToXml(string json) 
        => ObjectToXml(JsonSerializer.Deserialize<RootObject>(json)!.SquidGame);

    static string ObjectToXml<T>(T obj)
    {
        XmlWriterSettings settings = new() { Indent = true };
        var xmlSerializer = new XmlSerializer(typeof(T));

        var sb = new StringBuilder();
        using var xmlWriter = XmlWriter.Create(sb,settings);

        var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        xmlSerializer.Serialize(xmlWriter, obj, ns);

        return sb.ToString();
    }
}

public class RootObject
{
    public SquidGame? SquidGame { get; set; }
}

public class SquidGame
{
    public string? Genre { get; set; }
    public Rating? Rating { get; set; }
    [XmlElement]
    public string[]? Stars { get; set; }
    public object? Budget { get; set; }
}

public class Rating
{
    [XmlAttribute]
    [JsonPropertyName("@Type")]
    public string? Type { get; set; }
    [XmlText]
    [JsonPropertyName("#text")]
    public string? Text { get; set; }
}