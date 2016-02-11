using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class Key
    {
        //Members
        int id;
        string serial;
        KeyType keyType;
        KeyRing keyRing;
        bool broken;
        bool missing;

        //Properties
        public int Id { get; set; }
        public string Serial { get; set; }
        public KeyType KeyType { get; set; }
        public KeyRing KeyRing { get; set; }
        public bool Broken { get; set; }
        public bool Missing { get; set; }

        //Default constructor
        public Key()
        {
            id = 0;
            serial = "Serial";
            keyType = new KeyType();
            keyRing = new KeyRing();
            broken = false;
            missing = false;
        }

        //Constructor
        public Key(int pId, string pSerial, bool pBroken, bool pMissing)
        {
            id = pId;
            serial = pSerial;
            broken = pBroken;
            missing = pMissing;
        }
    }
}
