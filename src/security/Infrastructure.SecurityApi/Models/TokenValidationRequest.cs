using System;

namespace Infrastructure.SecurityApi.Models
{
    public class TokenValidationRequest
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
