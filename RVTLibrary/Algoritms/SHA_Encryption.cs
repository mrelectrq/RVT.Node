using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RVTLibrary.Algoritms
{
    public class SHA_Encryption
    {
        private readonly SHA256 _encrypt;
        public SHA_Encryption()
        {
            _encrypt = SHA256.Create();
        }

        public string GetHash(string data)
        {
            
            var bytes = Encoding.UTF8.GetBytes(data);
            var hashByte = _encrypt.ComputeHash(bytes);
            var hash = BitConverter.ToString(hashByte);

            var formattedHash = hash.Replace("-", "")
                                    .ToLower();

            return formattedHash;
        }
    }
}
