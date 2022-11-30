# About

Demonstrates using raw string literals to create an xml file from a json string.

```csharp
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
```

People.json

```json
[
  {
    "Id": 1,
    "FirstName": "Sheri",
    "LastName": "Krajcik",
    "BirthDate": "2014-05-10T12:27:23.6864147-07:00"
  },
  {
    "Id": 2,
    "FirstName": "Sophie",
    "LastName": "Purdy",
    "BirthDate": "2021-11-25T09:34:48.1464526-08:00"
  },
  {
    "Id": 3,
    "FirstName": "Jim",
    "LastName": "Smith",
    "BirthDate": "1990-01-01T00:00:00"
  }
]
```

Resulting XML file

```xml
<?xml version="1.0" standalone="no"?>
<People>
  <Person>
    <Id>1</Id>
    <FirstName>Sheri</FirstName>
    <LastName>Krajcik</LastName>
    <BirthDate>2014-05-10T12:27:23.6864147-07:00</BirthDate>
  </Person>
  <Person>
    <Id>2</Id>
    <FirstName>Sophie</FirstName>
    <LastName>Purdy</LastName>
    <BirthDate>2021-11-25T09:34:48.1464526-08:00</BirthDate>
  </Person>
  <Person>
    <Id>3</Id>
    <FirstName>Jim</FirstName>
    <LastName>Smith</LastName>
    <BirthDate>1990-01-01T00:00:00</BirthDate>
  </Person>
</People>
```
