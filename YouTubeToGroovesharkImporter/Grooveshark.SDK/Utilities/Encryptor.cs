using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Utilities
{
    /// <summary>
    /// Contains Methods For Text Encryption
    /// </summary>
    public static class Encryptor
    {
        /// <summary>
        /// Encrypts string using MD5s encrypt.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="secret">The secret.</param>
        /// <returns>encrypted md5 hash</returns>
        public static string Md5Encrypt(string message, string secret = null)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            HMACMD5 hmacmd5;
            if (string.IsNullOrEmpty(secret))
            {
                hmacmd5 = new HMACMD5();
            }
            else
            {
                byte[] keyByte = encoding.GetBytes(secret);
                hmacmd5 = new HMACMD5(keyByte);
            }

            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacmd5.ComputeHash(messageBytes);
            string result = ByteToString(hashmessage);

            return result;
        }

        /// <summary>
        /// Calculates the m d5 hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Bytes to string.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <returns>byty array string representation</returns>
        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return (sbinary);
        }  
    }
}
