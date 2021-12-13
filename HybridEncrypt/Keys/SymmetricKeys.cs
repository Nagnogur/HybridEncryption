using System;
using System.Security.Cryptography;
using Hybrid.Providers.Symmetric;
using Hybrid.Models;

namespace Hybrid.Keys
{
    public class SymmetricKeys
    {
        private static SymmetricKeys _keys;
        private SymmetricKeys() { }
        private static readonly object _lock = new object();
        public static SymmetricKeys GetInstance()
        {
            if (_keys == null)
            {
                lock (_lock)
                {
                    if (_keys == null)
                    {
                        _keys = new SymmetricKeys();
                    }
                }
            }
            return _keys;
        }
        public SymmetricKeyModel CreateSymmetricKeys()
        {
            SymmetricKeys keys = new SymmetricKeys();
            SymmetricProvider symmetricProvider = new SymmetricProvider();

            string key = keys.GetRandomString(32);
            Aes aes = symmetricProvider.CreateAES(key);
            string IV = Convert.ToBase64String(aes.IV);
            return new SymmetricKeyModel { Key = key, IV = IV };
        }
        private string GetRandomString(int length)
        {
            string randomString = Convert.ToBase64String(GetRandomByteArray(length));
            return randomString;
        }
        private byte[] GetRandomByteArray(int length)
        {
            var byteArray = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return byteArray;
        }
    }
}
