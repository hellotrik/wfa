﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace wt001.ran.crypt
{
    public class Aes
    {
        private readonly string _key;
        private readonly string _vector = RndBytes.ToString(RndBytes.Next(-1));

        public Aes(string key)
        {
            _key = key;
        }

        public string Encrypt(string data)
        {
            var plainBytes = Encoding.UTF8.GetBytes(data);

            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(_key.PadRight(bKey.Length)), bKey, bKey.Length);
            var bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(_vector.PadRight(bVector.Length)), bVector, bVector.Length);

            byte[] cryptographic = null; // 加密后的密文

            var aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流
                using (var memory = new MemoryStream())
                {
                    // 把内存流对象包装成加密流对象
                    using (var encrypt = new CryptoStream(memory,
                        aes.CreateEncryptor(bKey, bVector),
                        CryptoStreamMode.Write))
                    {
                        // 明文数据写入加密流
                        encrypt.Write(plainBytes, 0, plainBytes.Length);
                        encrypt.FlushFinalBlock();

                        cryptographic = memory.ToArray();
                    }
                }
            }
            catch
            {
                cryptographic = null;
            }


            return cryptographic != null ? Convert.ToBase64String(cryptographic) : "";
        }

        public string Decrypt(string data, bool must = false)
        {
            byte[] encryptedBytes = null;
            try
            {
                encryptedBytes = Convert.FromBase64String(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return must ? "" : data;
            }

            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(_key.PadRight(bKey.Length)), bKey, bKey.Length);
            var bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(_vector.PadRight(bVector.Length)), bVector, bVector.Length);

            byte[] original = null; // 解密后的明文

            var aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流，存储密文
                using (var memory = new MemoryStream(encryptedBytes))
                {
                    // 把内存流对象包装成加密流对象
                    using (var decrypt = new CryptoStream(memory,
                        aes.CreateDecryptor(bKey, bVector),
                        CryptoStreamMode.Read))
                    {
                        // 明文存储区
                        using (var originalMemory = new MemoryStream())
                        {
                            var buffer = new byte[1024];
                            var readBytes = 0;
                            while ((readBytes = decrypt.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                originalMemory.Write(buffer, 0, readBytes);
                            }

                            original = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch
            {
                original = null;
            }

            return original != null ? Encoding.UTF8.GetString(original) : "";
        }
    }
}