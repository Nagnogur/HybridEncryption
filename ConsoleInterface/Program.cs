using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HybridEncryption.AsymmetricProvider;
using HybridEncryption.Hybrid;
using Newtonsoft.Json;

namespace Console1
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string privateKeyPath = "PrivateKey.private";
            string privateKeyPassword = "theorangeisinthehenhouse";

            var publicKeyPath = Path.ChangeExtension(privateKeyPath, ".public");

            if (!File.Exists(privateKeyPath))
            {
                var keys = AsymmetricProvider.GenerateNewKeyPair(4096);
                AsymmetricProvider.WritePublicKey(publicKeyPath, keys.PublicKey);
                AsymmetricProvider.WritePrivateKey(privateKeyPath, keys.PrivateKey, privateKeyPassword);
            }

            var privateKey = AsymmetricProvider.ReadPrivateKey(privateKeyPath, privateKeyPassword);
            var publicKey = AsymmetricProvider.ReadPublicKey(publicKeyPath);
            

            string text1 = "sandras";
            string password1 = "mypublic key";
            string text2 = "Ryan \"QuickSave\"";

            Hybrid h = new Hybrid();
            AsymmetricEncryptDecrypt asym = new AsymmetricEncryptDecrypt();

            var (Key, IVBase64) = h.InitSymmetricEncryptionKeyIV();
            Console.WriteLine("Key: " + Key);
            Console.WriteLine("IV: " + IVBase64);
            
            var encryptedText = h.Encrypt(text2, IVBase64, Key);

            var encryptedKey = AsymmetricProvider.EncryptString(Key,
                publicKey);

            var encryptedIV = AsymmetricProvider.EncryptString(IVBase64,
                publicKey);

            var encryptedDto = new
            {
                Text = encryptedText,
                Key = encryptedKey,
                IV = encryptedIV
            };

            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(encryptedDto);

            var encryptedDto2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(jsonString);

            var key = AsymmetricProvider.DecryptString(encryptedDto2.Key,
                privateKey);
            Console.WriteLine("key: " + key);


            var IV = AsymmetricProvider.DecryptString(encryptedDto2.IV,
                privateKey);
            Console.WriteLine("IV: " + IV);

            var text = h.Decrypt(encryptedDto2.Text, IV, key);

            Console.WriteLine($"{text}");
            /*var (Key, IVBase64) = h.InitSymmetricEncryptionKeyIV();
            var encrypted = h.Encrypt(text2, IVBase64, Key);

            Console.WriteLine("-- Key --");
            Console.WriteLine(Key);
            Console.WriteLine("-- IVBase64 --");
            Console.WriteLine(IVBase64);

            Console.WriteLine("");
            Console.WriteLine("-- Encrypted Text --");
            Console.WriteLine(encrypted);

            var decrypted = h.Decrypt(encrypted, IVBase64, Key);
            Console.WriteLine("");
            Console.WriteLine("-- Decrypted Text --");
            Console.WriteLine(decrypted);*/

            /*string encr = AsymmetricProvider.EncryptString(text1, keys.PublicKey);
            Console.WriteLine(encr);
            string decr = AsymmetricProvider.DecryptString(encr, keys.PrivateKey);
            Console.WriteLine(decr);
            Console.WriteLine(encr.Length);*/

            /*string encr2 = AsymmetricProvider.EncryptString(text2, keys.PublicKey);
            Console.WriteLine(encr2);
            string decr2 = AsymmetricProvider.DecryptString(encr2, keys.PrivateKey);
            Console.WriteLine(decr2);
            Console.WriteLine(encr2.Length);*/
            Console.ReadKey();
        }
    }
}

        /*private static void HybridCryptoTest(string privateKeyPath, string privateKeyPassword, string inputPath)
        {
            // Setup the test
            var publicKeyPath = Path.ChangeExtension(privateKeyPath, ".public");
            var outputPath = Path.Combine(Path.ChangeExtension(inputPath, ".enc"));
            var testPath = Path.Combine(Path.ChangeExtension(inputPath, ".test"));

            if (!File.Exists(privateKeyPath))
            {
                var keys = AsymmetricProvider.GenerateNewKeyPair(2048);
                AsymmetricProvider.WritePublicKey(publicKeyPath, keys.PublicKey);
                AsymmetricProvider.WritePrivateKey(privateKeyPath, keys.PrivateKey, privateKeyPassword);
            }

            // Encrypt the file
            var publicKey = AsymmetricProvider.ReadPublicKey(publicKeyPath);
            AsymmetricProvider.EncryptFile(inputPath, outputPath, publicKey);

            // Decrypt it again to compare against the source file
            var privateKey = AsymmetricProvider.ReadPrivateKey(privateKeyPath, privateKeyPassword);
            AsymmetricProvider.DecryptFile(outputPath, testPath, privateKey);

            // Check that the two files match
            var source = File.ReadAllBytes(inputPath);
            var dest = File.ReadAllBytes(testPath);

            if (source.Length != dest.Length)
                throw new Exception("Length does not match");

            if (source.Where((t, i) => t != dest[i]).Any())
                throw new Exception("Data mismatch");
        }
        static void Main(string[] args)
        {
            string privateKeyPath = @"D:\Курсовая\3 курс 1 семестр\HybridEncryption\ConsoleInterface\bin\Debug\PrivateKey.txt";
            string inputPath = @"D:\Курсовая\3 курс 1 семестр\HybridEncryption\ConsoleInterface\bin\Debug\Input.txt";
            HybridCryptoTest(privateKeyPath, "hmm,idk", inputPath);
        }
    }
}*/
