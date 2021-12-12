using Hybrid.Models;

namespace HybridEncrypt.Strategy
{
    public class Context
    {
        private IProvider provider;
        public void SetProvider(IProvider provider)
        {
            this.provider = provider;
        }
        public string Encrypt(IEncryptionInfo info)
        {
            return provider.Encrypt(info);
        }
        public string Decrypt(IEncryptionInfo info)
        {
            return provider.Decrypt(info);
        }
    }
}
