using System;
using System.Security.Cryptography;
using Core.Application.Services;
using Core.Domain.Models;

namespace Infrastructure.Server
{
    public class TokenService : ITokenService
    {
        private static byte[] _secretKeyHmac;
        private byte[] _secretKeyEncryption;

        #region Implementation of ITokenService

        public string GenerateToken(string userId, string ipAddress, DateTime issueDate)
        {
            // Algorithm
            // 1. Validate the input
            // 2. Create a token with the input
            // 3. Calculate the HMAC
            // 4. JSON-serialize the token object
            // 5. Encrypt the serialized token string
            // 6. Base64-encode this string
            var token = new Token(userId, ipAddress, issueDate);

            return token.Tokenize();
        }

        public bool ValidateToken(string token, string ipAddress)
        {
            // Algorithm
            // 1. Reconstruct the submitted Token object from the token string
            //    1.1 Base64-decode the token string
            //    1.2 Decrypt the token string
            //    1.3 JSON-deserialize the token object
            //    1.4 Check if the token is valid
            // 2. Generate a token based on the input
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
