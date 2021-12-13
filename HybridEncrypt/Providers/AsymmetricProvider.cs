using Hybrid.Models;
using HybridEncrypt.Strategy;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Hybrid.Providers.Asymmetric
{
    public class AsymmetricProvider : IProvider
    {
        private byte[] EncryptData(byte[] data, string publicKey, int keySize = 7680)
        {
            using RSACryptoServiceProvider provider = new RSACryptoServiceProvider(keySize);
            provider.FromXmlString(publicKey);
            return provider.Encrypt(data, true);
        }

        private byte[] DecryptData(byte[] data, string privateKey, int keySize = 7680)
        {
            using RSACryptoServiceProvider provider = new RSACryptoServiceProvider(keySize);
            provider.FromXmlString(privateKey);
            if (provider.PublicOnly)
                throw new CryptographicException("Only public key is given");
            try
            {
                return provider.Decrypt(data, true);
            }
            catch (CryptographicException)
            {
                throw new ArgumentException("Invalid input");
            }
        }

        public string Encrypt(IEncryptionInfo info)
        {
            return Convert.ToBase64String(EncryptData(Encoding.UTF8.GetBytes(info.Text), info.Key));
        }
        public string Decrypt(IEncryptionInfo info)
        {
            try
            {
                return Encoding.UTF8.GetString(DecryptData(Convert.FromBase64String(info.Text), info.Key));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}