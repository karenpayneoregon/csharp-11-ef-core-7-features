using System.Text.Json;
using System.Xml.Linq;

namespace JsonExample.Classes;

public class JsonOperations
{
    /// <summary>
    /// Converts a JSON string to an XML representation.
    /// </summary>
    /// <param name="json">The JSON string to be converted. The root element of the JSON must be an array.</param>
    /// <param name="rootElementName">The name of the root element in the resulting XML.</param>
    /// <param name="itemElementName">The name of each item element in the resulting XML.</param>
    /// <returns>A string containing the XML representation of the provided JSON.</returns>
    /// <exception cref="ArgumentException">Thrown when the root element of the JSON is not an array.</exception>
    public static string ToXml(string json, string rootElementName, string itemElementName)
    {
        using var doc = JsonDocument.Parse(json);
        XElement root = new(rootElementName);

        if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            foreach (var element in doc.RootElement.EnumerateArray())
            {
                var item = new XElement(itemElementName);
                ParseJsonElement(element, item);
                root.Add(item);
            }
        }
        else
        {
            throw new ArgumentException("JSON root must be an array.");
        }

        return root.ToString();
    }

    /// <summary>
    /// Parses a <see cref="JsonElement"/> and adds its properties as child elements to the specified <see cref="XElement"/>.
    /// </summary>
    /// <param name="element">The <see cref="JsonElement"/> to parse.</param>
    /// <param name="parent">The <see cref="XElement"/> to which the parsed properties will be added as child elements.</param>
    private static void ParseJsonElement(JsonElement element, XElement parent)
    {
        foreach (var property in element.EnumerateObject())
        {
            var child = new XElement(property.Name, property.Value.ToString());
            parent.Add(child);
        }
    }
}