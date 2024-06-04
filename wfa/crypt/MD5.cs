﻿using System.Security.Cryptography;
using System.Text;

namespace wt001.ran.crypt
{
    public static class Md5
    {
        private static char[] hexDigits =
            {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        public static string bytes2HexString(byte[] bytes)
        {
            if (bytes == null) return null;
            var len = bytes.Length;
            if (len <= 0) return null;
            var ret = new char[len << 1];
            for (int i = 0, j = 0; i < len; i++)
            {
                ret[j++] = hexDigits[bytes[i] >> 4 & 0x0f];
                ret[j++] = hexDigits[bytes[i] & 0x0f];
            }

            return new string(ret);
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt32(string password)
        {
            var cl = password;
            var md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            var s = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            return bytes2HexString(s);
        }
    }
}