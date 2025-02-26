using BLL.ServicesContracts;
using BLL.Strategies;

namespace BLL.Services
{
    public class EncryptionService : IEncryptionService
    {
        private IEncryptionStrategy _encryptionStrategy;

        // Sélectionne dynamiquement la stratégie de chiffrement
        public void SetEncryptionStrategy(string appType)
        {
            if (appType == "GrandPublic")
            {
                _encryptionStrategy = new AesEncryptionStrategy();
            }
            else if (appType == "Professionnelle")
            {
                _encryptionStrategy = new RsaEncryptionStrategy();
            }
            else
            {
                throw new ArgumentException("Type d'application non pris en charge");
            }
        }

        // Exécute le chiffrement
        public string EncryptPassword(string password)
        {
            if (_encryptionStrategy == null)
            {
                throw new InvalidOperationException("La stratégie de chiffrement n'a pas été définie.");
            }

            return _encryptionStrategy.Encrypt(password);
        }
    }
}
