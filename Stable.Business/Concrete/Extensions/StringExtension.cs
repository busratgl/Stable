using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Stable.Business.Concrete.Extensions
{
    public static class StringExtension
    {
        public static T ToObject<T>(this string value) where T : class
        {
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<T>(value);
        }

        public static string Md5Encryption(this string text)
        {
            var md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(text);

            array = md5CryptoServiceProvider.ComputeHash(array);
            var stringBuilder = new StringBuilder();

            foreach (byte ba in array)
            {
                stringBuilder.Append(ba.ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }
    }
}
