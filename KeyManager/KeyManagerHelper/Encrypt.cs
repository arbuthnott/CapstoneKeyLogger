using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeyManagerHelper
{
    class Encrypt
    {
        MemoryStream stream;
        Aes aes;
        ICryptoTransform encrypt;
        ICryptoTransform decrypt;
        CryptoStream csEncrypt;
        CryptoStream csDecrypt;
        StreamWriter cwEncrypt;
        StreamReader crDecrypt;

        public Encrypt()
        {
            aes = Aes.Create();

        }

        public void SetKey(Byte[] key)
        {
            aes.Key = key;
            encrypt = aes.CreateEncryptor();
            decrypt = aes.CreateDecryptor();
        }

        public String EncryptString(String plaintext)
        {
            stream = new MemoryStream();
            csEncrypt = new CryptoStream(stream, encrypt, CryptoStreamMode.Write);
            cwEncrypt = new StreamWriter(csEncrypt);
            cwEncrypt.Write(plaintext);

            return Convert.ToBase64String(stream.ToArray());
        }

        public Byte[] EncryptBinaryString(String plaintext)
        {
            stream = new MemoryStream();
            csEncrypt = new CryptoStream(stream, encrypt, CryptoStreamMode.Write);
            cwEncrypt = new StreamWriter(csEncrypt);
            cwEncrypt.Write(plaintext);

            return stream.ToArray();
        }

        public String DecryptString(String ciphertext)
        {
            stream = new MemoryStream(Convert.FromBase64String(ciphertext));
            csDecrypt = new CryptoStream(stream, decrypt, CryptoStreamMode.Read);
            crDecrypt = new StreamReader(csDecrypt);

            return crDecrypt.ReadToEnd();
        }

        public String DecryptBinaryString(Byte[] ciphertext)
        {
            stream = new MemoryStream(ciphertext);
            csDecrypt = new CryptoStream(stream, decrypt, CryptoStreamMode.Read);
            crDecrypt = new StreamReader(csDecrypt);

            return crDecrypt.ReadToEnd();
        }
    }
}
