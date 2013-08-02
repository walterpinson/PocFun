using System;
using Core.Application.Services;
using Core.Domain.Models;

namespace Infrastructure.Server
{
    using Core.Domain.Services;

    using Newtonsoft.Json;

    public class TokenService : ITokenService
    {
        private IMessageAuthenticationService _messageAuthenticationService;
        
        public TokenService(IMessageAuthenticationService messageAuthenticationService)
        {
            _messageAuthenticationService = messageAuthenticationService;
        }

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
            /////////////////////////////////////////////////////////////////////////
            
            // 1. Validate the input
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(ipAddress) || DateTime.MinValue == issueDate
               || DateTime.MaxValue == issueDate)
            {
                throw new Exception();
            }

            // 2. Create a token with the input
            var token = new Token(userId, ipAddress, issueDate);

            // 3. Calculate the HMAC
            token.Tokenize(_messageAuthenticationService);

            // 4. JSON-serialize the token
            var serializedToken = JsonConvert.SerializeObject(token);

            // 5. & 6. Encrypt and  Base64-encode this string
            var encryptedToken = serializedToken;

            return encryptedToken;
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
    }
}
