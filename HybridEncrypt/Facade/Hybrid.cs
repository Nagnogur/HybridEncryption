using Hybrid.Keys;
using Hybrid.Models;
using HybridEncrypt.Strategy;
using Hybrid.Providers.Asymmetric;
using Hybrid.Providers.Symmetric;

namespace Hybrid
{
    public class HybridProvider
    {
        public SymmetricTextModel HybridEncryption(string plainText)
        {
            SymmetricKeyModel symmetricKey = SymmetricKeys.GetInstance().CreateSymmetricKeys();

            var provider = new Context();
            provider.SetProvider(new SymmetricProvider());

            var encryptedText = provider.Encrypt(new SymmetricTextModel(plainText, symmetricKey.Key, symmetricKey.IV));
            provider.SetProvider(new AsymmetricProvider());
            
            var publicKey = AsymmetricKeys.GetInstance().GetPublicKey();
            var encryptedKey = provider.Encrypt(new AsymmetricTextModel(symmetricKey.Key, publicKey));
            var encryptedIV = provider.Encrypt(new AsymmetricTextModel(symmetricKey.IV, publicKey));

            SymmetricTextModel encrypted = new SymmetricTextModel
            {
                Text = encryptedText,
                Key = encryptedKey,
                IV = encryptedIV
            };
            return encrypted;
        }

        public string HybridDecryption(SymmetricTextModel encrypted)
        {
            var privateKey = AsymmetricKeys.GetInstance().GetPrivateKey("theorangeisinthehenhouse");

            var provider = new Context();
            provider.SetProvider(new AsymmetricProvider());      

            var key = provider.Decrypt(new AsymmetricTextModel(encrypted.Key, privateKey));
            var IV = provider.Decrypt(new AsymmetricTextModel(encrypted.IV, privateKey));
            if (key is null || IV is null)
            {
                return null;
            }
            provider.SetProvider(new SymmetricProvider());

            var decrypted = provider.Decrypt(new SymmetricTextModel(encrypted.Text, key, IV));
            return decrypted;
        }
    }
}
