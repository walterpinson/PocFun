using System;

namespace Infrastructure.PocFunApi.Models
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
