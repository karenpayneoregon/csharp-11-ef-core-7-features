using BinaryFormatterAlternate.Models;
using MessagePack;

using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate.Classes;

/// <summary>
/// Provides operations for serializing and deserializing objects using the MessagePack library.
///
/// To keep easy to following no error handling is included in the methods and no encryption is used
/// as each developer will have their own requirements for error handling and encryption.
/// </summary>
internal class MessagePackOperations
{
    /// <summary>
    /// Serializes the first <see cref="Friend"/> object from a list to a binary file
    /// and then deserializes it back to a <see cref="Friend"/> object.
    /// </summary>
    /// <remarks>
    /// The method uses the MessagePack library for serialization and deserialization using Contractless process
    /// which is for when a developer can not set up properly as done with <see cref="Friend1"/>.
    ///
    /// MessagePack, using Contractless is slower than properly setting up as done with SingleFriend1 method below.
    /// </remarks>
    public static void SingleFriend()
    {

        PrintCyan();

        var fileName = "SingleFriend.bin";

        var list = MockedData.Friends();
        var friend = list[0];

        var bytes = MessagePackSerializer.Serialize(friend, 
            MessagePack.Resolvers.ContractlessStandardResolver.Options);

        File.WriteAllBytes(fileName, bytes);

        var bytes1 = File.ReadAllBytes(fileName);
        var deserialized = MessagePackSerializer.Deserialize<Friend>(bytes1, 
            MessagePack.Resolvers.ContractlessStandardResolver.Options);

        AnsiConsole.MarkupLine(BeautifyFriendDump(deserialized.Dump()));
    }

    /// <summary>
    /// Serializes a <see cref="Friend1"/> object to a binary file and then deserializes it back to a <see cref="Friend1"/> object.
    /// </summary>
    /// <remarks>
    /// The method uses the MessagePack library for serialization and deserialization with attributes and is the preferred
    /// path for new work. This is faster executing and more efficient than the Contractless process.
    /// </remarks>
    public static void SingleBinaryFriend1()
    {

        PrintCyan();

        var fileName = "SingleBinaryFriend1.bin";

        Friend1 friend = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1980, 1, 1),
            CellPhone = "555-555-5555"
        };

        // Serialize Friend to byte[]
        var bytes = MessagePackSerializer.Serialize(friend);

        var json = MessagePackSerializer.ConvertToJson(bytes);

        File.WriteAllBytes(fileName, bytes);
        // Deserialize byte[] to Friend
        var bytes1 = File.ReadAllBytes(fileName);
        var deserialized = MessagePackSerializer.Deserialize<Friend1>(bytes1);

        AnsiConsole.MarkupLine(BeautifyFriendDump(deserialized.Dump()));
    }

    /// <summary>
    /// Serializes a <see cref="Friend1"/> object to JSON using MessagePack, writes it to a file,
    /// reads the JSON from the file, deserializes it back to a <see cref="Friend1"/> object,
    /// and displays the deserialized object's details.
    /// </summary>
    /// <remarks>
    /// The method demonstrates the process of converting a <see cref="Friend1"/> object to a JSON string
    /// using MessagePack serialization, storing it in a file, and then reversing the process to retrieve
    /// and display the object's data.
    /// </remarks>
    public static void SingleJsonFriend1()
    {

        PrintCyan();

        var fileName = "SingleJsonFriend1.json";

        Friend1 friend = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1980, 1, 1),
            CellPhone = "555-555-5555"
        };

        var bytes = MessagePackSerializer.Serialize(friend);
        var json = MessagePackSerializer.ConvertToJson(bytes);

        File.WriteAllText(fileName, json);
        // Deserialize byte[] to Friend
        var json1 = File.ReadAllText(fileName);
        var bytes1 = MessagePackSerializer.ConvertFromJson(json1);

        var deserialized = MessagePackSerializer.Deserialize<Friend1>(bytes1);

        AnsiConsole.MarkupLine(BeautifyFriendDump(deserialized.Dump()));
    }
    public static void ListFriends()
    {

        PrintCyan();

        var fileName = "Friends.bin";

        var list = MockedData.Friends();
        

        // Serialize Friend to byte[]
        var bytes = MessagePackSerializer.Serialize(list, MessagePack.Resolvers.ContractlessStandardResolver.Options);
        File.WriteAllBytes(fileName, bytes);
        // Deserialize byte[] to Friend
        var bytes1 = File.ReadAllBytes(fileName);
        var deserialized = MessagePackSerializer.Deserialize<List<Friend>>(bytes1, MessagePack.Resolvers.ContractlessStandardResolver.Options);

        AnsiConsole.MarkupLine(BeautifyFriendDump(deserialized.Dump()));
    }
}
