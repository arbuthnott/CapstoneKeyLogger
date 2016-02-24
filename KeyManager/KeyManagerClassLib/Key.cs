using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class Key : IComparable<Key>
    {
        //Members
        //int id;
        //string serial;
        //KeyType keyType;
        //KeyRing keyRing;
        //bool broken;
        //bool missing;

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
            Id = 0;
            Serial = "Serial";
            KeyType = new KeyType();
            KeyRing = new KeyRing();
            Broken = false;
            Missing = false;
        }

        //Constructor
        public Key(int pId, string pSerial, bool pBroken, bool pMissing)
        {
            Id = pId;
            Serial = pSerial;
            Broken = pBroken;
            Missing = pMissing;
        }

        public int CompareTo(Key other)
        {
            return this.Serial.CompareTo(other.Serial);
        }
    }
}
