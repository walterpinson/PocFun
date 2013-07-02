using System;
using System.Security.Cryptography;
using Core.Application.Services;

namespace Infrastructure.Server
{
    public class TokenService : ITokenService
    {
        private byte[] _secretKeyHmac;
        private byte[] _secretKeyEncryption;

        #region Implementation of ITokenService

        public string Generate(string userId, string ipAddress)
        {
            _secretKeyHmac = new byte[64];
            using(var rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically strong random bytes
                rng.GetBytes(_secretKeyHmac);
            }
            return "hello_secret";
        }

        /// <summary>
        ///  We won't pass any date/time to the validation function.  Instead we will use a
        ///  configurable TTL.  The validation will do a diff between the time embedded in the
        ///  token and now.  If the diff is greater than the TTL, the the token will be invalid.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public bool Validate(string token, string userId, string ipAddress)
        {
            throw new NotImplementedException();
   
        }

        #endregion

    }
}
