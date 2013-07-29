using System;
using System.Security.Cryptography;
using Core.Application.Services;

namespace Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private static byte[] _secretKeyHmac;
        private byte[] _secretKeyEncryption;

        #region Implementation of ITokenProvider

        public string GenerateToken(string userId, string ipAddress, DateTime issueDate)
        {
            var token = new Token();

            return token.Tokenize();
        }

        public bool ValidateToken(string token, string userId, string ipAddress, DateTime issueDate)
        {
            return true;
        }

        #endregion

        public static void Initialize()
        {
            _secretKeyHmac = new byte[64];
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically strong random bytes
                rng.GetBytes(_secretKeyHmac);
            }
        }
    }
}
