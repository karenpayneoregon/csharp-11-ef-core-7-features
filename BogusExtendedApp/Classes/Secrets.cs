namespace BogusExtendedApp.Classes;
public class Secrets
{
    // IMPORTANT:
    //  This cryptographic key is defined in code for demonstration purposes.
    //  Production keys should be stored in a secure location,
    //  (such as Azure Key Vault or AWS KMS) or protected using .NET's 
    //  ProtectedData class.
    public static readonly byte[] Key;

    static Secrets()
    {
        Key = [87, 167, 103, 151, 197, 100, 254, 130, 74,  59, 51,  28, 26, 230, 7, 97, 137, 224,  69,  23,  51, 110, 3,  37, 157,  41,  12, 12, 158,  24,  30,  86];
    }
}
