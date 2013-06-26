using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface ITokenService
    {
        string Generate(string userId, string ipAddress, string userAgent);
        bool Validate(string token);
    }
}
