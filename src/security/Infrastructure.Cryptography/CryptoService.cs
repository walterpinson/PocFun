using Core.Domain.Services;

namespace Infrastructure.Cryptography
{
    public class CryptoService : ICryptoService
    {
        #region Implementation of ICryptoService

        public string Encrypt(string buffer)
        {
            return buffer;
        }

        public string Decrypt(string cipher)
        {
            return cipher;
        }

        #endregion
    }
}
