using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface ITokenProvider
    {
        string GenerateToken(string userId, string ipAddress);
        bool ValidateToken(string token, string userId, string ipAddress);
    }
}
