using System;

namespace Infrastructure.Cryptography
{
    using System.Security.Cryptography;
    using System.Text;

    using Core.Domain.Services;

    public class MessageAuthenticationService : IMessageAuthenticationService
    {
        private byte[] _secretKey;

        public MessageAuthenticationService()
        {
            _secretKey = new byte[64];
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically strong random bytes
                rng.GetBytes(_secretKey);
            }
        }

        public string CreateHmac(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            string signature;

            using (var hmac = new HMACSHA256(_secretKey))
            {
                var hash = hmac.ComputeHash(messageBytes);
                signature = Convert.ToBase64String(hash);
            }

            return signature;
        }
    }
}

