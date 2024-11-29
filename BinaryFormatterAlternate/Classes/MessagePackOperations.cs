using BinaryFormatterAlternate.Models;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFormatterAlternate.Classes;
internal class MessagePackOperations
{
    public static void SingleFriend()
    {
        var fileName = "SingleFriend.bin";

        var list = MockedData.Friends();
        var friend = list[0];

        // Serialize object to byte[]
        var bytes = MessagePackSerializer.Serialize(friend);
        File.WriteAllBytes(fileName, bytes);
        // Deserialize byte[] to Friend
        var bytes1 = File.ReadAllBytes(fileName);
        var deserialized = MessagePackSerializer.Deserialize<Friend>(bytes1);
        Console.WriteLine(deserialized.Dump());
    }
}
