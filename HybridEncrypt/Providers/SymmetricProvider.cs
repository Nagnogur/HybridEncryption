using System;
using System.Security.Cryptography;
using System.Text;
using Hybrid.Models;
using HybridEncrypt.Strategy;

namespace Hybrid.Providers.Symmetric
{
    public class SymmetricProvider : IProvider
    {
        public Aes CreateAES(string key)
        {
            Aes aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.Key = Convert.FromBase64String(key);
            return aes;
        }
        public string Encrypt(IEncryptionInfo info)
        {
            Aes aes = CreateAES(info.Key);
            aes.IV = Convert.FromBase64String(((SymmetricTextModel)info).IV);
            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(info.Text);
            byte[] encryptedText = encryptor.TransformFinalBlock(plainText, 0, plainText.Length);

            return Convert.ToBase64String(encryptedText);
        }
        public string Decrypt(IEncryptionInfo info)
        {
            try
            {
                Aes aes = CreateAES(info.Key);
                aes.IV = Convert.FromBase64String(((SymmetricTextModel)info).IV);
                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64String(info.Text);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                string decrypted = Encoding.UTF8.GetString(decryptedBytes);
                return decrypted;
            }
            catch (CryptographicException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
