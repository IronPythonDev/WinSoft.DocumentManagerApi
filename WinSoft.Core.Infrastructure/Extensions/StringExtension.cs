using System.Text;

namespace WinSoft.Core.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string MD5Hash(this string @string)
        {
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(@string);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
