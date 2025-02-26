namespace BLL.Strategies
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string plainText);
    }
}
