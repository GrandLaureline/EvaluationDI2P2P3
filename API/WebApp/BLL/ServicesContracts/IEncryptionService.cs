namespace BLL.ServicesContracts
{
    public interface IEncryptionService
    {
        void SetEncryptionStrategy(string appType);

        string EncryptPassword(string password);
    }
}
