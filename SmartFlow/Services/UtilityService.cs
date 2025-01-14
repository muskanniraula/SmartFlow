using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartFlow.Services
{
    public static class UtilityService
    {
        private const char segmentDelimiter = ':';

        public static string HashSecret(this string input)
        {
            var saltSize = 16;
            var iterations = 100_000;
            var keySize = 32;
            var algorithm = HashAlgorithmName.SHA256;
            var salt = RandomNumberGenerator.GetBytes(saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, iterations, algorithm, keySize);

            var result = string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                iterations,
                algorithm
            );

            return result;
        }

        public static bool VerifyHash(this string input, string hashString)
        {
            var segments = hashString.Split(segmentDelimiter);
            var hash = Convert.FromHexString(segments[0]);
            var salt = Convert.FromHexString(segments[1]);
            var iterations = int.Parse(segments[2]);
            var algorithm = new HashAlgorithmName(segments[3]);
            var inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithm,
                hash.Length
            );

            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        /// <summary>
        /// Initializing a method so as to retrieve the directory path to store all the records and logs
        /// </summary>
        /// <returns>Path of the directory that holds all the application data</returns>
        public static string GetAppDirectoryPath()
        {
            return @"D:\Islington\5th Semester\Application Development\Coursework\SmartFlow\SmartFlow";
        }

        public static string GetAppUsersFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "User.json");
        }

        public static string GetAppTransactionsFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "transactions.json");
        }

        public static string GetAppTagsFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "tags.json");
        }

        public static string GetAppDebtsFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "debts.json");
        }
    }
    }