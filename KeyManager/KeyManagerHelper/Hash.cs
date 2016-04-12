using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KeyManagerHelper
{
    public class Hash
    {
        MemoryStream hashStream;
        SHA512 hasher;

        public Hash()
        {
            hasher = new SHA512Managed();
        }

        public String getHash(String plaintext)
        {

            hashStream = new MemoryStream((Encoding.UTF8.GetBytes(plaintext)));
            string returnHash = Convert.ToBase64String(hasher.ComputeHash(hashStream));
            hashStream.Close();
            return returnHash;
        }

        public Byte[] getBinaryHash(String plaintext)
        {

            hashStream = new MemoryStream((Encoding.UTF8.GetBytes(plaintext)));
            Byte[] returnHash = hasher.ComputeHash(hashStream));
            hashStream.Close();
            return returnHash;
        }
    }
}
