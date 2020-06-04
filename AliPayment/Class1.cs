using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using javax.crypto;
using java.security;
using System.Security.Cryptography;
using java.lang;
using javax.crypto.spec;
using sun.misc;

namespace AliPayment
{
    partial class Program
    {
        private static string secret = "7825a0fc05e04c5eb0283539079afa71";
        private static string key = "2983593B92F868CF";
        public static System.String AESEncrypt(string content)
        {
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            SecretKeySpec keySpec = new SecretKeySpec(Encoding.UTF8.GetBytes(key), "AES");
            cipher.init(Cipher.ENCRYPT_MODE, keySpec);
            var data = cipher.doFinal(Encoding.UTF8.GetBytes(content));
            System.Text.StringBuilder sb = new System.Text.StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public static string AESDecrypt(string content)
        {
            SecretKeySpec keySpec = new SecretKeySpec(Encoding.UTF8.GetBytes(key), "AES");
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            cipher.init(Cipher.DECRYPT_MODE, keySpec);

            byte[] data = cipher.doFinal(HexStringToByteArray(content));
            
            
            return Convert.ToBase64String(data);
        }
        public static byte[] HexStringToByteArray(string s)
        {
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            return buffer;
        }
        public static string Encode_md5(string content)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(content));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
