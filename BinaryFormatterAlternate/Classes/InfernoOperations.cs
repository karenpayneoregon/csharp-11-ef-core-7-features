using SecurityDriven.Inferno;
using System.Security.Cryptography;
using System.Text.Json;
using BinaryFormatterAlternate.Models;
using Spectre.Console.Json;

namespace BinaryFormatterAlternate.Classes;

/// <summary>
/// Provides operations for encrypting, decrypting, and authenticating files using the Inferno library.
/// All code came from the Inferno library's documentation AEAD Transform (Streaming)
/// </summary>
/// <remarks>
/// This class includes methods to encrypt and decrypt files, authenticate encrypted data, and display
/// decrypted content with customized JSON formatting using Spectre.Console.
///
/// For a real application encryptedFilename and decryptedFilename would be the same file name, here they are different
/// to show the process in steps
/// </remarks>
internal class InfernoOperations
{
    private static CryptoRandom random = new();
    private static byte[] key = random.NextBytes(32);

    private static string originalFilename = @"person1.json";

    private static string encryptedFilename = $"{originalFilename}.enc{Path.GetExtension(originalFilename)}";
    private static string decryptedFilename = $"{originalFilename}.dec{Path.GetExtension(originalFilename)}";

    /// <summary>
    /// Encrypts the content of a specified file using a predefined key and writes the encrypted data to a new file.
    /// </summary>
    /// <remarks>
    /// This method reads the content of the original file, encrypts it using the EtM (Encrypt-then-MAC) transform,
    /// and writes the encrypted data to a file with an ".enc" extension.
    /// </remarks>
    /// <exception cref="IOException">
    /// Thrown when an I/O error occurs during file operations.
    /// </exception>
    /// <exception cref="CryptographicException">
    /// Thrown when an error occurs during the encryption process.
    /// </exception>
    public static void Encrypt()
    {
        using var originalStream = new FileStream(originalFilename, FileMode.Open);
        using var encryptedStream = new FileStream(encryptedFilename, FileMode.Create);
        using var encTransform = new EtM_EncryptTransform(key: key);
        using var cryptoStream = new CryptoStream(encryptedStream, encTransform, CryptoStreamMode.Write);

        originalStream.CopyTo(cryptoStream);

    }

    /// <summary>
    /// Decrypts an encrypted file using a specified key and writes the decrypted content to a new file.
    /// </summary>
    /// <exception cref="Exception">
    /// Thrown when not all blocks are decrypted successfully.
    /// </exception>
    public static void Decrypt()
    {
        using var encryptedStream = new FileStream(encryptedFilename, FileMode.Open);
        using var decryptedStream = new FileStream(decryptedFilename, FileMode.Create);

        using (var decTransform = new EtM_DecryptTransform(key: key))
        {
            using (var cryptoStream = new CryptoStream(encryptedStream, decTransform, CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(decryptedStream);
            }

            if (!decTransform.IsComplete) throw new Exception("Not all blocks are decrypted.");

        }
    }

    /// <summary>
    /// Authenticates the encrypted data by verifying its integrity without decrypting it.
    /// </summary>
    /// <exception cref="Exception">
    /// Thrown when not all blocks are authenticated successfully.
    /// </exception>
    public static void Authenticate()
    {
        using var encryptedStream = new FileStream(encryptedFilename, FileMode.Open);
        using var decTransform = new EtM_DecryptTransform(key: key, authenticateOnly: true);
        using (var cryptoStream = new CryptoStream(encryptedStream, decTransform, CryptoStreamMode.Read))
        {
            cryptoStream.CopyTo(Stream.Null);
        }

        if (!decTransform.IsComplete) throw new Exception("Not all blocks are authenticated.");
    }

    /// <summary>
    /// Encrypts and decrypts a JSON file, then displays the decrypted content
    /// with customized JSON formatting using Spectre.Console.
    /// </summary>
    /// <remarks>
    /// This method first encrypts the content of a JSON file, then decrypts it.
    /// After decryption, it customizes the JSON output with colors and displays
    /// it in a formatted panel using Spectre.Console.
    /// </remarks>
    public static void EncryptDecrypt()
    {

        Encrypt();

        Decrypt();

        /*
         * Customize the JSON output with colors using Spectre.Console
         */
        var jsonText = new JsonText(File.ReadAllText(decryptedFilename))
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
                .Header("People decrypted")
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow));

        var people = JsonSerializer.Deserialize<List<Person1>>(
            File.ReadAllText(decryptedFilename));
    }
}
