using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
