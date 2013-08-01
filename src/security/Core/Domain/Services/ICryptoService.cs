﻿using System.Security.Cryptography;

namespace Core.Domain.Services
{
    public interface ICryptoService
    {
        byte[] Encrypt(byte[] buffer);
        byte[] Decrypt(byte[] cipher);
    }
}
