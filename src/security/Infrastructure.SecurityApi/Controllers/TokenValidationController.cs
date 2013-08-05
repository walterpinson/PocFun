using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using Core.Application.Services;
using Infrastructure.SecurityApi.Models;

namespace Infrastructure.SecurityApi.Controllers
{
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
            var ipAddress = GetRequestIpAddress();
            return _tokenService.ValidateToken(request.Token, ipAddress);
        }

        private static string GetRequestIpAddress()
        {
            var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}
