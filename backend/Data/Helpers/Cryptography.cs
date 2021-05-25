using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Data.Helpers
{
    public static class Cryptography
    {
        private const int _iterCount = 10000;
        private const int _subkeyLength = 256 / 8;
        private const int _saltSize = 128 / 8;
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            return HashPasswordInternal(password);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return VerifyHashedPasswordInternal(hashedPassword, password);
        }

        private static string HashPasswordInternal(string password)
        {
            var bytes = GetOutputBytes(password, KeyDerivationPrf.HMACSHA256, _iterCount, _saltSize, _subkeyLength);
            return Convert.ToBase64String(bytes);
        }

        private static byte[] GetOutputBytes(string password, KeyDerivationPrf prf, int iterationCount, int saltSize, int numBytesRequested)
        {
            var salt = new byte[saltSize];
            _rng.GetBytes(salt);

            var subKey = KeyDerivation.Pbkdf2(password, salt, prf, iterationCount, numBytesRequested);
            var outputBytes = new byte[13 + salt.Length + subKey.Length];

            // Write format marker.
            outputBytes[0] = 0x01;
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterationCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subKey, 0, outputBytes, 13 + saltSize, subKey.Length);

            return outputBytes;
        }

        private static bool VerifyHashedPasswordInternal(string hashedPassword, string password)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length == 0) return false;

            try
            {
                // Verify hashing format.
                if (decodedHashedPassword[0] != 0x01) return false;

                // Read hashing algorithm version.
                var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
                // Read iteration count of the algorithm.
                var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
                // Read size of the salt.
                var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

                // Verify the salt size: >= 128 bits.
                if (saltLength < 128 / 8) return false;

                // Read the salt.
                var salt = new byte[saltLength];
                Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

                // Verify the subkey length >= 128 bits.
                var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8) return false;

                // Read the subkey.
                var expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the given password and verify it against the expected subkey.
                var actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                // This should never occur except in the case of a malformed payload, where
                // we might go off the end of the array. Regardless, a malformed payload
                // implies verification failed.
                return false;
            }
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return (uint)buffer[offset + 0] << 24
                | (uint)buffer[offset + 1] << 16
                | (uint)buffer[offset + 2] << 8
                | buffer[offset + 3];
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        // Compares two byte arrays for equality.
        // The method is specifically written so that the loop is not optimized.
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var equal = true;
            for (var i = 0; i < a.Length; i++)
            {
                equal &= a[i] == b[i];
            }

            return equal;
        }
    }
}