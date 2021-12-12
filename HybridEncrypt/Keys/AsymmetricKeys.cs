using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hybrid.Keys
{
    public class AsymmetricKeys
    {
        private static AsymmetricKeys _keys;
        private AsymmetricKeys() { }
        private static readonly object _lock = new object();

        private const string _privateKeyPath = "PrivateKey.private";
        private const string _publicKeyPath = "PublicKey.public";
        private const string _privateKeyPassword = "theorangeisinthehenhouse";
        private const string _salt = "AlekSandras";

        public static AsymmetricKeys GetInstance()
        {
            if (_keys == null)
            {
                lock (_lock)
                {
                    if (_keys == null)
                    {
                        _keys = new AsymmetricKeys();
                    }
                }
            }
            return _keys;
        }
        public string GetPublicKey()
        {
            if (!File.Exists(_privateKeyPath))
            {
                var keys = GenerateNewKeys(4096);
                WritePublicKey(_publicKeyPath, keys.PublicKey);
                WritePrivateKey(_privateKeyPath, keys.PrivateKey, _privateKeyPassword);
            }
            var publicKey = ReadPublicKey(_publicKeyPath);
            return publicKey;
        }
        public string GetPrivateKey(string privateKeyPassword)
        {
            if (privateKeyPassword != AsymmetricKeys._privateKeyPassword)
            {
                throw new ArgumentException(nameof(privateKeyPassword) + " is not valid password");
            }
            if (!File.Exists(_privateKeyPath))
            {
                var keys = GenerateNewKeys(4096);
                WritePublicKey(_publicKeyPath, keys.PublicKey);
                WritePrivateKey(_privateKeyPath, keys.PrivateKey, privateKeyPassword);
            }
            var privateKey = ReadPrivateKey(_privateKeyPath, privateKeyPassword);
            return privateKey;
        }
        private string ReadPrivateKey(string privateKeyFilePath, string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(_salt);
            byte[] privateKey = File.ReadAllBytes(privateKeyFilePath);

            using AesManaged aes = new AesManaged();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt);
            byte[] key = pdb.GetBytes(aes.KeySize / 8);
            byte[] iv = pdb.GetBytes(aes.BlockSize / 8);

            using var decryptor = aes.CreateDecryptor(key, iv);
            using Stream stream = new MemoryStream(privateKey);
            using CryptoStream cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read);
            using StreamReader privateKeyDecrypted = new StreamReader(cryptoStream);
            return privateKeyDecrypted.ReadToEnd();
        }

        private void WritePrivateKey(string privateKeyFilePath, string privateKey, string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(_salt);
            using AesManaged aes = new AesManaged();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt);
            byte[] key = pdb.GetBytes(aes.KeySize / 8);
            byte[] iv = pdb.GetBytes(aes.BlockSize / 8);

            using var encryptor = aes.CreateEncryptor(key, iv);
            using FileStream fileStream = new FileStream(privateKeyFilePath, FileMode.Create);
            using CryptoStream cryptoStream = new CryptoStream(fileStream, encryptor, CryptoStreamMode.Write);
            using StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(privateKey);
        }
        private void WritePublicKey(string publicKeyFilePath, string publicKey)
        {
            File.WriteAllText(publicKeyFilePath, publicKey);
        }
        private string ReadPublicKey(string publicKeyFilePath)
        {
            return File.ReadAllText(publicKeyFilePath);
        }
        public KeyPair GenerateNewKeys(int keySize = 4096)
        {
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize);
            return new KeyPair
            {
                PublicKey = rsa.ToXmlString(false),
                PrivateKey = rsa.ToXmlString(true)
            };
        }
    }
}
