using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Web.CredBox
{
    public static class StringExtension
    {
        private const string Chave = "WAZYXTEO";
        private static byte[] _key = { };
        private static readonly byte[] Iv = { 0x12, 0X34, 0X56, 0X78, 0X90, 0XAB, 0XCD, 0XEF };

        public static string Encrypt(this string valor)
        {
            byte[] inputByteArray;

            _key = Encoding.UTF8.GetBytes(Chave.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Encoding.UTF8.GetBytes(valor);

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(_key, Iv), CryptoStreamMode.Write);

            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        internal static string Decrypt(this string valor)
        {
            byte[] inputByteArray = new byte[valor.Length];

            _key = Encoding.UTF8.GetBytes(Chave.Substring(0, 8));

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            inputByteArray = Convert.FromBase64String(valor.Replace(" ", "+"));

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(_key, Iv), CryptoStreamMode.Write);

            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;

            return encoding.GetString(memoryStream.ToArray());
        }
    }
}
