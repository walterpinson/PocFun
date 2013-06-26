using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface ITokenService
    {
        string Generate(string userId, string ipAddress);
        bool Validate(string token, string userId, string ipAddress);
    }
}
