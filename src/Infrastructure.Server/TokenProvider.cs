using System;
using System.Security.Cryptography;
using Core.Application.Services;

namespace Infrastructure.Server
{
    public class TokenProvider : ITokenProvider
    {
        private byte[] _secretKeyHmac;
        private byte[] _secretKeyEncryption;

        #region Implementation of ITokenProvider

        public string GenerateToken(string userId, string ipAddress)
        {
            return "hello.token";
        }

        public bool ValidateToken(string token, string userId, string ipAddress)
        {
            return true;
        }

        #endregion
    }
}
