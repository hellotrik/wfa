﻿using System;

namespace wt001.ran.crypt
{
    public static class RndByte
    {
        private static readonly char[] ArrChar =
        {
            //字典
            'a', 'b', 'd', 'c', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 'q', 's', 't', 'u', 'v',
            'w', 'z', 'y', 'x',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Q', 'P', 'R', 'T', 'S', 'V', 'U',
            'W', 'X', 'Y', 'Z'
        };

        public static Random NormalGet()
        {
            return new Random(DateTime.Now.Millisecond);
        }


        public static char Next(Random random)
        {
            return ArrChar[random.Next(0, ArrChar.Length)];
        }
    }
}