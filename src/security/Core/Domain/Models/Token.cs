using System;

namespace Core.Domain.Models
{
    using Core.Domain.Services;

    public class Token
    {
        public string UserId { get; private set; }
        public string IpAddress { get; private set; }
        public DateTime IssueDate { get; private set; }
        public string Hmac { get; private set; }

        private IMessageAuthenticationService _messageAuthenticationService;

        public Token(string userId, string ipAddress, DateTime issueDate)
        {
            UserId = userId;
            IpAddress = ipAddress;
            IssueDate = issueDate;
        }

        public override string ToString()
        {

            return "hello.crtyptic.world";
            //return base.ToString();
        }

        public string Tokenize(IMessageAuthenticationService messageAuthenticationService)
        {
            _messageAuthenticationService = messageAuthenticationService;
            Hmac = GenerateHmac();

            return Hmac;
        }

        public bool IsValid(IMessageAuthenticationService messageAuthenticationService, string token, string ipAddress)
        {
            if (string.Equals(ipAddress, IpAddress))
            {
                _messageAuthenticationService = messageAuthenticationService;

                var validHmac = GenerateHmac();
                if (string.Equals(Hmac, validHmac)) return true;
            }

            return false;
        }

        private string GenerateHmac()
        {
            var message = string.Format("{0}:{1}:{2}", UserId, IpAddress, IssueDate.ToUniversalTime().ToString());
            return _messageAuthenticationService.CreateHmac(message);
        }
    }
}
