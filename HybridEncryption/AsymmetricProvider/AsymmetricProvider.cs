using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HybridEncryption.AsymmetricProvider
{
    public static class AsymmetricProvider
    {
        public class KeyPair
        {
            public string PublicKey { get; set; }
            public string PrivateKey { get; set; }
        }

        public static KeyPair GenerateNewKeyPair(int keySize = 4096)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))
            {
                return new KeyPair { PublicKey = rsa.ToXmlString(false), 
                                     PrivateKey = rsa.ToXmlString(true) };
            }
        }

        public static byte[] EncryptData(byte[] data, string publicKey, int keySize = 4096)
        {
            using (RSACryptoServiceProvider asymmetricProvider = new RSACryptoServiceProvider(keySize))
            {
                asymmetricProvider.FromXmlString(publicKey);
                return asymmetricProvider.Encrypt(data, true);
            }
        }

        public static byte[] DecryptData(byte[] data, string publicKey, int keySize = 4096)
        {
            using (RSACryptoServiceProvider asymmetricProvider = new RSACryptoServiceProvider(keySize))
            {
                asymmetricProvider.FromXmlString(publicKey);
                if (asymmetricProvider.PublicOnly)
                    throw new CryptographicException("The key does not contain the private key");
                return asymmetricProvider.Decrypt(data, true);
            }
        }

        public static string EncryptString(string value, string publicKey)
        {
            return Convert.ToBase64String(EncryptData(Encoding.UTF8.GetBytes(value), publicKey));
        }

        public static string DecryptString(string value, string privateKey)
        {
            return Encoding.UTF8.GetString(EncryptData(Convert.FromBase64String(value), privateKey));
        }
    }
}