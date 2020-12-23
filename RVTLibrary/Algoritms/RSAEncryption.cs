using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace RVTLibrary.Algoritms
{
    public class RSAEncryption
    {
        public static List<string> Encrypt(byte[] message, byte[] key)
        {
            var messageList = new List<byte[]>();
            var i = Math.Ceiling((decimal)message.Length / 300);
            var rest = message.Length % 300;
            int index = 0;
            for (int y = 1; y <= i; y++)
            {
                if (i != y)
                {
                    var copy = new byte[300];
                    Array.Copy(message, index, copy, 0, 300);
                    index += 300;
                    messageList.Add(copy);
                }
                else
                {
                    var copy = new byte[rest];
                    Array.Copy(message, message.Length - rest, copy, 0, rest);
                    messageList.Add(copy);
                }
            }
            ReadOnlySpan<byte> pubKey = key;
            var encrypt_provider = new RSACryptoServiceProvider(4096);
            encrypt_provider.ImportRSAPublicKey(pubKey, out int volume);
            var encrypted_strings = new List<string>();

            foreach (var part in messageList)
            {
                encrypted_strings.Add(Convert.ToBase64String(encrypt_provider.Encrypt(part, true)));
            }

          
           return encrypted_strings;
        }


        public static byte[] Decrypt(List<string> message, byte[] privkey)
        {
            ReadOnlySpan<byte> readOnlykey = privkey;
            var decrypt_provider = new RSACryptoServiceProvider(4096);
            decrypt_provider.ImportPkcs8PrivateKey(readOnlykey, out int volume);

            List<byte[]> content = new List<byte[]>();

            foreach (var msg in message)
            {
                content.Add(decrypt_provider.Decrypt(Convert.FromBase64String(msg), true));
            }

            var response = content.SelectMany(a => a).ToArray();
            return response;
        }

    }
}
