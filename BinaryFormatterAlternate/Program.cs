
using BinaryFormatterAlternate.Classes;
using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate;

internal partial class Program
{
    /// <summary>
    /// The main entry point for the application, which executes various serialization and deserialization samples.
    /// </summary>
    static void Main(string[] args)
    {
        

        if (Question("Run Protobuf samples?"))
        {
            ProtobufOperations.SerializePeople();
            ProtobufOperations.DeserializePeople();
        }


        if (Question("Run MessagePack samples?"))
        {
            MessagePackOperations.SingleFriend1();
            MessagePackOperations.SingleFriend();
            MessagePackOperations.ListFriends();
        }


        if (Question("Run System.Text.Json samples?",true))
        {
            SystemTextJsonOperations.SerializePeople();
            SystemTextJsonOperations.DeserializePeople();
        }

        if (Question("Run Inferno sample?", true))
        {
            InfernoOperations.EncryptDecrypt();
        }

        if (Question("Run DataContractSerializer sample?"))
        {
            DataContractSerializerOperations.SerializePeople();
        }

        ExitPrompt();

    }

}