using System.Security.Cryptography;

namespace Core.Domain.Services
{
    public interface ICryptoService
    {
        IBuffer CreateHmac();

        bool VerifyHmac();
    }
}
