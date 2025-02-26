using System.Security.Cryptography;
using System.Text;

namespace BLL.Strategies
{
    public class RsaEncryptionStrategy : IEncryptionStrategy
    {
        private readonly RSA _rsa;

        public RsaEncryptionStrategy()
        {
            _rsa = RSA.Create();
            // Charger la clé publique
            _rsa.ImportFromPem(File.ReadAllText("publicKey.pem"));
        }

        public string Encrypt(string plainText)
        {
            var data = Encoding.UTF8.GetBytes(plainText);
            var encryptedData = _rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }
    }
}
