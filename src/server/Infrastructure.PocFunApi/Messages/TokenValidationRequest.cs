namespace Infrastructure.PocFunApi.Messages
{
    public class TokenValidationRequest
    {
        public string Token { get; set; }
        public string IpAddress { get; set; }
    }
}