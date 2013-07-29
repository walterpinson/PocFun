using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Services;
using Infrastructure.SecurityApi.Models;

namespace Infrastructure.SecurityApi.Controllers
{
    public class TokenRequestController : ApiController
    {
        private readonly ITokenService _tokenService ;

        public TokenRequestController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // GET api/tokenrequest
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // POST api/tokenrequest
        public string Post(TokenRequest request)
        {
            return _tokenService.GenerateToken(request.UserName, request.IpAddress, request.RequestDate);
        }
    }
}
