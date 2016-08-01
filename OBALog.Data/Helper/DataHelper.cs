using System;
using System.Security.Cryptography;
using System.Text;

namespace OBALog.Data
{
    public static class DataHelper
    {
        public static string CreateSHA1(String inputString)
        {
            return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(inputString))).Replace("-", "");
        }
    }
}
