using System.Collections.Generic;
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
            return _tokenService.ValidateToken(request.Token, request.UserName, request.IpAddress, request.RequestDate);
        }
    }
}
