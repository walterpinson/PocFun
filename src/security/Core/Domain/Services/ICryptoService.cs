namespace Core.Domain.Services
{
    public interface ICryptoService
    {
        byte[] Encrypt(byte[] buffer);
        byte[] Decrypt(byte[] cipher);

        string Encrypt(string unencrypted);
        string Decrypt(string encrypted);
    }
}
