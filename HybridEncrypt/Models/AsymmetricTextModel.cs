namespace Hybrid.Models
{
    public class AsymmetricTextModel : IEncryptionInfo
    {
        public string Text { get; set; }
        public string Key { get; set; }
        public AsymmetricTextModel(string text, string key)
        {
            this.Text = text;
            this.Key = key;
        }
        public AsymmetricTextModel() { }
    }
}
