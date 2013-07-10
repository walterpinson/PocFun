using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infrastructure.Security;

namespace Infrastructure.PocFunApi.Controllers
{
    using Core.Application.Services;

    public class SecurityController : ApiController
    {
        private ITokenService _tokenService;

        public SecurityController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // Request a token
        [HttpPost]
        [ActionName("GetToken")]
        public string GetToken(TokenRequest tokenRequest)
        {
            return _tokenService.GenerateToken(tokenRequest.UserId, tokenRequest.IpAddress);
        }

        // GET api/security
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/security/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/security
        public void Post([FromBody]string value)
        {
        }

        // PUT api/security/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/security/5
        public void Delete(int id)
        {
        }
    }
}
