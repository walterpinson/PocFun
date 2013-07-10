namespace Core.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string ipAddress);
        bool ValidateToken(string token, string userId, string ipAddress);
    }
}
