using System;
using System.Security.Cryptography;
using System.Text;

namespace Libraries.Helpers
{
    public static class Cryptography
    {
        public static string EncryptWithMD5(string value)
        {
            using var md5Hash = MD5.Create();
            return GetMD5Hash(md5Hash, value);
        }

        private static string GetMD5Hash(MD5 md5Hash, string value)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            var builder = new StringBuilder();

            foreach (var currentByte in data)
            {
                builder.Append(currentByte.ToString("x2"));
            }

            return builder.ToString();
        }

        public static string EncryptWithBase64(string value)
        {
            var encryptedString = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var bytes = Encoding.UTF8.GetBytes(value);
                    encryptedString = Convert.ToBase64String(bytes);
                }
            }
            catch { }

            return encryptedString;
        }

        public static string DecryptWithBase64(string value)
        {
            var decryptedString = string.Empty;

            try
            {
                var bytes = Convert.FromBase64String(value);
                decryptedString = Encoding.UTF8.GetString(bytes);
            }
            catch { }

            return decryptedString;
        }
    }
}