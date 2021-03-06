﻿using System;
using System.Globalization;
using Core.Domain.Services;

namespace Core.Domain.Models
{

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

        public string Tokenize(IMessageAuthenticationService messageAuthenticationService)
        {
            _messageAuthenticationService = messageAuthenticationService;
            Hmac = GenerateHmac();

            return Hmac;
        }

        public bool IsValid(IMessageAuthenticationService messageAuthenticationService, string ipAddress)
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
            var message = string.Format("{0}:{1}:{2}", UserId, IpAddress, IssueDate.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
            return _messageAuthenticationService.CreateHmac(message);
        }
    }
}
