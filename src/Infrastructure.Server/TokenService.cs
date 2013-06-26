using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Core.Application.Services;

namespace Infrastructure.Server
{
    public class TokenService : ITokenService
    {
        public string Generate(string userId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  We won't pass any date/time to the validation function.  Instead we will use a
        ///  configurable TTL.  The validation will do a diff between the time embedded in the
        ///  token and now.  If the diff is greater than the TTL, the the token will be invalid.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public bool Validate(string token, string userId, string ipAddress)
        {
            throw new NotImplementedException();
        }
    }
}
