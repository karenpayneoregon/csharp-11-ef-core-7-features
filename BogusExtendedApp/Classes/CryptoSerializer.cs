using System.Security.Cryptography;
#pragma warning disable SYSLIB0021
#pragma warning disable SYSLIB0023

namespace BogusExtendedApp.Classes
{
    /// <summary>
    /// Serializer to encrypt/decrypt objects.
    /// </summary>
    /// <typeparam name="T">Type of object to serialize/deserialize.</typeparam>
    /// <remarks>
    /// Do not use this for a production project
    /// </remarks>
    public class CryptoSerializer<T>
    {
        private readonly byte[] _secretKey;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="secretKey">
        /// Secret key. Legal AES keys are 16, 24, or 32 bytes long.
        /// </param>
        public CryptoSerializer(byte[] secretKey)
        {
            _secretKey = secretKey;
        }

        /// <summary>
        /// Serialization callback that can be registered with 
        /// a cache using CacheBuilder.SetSerialization
        /// </summary>
        public void Serialize(List<T> list, Stream stream)
        {
            // The first 16 bytes of the serialized stream is the 
            // AES initialization vector. (An IV does not need to be
            // secret, but the same IV should never be used twice with
            // the same key.)
            byte[] iv = GenerateRandomBytes(16);
            stream.Write(iv, 0, 16);

            using AesCryptoServiceProvider aes = new();
            aes.Key = _secretKey;
            aes.IV = iv;

            CryptoStream cryptoStream = new(stream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            // Using protobuf-net for serialization
            // (but any serializer can be used to write to this CryptoStream).
            ProtoBuf.Serializer.Serialize(cryptoStream, list);

            cryptoStream.FlushFinalBlock();
        }

        /// <summary>
        /// Deserialization callback that can be registered with 
        /// a cache using CacheBuilder.SetSerialization
        /// </summary>
        public List<T> Deserialize(Stream stream)
        {
            // First 16 bytes is the initialization vector.
            byte[] ivBytes = new byte[16];
            stream.Read(ivBytes, 0, 16);

            using AesCryptoServiceProvider aes = new();
            aes.Key = _secretKey;
            aes.IV = ivBytes;

            CryptoStream cryptoStream = new(stream, aes.CreateDecryptor(), CryptoStreamMode.Read);

            return ProtoBuf.Serializer.Deserialize<List<T>>(cryptoStream);
        }

        public T DeserializeSingle(Stream stream) => Deserialize(stream).FirstOrDefault();


        private static readonly RNGCryptoServiceProvider provider = new();

        private static byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            provider.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}
