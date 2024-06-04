﻿using System.Text;

namespace wt001.ran.crypt
{
    public static class RndBytes
    {
        private static readonly byte[] AesIv =
            {0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF};

        public static string ToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }


        public static byte[] Next(int n = 16) //构造 长度为n的 byte[]
        {
            if (n < 16)
            {
                return AesIv;
            }

            var num = new StringBuilder();
            var rnd = RndByte.NormalGet();
            for (var i = 0; i < n; i++)
            {
                num.Append(RndByte.Next(rnd).ToString());
            }

            return Encoding.UTF8.GetBytes(num.ToString());
        }
    }
}