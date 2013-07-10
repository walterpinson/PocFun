using System;
using System.Security.Cryptography;
using Core.Application.Services;

namespace Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private byte[] _secretKeyHmac;
        private byte[] _secretKeyEncryption;

        #region Implementation of ITokenProvider

        public string GenerateToken(string userId, string ipAddress)
        {
            _secretKeyHmac = new byte[64];
            using(var rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically strong random bytes
                rng.GetBytes(_secretKeyHmac);
            }

            var token = new Token("user","127.0.0.1");

            return token.Tokenize();
        }

        public bool ValidateToken(string token, string userId, string ipAddress)
        {
            return true;
        }

        #endregion
    }
}
