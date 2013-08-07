using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Services;
using Infrastructure.SecurityApi.Models;

namespace Infrastructure.SecurityApi.Controllers
{
    using System.Text;
    using System.Web;

    public class TokenValidationController : ApiController
    {
        private readonly ITokenService _tokenService ;

        public TokenValidationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // GET api/tokenvalidation
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // POST api/tokenvalidation
        public bool Post(TokenValidationRequest request)
        {
            var token = Base64ForUrlDecode(request.Token);
            return _tokenService.ValidateToken(token, request.IpAddress);
        }

        private static string Base64ForUrlDecode(string encoded)
        {
            byte[] decodedBuffer = HttpServerUtility.UrlTokenDecode(encoded);
            return Encoding.UTF8.GetString(decodedBuffer);
        }
    }
}
