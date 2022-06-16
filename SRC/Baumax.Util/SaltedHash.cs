using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Baumax.Util
{
    public static class SaltHashing
    {
        public static string ComputeSaltedHash(string text, int salt)
        {
            // Create Byte array of password string
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] secretBytes = encoder.GetBytes(text);

            // Create a new salt
            Byte[] saltBytes = new Byte[4];
            saltBytes[0] = (byte)(salt >> 24);
            saltBytes[1] = (byte)(salt >> 16);
            saltBytes[2] = (byte)(salt >> 8);
            saltBytes[3] = (byte)(salt);

            // append the two arrays
            Byte[] toHash = new Byte[secretBytes.Length + saltBytes.Length];
            Array.Copy(secretBytes, 0, toHash, 0, secretBytes.Length);
            Array.Copy(saltBytes, 0, toHash, secretBytes.Length, saltBytes.Length);

            MD5 md5 = MD5.Create();
            Byte[] computedHash = md5.ComputeHash(toHash);

            return Convert.ToBase64String(computedHash);
        }

        public static int CreateRandomSalt()
        {
            Byte[] _saltBytes = new Byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(_saltBytes);

            return ((((int)_saltBytes[0]) << 24) + (((int)_saltBytes[1]) << 16) +
              (((int)_saltBytes[2]) << 8) + ((int)_saltBytes[3]));
        }
    }
}
