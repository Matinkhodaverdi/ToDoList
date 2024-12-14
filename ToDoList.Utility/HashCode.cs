using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Utility
{
    public static class HashEnCode
    {
        public static string GetHashCode(string password)
        {
            Byte[] mainBytes;
            Byte[] encodeBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            mainBytes = ASCIIEncoding.Default.GetBytes(password);
            encodeBytes = md5.ComputeHash(mainBytes);
            return BitConverter.ToString(encodeBytes);
        }
    }
}
