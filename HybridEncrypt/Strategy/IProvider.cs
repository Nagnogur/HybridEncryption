using Hybrid.Models;

namespace HybridEncrypt.Strategy
{
    public interface IProvider
    {
        public string Encrypt(IEncryptionInfo info);
        public string Decrypt(IEncryptionInfo info);
    }
}
