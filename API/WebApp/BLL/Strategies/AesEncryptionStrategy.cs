using System.Security.Cryptography;
using System.Text;

namespace BLL.Strategies
{
    public class AesEncryptionStrategy : IEncryptionStrategy
    {
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException("Le texte à chiffrer ne peut pas être vide.", nameof(plainText));
            }

            try
            {
                using (var aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = 256;  // Choisir AES-256 (32 octets pour la clé)
                    aesAlg.BlockSize = 128; // Taille du bloc de données (128 bits / 16 octets pour AES)
                    aesAlg.GenerateKey();  // Générer la clé aléatoirement
                    aesAlg.GenerateIV();   // Générer l'IV aléatoirement

                    using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                        swEncrypt.Flush();
                        csEncrypt.FlushFinalBlock();
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch (CryptographicException ex)
            {
                throw new Exception("Erreur lors du chiffrement.", ex);
            }
        }
    }
}
