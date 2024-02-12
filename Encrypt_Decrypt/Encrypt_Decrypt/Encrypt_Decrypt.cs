using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt
{
    public static class Encrypt_Decrypt
    {
        public static string encryptStringWithKey(string input, string key)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);

                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(input);
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);

                return Convert.ToBase64String(encryptedData);
            }
        }

        public static string decryptStringWithKey(string input, string key)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);

                byte[] dataToDecrypt = Convert.FromBase64String(input);
                byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);

                return Encoding.UTF8.GetString(decryptedData);
            }
        }

        public static string generatePrivateKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string privateKey = rsa.ToXmlString(true);
                return privateKey;
            }
        }
    }
}
