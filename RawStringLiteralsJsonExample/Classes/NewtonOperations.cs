using Newtonsoft.Json;
using System.Xml;

namespace JsonExample.Classes;

internal class NewtonOperations
{
    private static string FileName => "People.json";

    public static void ConvertJsonToXml()
    {

        string json = $$"""
            {
                '?xml': {
                '@version': '1.0',
                '@standalone': 'no'
            },
            'People': 
            {
                'Person': 
                 {{File.ReadAllText(FileName)}}
              }
            }
        """;

        XmlDocument doc = JsonConvert.DeserializeXmlNode(json)!;
        doc.Save("People.xml");
    }
}