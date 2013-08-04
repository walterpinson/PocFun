using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Core.Domain.Services;

namespace Infrastructure.Cryptography
{
    public class CryptoService : ICryptoService
    {
        private readonly ICryptoTransform _encryptor;
        private readonly ICryptoTransform _decryptor;
        private readonly UTF8Encoding _encoder;

        public CryptoService()
        {
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateIV();
            rm.GenerateKey();
            _encryptor = rm.CreateEncryptor(rm.Key, rm.IV);
            _decryptor = rm.CreateDecryptor(rm.Key, rm.IV);
            _encoder = new UTF8Encoding();

        }
        #region Implementation of ICryptoService

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(_encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return _encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, _encryptor);
        }

        public byte[] Decrypt(byte[] cipher)
        {
            return Transform(cipher, _decryptor);
        }

        #endregion

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
