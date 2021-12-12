using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace HybridEncryption.Hybrid
{
    public class DTO
    {
        public string Text;
        public string Key;
        public string IV;
    }
    public class Hybrid
    {
        public (string Key, string IVBase64) InitSymmetricEncryptionKeyIV()
        {
            var key = GetEncodedRandomString(32); // 256
            Aes cipher = CreateCipher(key);
            var IVBase64 = Convert.ToBase64String(cipher.IV);
            return (key, IVBase64);
        }
        private string GetEncodedRandomString(int length)
        {
            var base64 = Convert.ToBase64String(GenerateRandomBytes(length));
            return base64;
        }
        private byte[] GenerateRandomBytes(int length)
        {
            var byteArray = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return byteArray;
        }
        private Aes CreateCipher(string keyBase64)
        {
            // Default values: Keysize 256, Padding PKC27
            Aes cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC; // Ensure the integrity of the ciphertext if using CBC
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }
        public string Encrypt(string text, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }
        public string Decrypt(string encryptedText, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
    public class AsymmetricEncryptDecrypt
    {
        // Encrypt with RSA using public key
        public string Encrypt(string text, RSA rsa)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(cipherText);
        }
        public string Decrypt(string text, RSA rsa)
        {
            byte[] data = Convert.FromBase64String(text);
            byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(cipherText);
        }
    }

    public static class Utils
    {
        public static RSA CreateRsaPublicKey(X509Certificate2 certificate)
        {
            RSA publicKeyProvider = certificate.GetRSAPublicKey();
            return publicKeyProvider;
        }

        public static RSA CreateRsaPrivateKey(X509Certificate2 certificate)
        {
            RSA privateKeyProvider = certificate.GetRSAPrivateKey();
            return privateKeyProvider;
        }
    }

}
