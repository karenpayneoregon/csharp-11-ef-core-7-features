using System.Text.Json;
using BinaryFormatterAlternate.Models;
using Spectre.Console.Json;

using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate.Classes;

/// <summary>
/// Provides operations for serializing and deserializing objects using System.Text.Json.
/// </summary>
/// <remarks>
/// This class is responsible for handling JSON serialization and deserialization of <see cref="Person1"/> objects.
/// It utilizes the System.Text.Json library to perform these operations, storing the serialized data in a file
/// named "person1.json" located in the application's base directory.
/// </remarks>
internal class SystemTextJsonOperations
{
    /// <summary>
    /// Handles JSON serialization and deserialization with System.Text.Json.
    /// </summary>
    private static string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "person1.json");

    /// <summary>
    /// Gets the <see cref="JsonSerializerOptions"/> configured to format JSON with indented output.
    /// </summary>
    public static JsonSerializerOptions Indented => new() { WriteIndented = true };

    /// <summary>
    /// Serializes a list of <see cref="Person1"/> objects to a JSON file using System.Text.Json.
    /// </summary>
    /// <remarks>
    /// The serialized JSON is written to a file named "person1.json" in the application's base directory.
    /// </remarks>
    public static void SerializePeople()
    {

        PrintCyan();

        List<Person1> people = MockedData.GetPersons1();

        var json = JsonSerializer.Serialize(people, Indented);
        
        File.WriteAllText(fileName, json);


        /*
         * Customize the JSON output with colors using Spectre.Console
         */
        var jsonText = new JsonText(json)
            .BracketColor(Color.Green)
            .ColonColor(Color.Blue)
            .CommaColor(Color.Yellow)
            .StringColor(Color.Green)
            .NumberColor(Color.White)
            .BooleanColor(Color.Red)
            .MemberColor(Color.DodgerBlue1)
            .NullColor(Color.Green);


        /*
         * Display json
         */
        AnsiConsole.Write(
            new Panel(jsonText)
                .Header("People")
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow));


    }

    /// <summary>
    /// Deserializes a JSON file into a list of <see cref="Person1"/> objects using System.Text.Json.
    /// </summary>
    /// <remarks>
    /// The JSON file is expected to be named "person1.json" and located in the application's base directory.
    /// </remarks>
    public static void DeserializePeople()
    {

        PrintCyan();

        var people = JsonSerializer.Deserialize<List<Person1>>(
            File.ReadAllText(fileName));

        AnsiConsole.MarkupLine($"{BeautifyPersonDump1(people.Dump())}");
    }

}
