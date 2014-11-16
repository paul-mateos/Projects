using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AutomationTestAssistantCore
{
    public class UnitTestIdGenerator
    {
        private static HashAlgorithm s_provider = new SHA1CryptoServiceProvider();

        public static HashAlgorithm Provider
        {
            get { return s_provider; }
        }

        /// 
        /// Calculates a hash of the string and copies the first 128 bits of the hash
        /// to a new Guid.
        /// 
        public static Guid GuidFromString(string data)
        {
            byte[] hash = Provider.ComputeHash(System.Text.Encoding.Unicode.GetBytes(data));

            byte[] toGuid = new byte[16];
            Array.Copy(hash, toGuid, 16);

            return new Guid(toGuid);
        }
    }
}
