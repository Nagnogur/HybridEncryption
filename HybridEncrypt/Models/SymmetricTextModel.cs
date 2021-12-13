namespace Hybrid.Models
{
    public class SymmetricTextModel : IEncryptionInfo
    {
        public string Text { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }
        public SymmetricTextModel(string text, string key, string iv)
        {
            Text = text;
            Key = key;
            IV = iv;
        }
        public SymmetricTextModel() { }
    }
}
