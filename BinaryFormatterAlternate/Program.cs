
using BinaryFormatterAlternate.Classes;
using static BinaryFormatterAlternate.Classes.SpectreConsoleHelpers;

namespace BinaryFormatterAlternate;


internal partial class Program
{

    static void Main(string[] args)
    {
        
        if (Question("Run Protobuf samples?"))
        {
            ProtobufOperations.SerializePeople();
            ProtobufOperations.DeserializePeople();
        }
        
        if (Question("Run MessagePack samples?"))
        {
            MessagePackOperations.SingleBinaryFriend1();
            MessagePackOperations.SingleFriend();
            MessagePackOperations.ListFriends();
            MessagePackOperations.SingleJsonFriend1();
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