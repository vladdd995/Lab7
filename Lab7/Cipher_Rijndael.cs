using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;


namespace Lab7
{
    internal class Cipher_Rijndael
    {
        public byte[] EncryptStringToBytes(
        byte[] plainText,
        byte[] Key,
        byte[] IV,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length == 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            byte[] array;
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = Key;
                rijndael.IV = IV;
                rijndael.Mode = cipherMode;
                rijndael.Padding = paddingMode;
                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();

                        array = memoryStream.ToArray();
                    }
                }
            }
            return array;
        }

        public byte[] DecryptStringFromBytes(
          byte[] cipherText,
          byte[] Key,
          byte[] IV,
          CipherMode cipherMode = CipherMode.CBC,
          PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (cipherText == null || cipherText.Length == 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length == 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            byte[] array;
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = Key;
                rijndael.IV = IV;
                rijndael.Mode = cipherMode;
                rijndael.Padding = paddingMode;
                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        array = new byte[cipherText.Length];
                        int bytesRead = cryptoStream.Read(array, 0, cipherText.Length);

                        array = array.Take(bytesRead).ToArray();
                    }
                }
            }
            return array;
        }
    }
}


