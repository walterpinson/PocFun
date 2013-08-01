﻿using System;

namespace Core.Domain.Models
{
    public class Token
    {
        public string UserId { get; private set; }
        public string IpAddress { get; private set; }
        public DateTime IssueDate { get; private set; }
        public string Hmac { get; private set; }

        private bool _isTokenized = false;
        private string _secretKey = null;

        public Token(string userId, string ipAddress, DateTime issueDate)
        {
            UserId = userId;
            IpAddress = ipAddress;
            IssueDate = issueDate;
        }

        public override string ToString()
        {
            if (!_isTokenized)
                Tokenize();

            return "hello.crtyptic.world";
            //return base.ToString();
        }

        public string Tokenize(string secret)
        {
            return "hello.world";
        }

        public string Tokenize()
        {
            return "hello.world";
        }

        public bool IsValid(string token)
        {
            return true;
        }
    }
}
