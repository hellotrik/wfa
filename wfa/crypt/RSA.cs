﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace wt001.ran.crypt
{
    public static class Rsa
    {
        /// <summary>
        /// 获取加密/解密对
        /// 给你一个，是无法推算出另外一个的
        ///
        /// Encrypt   Decrypt
        /// </summary>
        /// <returns>Encrypt   Decrypt</returns>
        public static KeyValuePair<string, string> GetKeyPair()
        {
            var rsa = new RSACryptoServiceProvider();
            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// 加密：内容+加密key
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encryptKey">加密key</param>
        /// <returns></returns>
        public static string Encrypt(string content, string encryptKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(encryptKey);
            var byteConverter = new UnicodeEncoding();
            var dataToEncrypt = byteConverter.GetBytes(content);
            var resultBytes = rsa.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// 解密  内容+解密key
        /// </summary>
        /// <param name="content"></param>
        /// <param name="decryptKey">解密key</param>
        /// <returns></returns>
        public static string Decrypt(string content, string decryptKey)
        {
            var dataToDecrypt = Convert.FromBase64String(content);
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(decryptKey);
            var resultBytes = rsa.Decrypt(dataToDecrypt, false);
            return Encoding.GetEncoding("UTF-8").GetString(resultBytes);
        }

        /// <summary>
        /// 可以合并在一起的，，每次产生一组新的密钥
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encryptKey">加密key</param>
        /// <param name="decryptKey">解密key</param>
        /// <returns>加密后结果</returns>
        private static string Encrypt(string content, out string publicKey, out string privateKey)
        {
            var rsaProvider = new RSACryptoServiceProvider();
            publicKey = rsaProvider.ToXmlString(false);
            privateKey = rsaProvider.ToXmlString(true);
            var byteConverter = new UnicodeEncoding();
            var dataToEncrypt = byteConverter.GetBytes(content);
            var resultBytes = rsaProvider.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }
    }


    public class RSAKeyConverter
    {
        /// <summary>
        /// xml private key -> base64 private key string
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <returns></returns>
        public static string FromXmlPrivateKey(string xmlPrivateKey)
        {
            string result;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPrivateKey);
                var param = rsa.ExportParameters(true);
                var privateKeyParam = new RsaPrivateCrtKeyParameters(
                    new BigInteger(1, param.Modulus), new BigInteger(1, param.Exponent),
                    new BigInteger(1, param.D), new BigInteger(1, param.P),
                    new BigInteger(1, param.Q), new BigInteger(1, param.DP),
                    new BigInteger(1, param.DQ), new BigInteger(1, param.InverseQ));
                var privateKey = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);

                result = Convert.ToBase64String(privateKey.ToAsn1Object().GetEncoded());
            }

            return result;
        }

        /// <summary>
        /// xml public key -> base64 public key string
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <returns></returns>
        public static string FromXmlPublicKey(string xmlPublicKey)
        {
            string result;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPublicKey);
                var p = rsa.ExportParameters(false);
                var keyParams = new RsaKeyParameters(
                    false, new BigInteger(1, p.Modulus), new BigInteger(1, p.Exponent));
                var publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyParams);
                result = Convert.ToBase64String(publicKeyInfo.ToAsn1Object().GetEncoded());
            }

            return result;
        }

        /// <summary>
        /// base64 private key string -> xml private key
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string ToXmlPrivateKey(string privateKey)
        {
            var privateKeyParams =
                PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey)) as RsaPrivateCrtKeyParameters;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var rsaParams = new RSAParameters
                {
                    Modulus = privateKeyParams.Modulus.ToByteArrayUnsigned(),
                    Exponent = privateKeyParams.PublicExponent.ToByteArrayUnsigned(),
                    D = privateKeyParams.Exponent.ToByteArrayUnsigned(),
                    DP = privateKeyParams.DP.ToByteArrayUnsigned(),
                    DQ = privateKeyParams.DQ.ToByteArrayUnsigned(),
                    P = privateKeyParams.P.ToByteArrayUnsigned(),
                    Q = privateKeyParams.Q.ToByteArrayUnsigned(),
                    InverseQ = privateKeyParams.QInv.ToByteArrayUnsigned()
                };
                rsa.ImportParameters(rsaParams);
                return rsa.ToXmlString(true);
            }
        }

        /// <summary>
        /// base64 public key string -> xml public key
        /// </summary>
        /// <param name="pubilcKey"></param>
        /// <returns></returns>
        public static string ToXmlPublicKey(string pubilcKey)
        {
            var p =
                PublicKeyFactory.CreateKey(Convert.FromBase64String(pubilcKey)) as RsaKeyParameters;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var rsaParams = new RSAParameters
                {
                    Modulus = p.Modulus.ToByteArrayUnsigned(),
                    Exponent = p.Exponent.ToByteArrayUnsigned()
                };
                rsa.ImportParameters(rsaParams);
                return rsa.ToXmlString(false);
            }
        }
    }
}