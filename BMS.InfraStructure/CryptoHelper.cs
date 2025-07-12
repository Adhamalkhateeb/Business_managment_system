using System.Security.Cryptography;
using System.Text;
using BMS.InfraStructure.Core.Interfaces;
using BMS.InfraStructure.InfraStructure.interfaces;

namespace BMS.InfraStructure
{
    public class CryptoHelper : ICryptoHelper
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public CryptoHelper(IConfigReader configReader)
        {
            _key = GetValidatedKey("AESKey", configReader);
            _iv = GetValidatedKey("AESIV", configReader);
        }

        public string ComputeHash(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public string Encrypt(string input)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(input);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string encryptedinput)
        {
            if (string.IsNullOrEmpty(encryptedinput))
                throw new ArgumentNullException(nameof(encryptedinput));

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var ms = new MemoryStream(Convert.FromBase64String(encryptedinput));
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

        private static byte[] GetValidatedKey(string settingKey, IConfigReader reader)
        {
            string base64 = reader.GetSetting(settingKey);
            if (string.IsNullOrWhiteSpace(base64))
                throw new InvalidOperationException($"{settingKey} is not configured.");

            return Convert.FromBase64String(base64);
        }
    }
}
