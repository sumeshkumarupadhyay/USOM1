using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace USOM
{
    public class CCACrypto
    {
        public string getchecksum(string MerchantId, string OrderId, string Amount, string redirectUrl, string WorkingKey)
        {
            string strPattern = MerchantId + "|" + OrderId + "|" + Amount + "|" + redirectUrl + "|" + WorkingKey;
            long adler = 1L;
            return adler32(adler, strPattern);
        }

        public string verifychecksum(string MerchantId, string OrderId, string Amount, string AuthDesc, string WorkingKey, string checksum)
        {
            string strPattern = MerchantId + "|" + OrderId + "|" + Amount + "|" + AuthDesc + "|" + WorkingKey;
            long adler = 1L;
            string strA = adler32(adler, strPattern);
            if (string.Compare(strA, checksum, ignoreCase: true) == 0)
            {
                return "true";
            }

            return "false";
        }

        private string adler32(long adler, string strPattern)
        {
            long num = 0L;
            long num2 = 65521L;
            long num3 = andop(adler, 65535L);
            long num4 = andop(cdec(rightshift(cbin(adler), 16L)), 65535L);
            for (int i = 0; i < strPattern.Length; i++)
            {
                char[] array = strPattern.Substring(i, 1).ToCharArray();
                num = array[0];
                num3 = (num3 + num) % num2;
                num4 = (num4 + num3) % num2;
            }

            return (cdec(leftshift(cbin(num4), 16L)) + num3).ToString();
        }

        private long power(long num)
        {
            long num2 = 1L;
            for (int i = 1; i <= num; i++)
            {
                num2 *= 2;
            }

            return num2;
        }

        private long andop(long op1, long op2)
        {
            string text = "";
            string text2 = cbin(op1);
            string text3 = cbin(op2);
            for (int i = 0; i < 32; i++)
            {
                text += long.Parse(text2.Substring(i, 1)) & long.Parse(text3.Substring(i, 1));
            }

            return cdec(text);
        }

        private string cbin(long num)
        {
            string text = "";
            do
            {
                text = (num % 2 + text).ToString();
                num = (long)Math.Floor((decimal)num / 2m);
            }
            while (num != 0);
            long num2 = 32 - text.Length;
            for (int i = 1; i <= num2; i++)
            {
                text = "0" + text;
            }

            return text;
        }

        private string leftshift(string str, long num)
        {
            long num2 = 32 - str.Length;
            for (int i = 1; i <= num2; i++)
            {
                str = "0" + str;
            }

            for (int j = 1; j <= num; j++)
            {
                str += "0";
                str = str.Substring(1, str.Length - 1);
            }

            return str;
        }

        private string rightshift(string str, long num)
        {
            for (int i = 1; i <= num; i++)
            {
                str = "0" + str;
                str = str.Substring(0, str.Length - 1);
            }

            return str;
        }

        private long cdec(string strNum)
        {
            long num = 0L;
            for (int i = 0; i < strNum.Length; i++)
            {
                num += long.Parse(strNum.Substring(i, 1)) * power(strNum.Length - (i + 1));
            }

            return num;
        }

        public string Encrypt(string strToEncrypt, string Key)
        {
            AesCryptUtil aesCryptUtil = new AesCryptUtil(Key);
            return aesCryptUtil.encrypt(strToEncrypt);
        }

        public string Decrypt(string strToDecrypt, string Key)
        {
            AesCryptUtil aesCryptUtil = new AesCryptUtil(Key);
            return aesCryptUtil.decrypt(strToDecrypt);
        }
    }

    public class AesCryptUtil
    {
        private byte[] data;

        private byte[] AesIV;

        public AesCryptUtil(string Key)
        {
            data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Key));
            AesIV = new byte[16]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                10, 11, 12, 13, 14, 15
            };
        }

        public string encrypt(string strToEncrypt)
        {
            string text = "";
            using (new RijndaelManaged())
            {
                byte[] array = EncryptStringToBytes(strToEncrypt, data, AesIV);
                StringBuilder stringBuilder = new StringBuilder();
                byte[] array2 = array;
                foreach (byte b in array2)
                {
                    stringBuilder.AppendFormat("{0:x2}", b);
                }

                return stringBuilder.ToString();
            }
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {

                rijndaelManaged.Key = Key;
                rijndaelManaged.IV = IV;
                ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        streamWriter.Write(plainText);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public string decrypt(string strToDecrypt)
        {
            using (new RijndaelManaged())
            {
                return DecryptStringFromBytes(strToDecrypt, data, AesIV);
            }
        }

        private static string DecryptStringFromBytes(string encryptedText, byte[] Key, byte[] IV)
        {
            int length = encryptedText.Length;
            byte[] array = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                array[i / 2] = Convert.ToByte(encryptedText.Substring(i, 2), 16);
            }

            if (array == null || array.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            //string text = null;
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Key = Key;
                rijndaelManaged.IV = IV;
                ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (MemoryStream stream = new MemoryStream(array))
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(stream2))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }

        }
    }
}
