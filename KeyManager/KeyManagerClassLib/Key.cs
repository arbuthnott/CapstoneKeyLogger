﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class Key : IComparable<Key>
    {
        //Properties
        public int Id { get; set; }
        public string Serial { get; set; }
        public KeyType KeyType { get; set; }
        public KeyRing KeyRing { get; set; }
        public bool Broken { get; set; }
        public bool Missing { get; set; }

        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue(true, "Serial", Serial);
            dl.AddValue(false, "Keytype", KeyType == null ? "NULL" : "" + KeyType.Id);
            dl.AddValue(false, "Keyring", KeyRing == null ? "NULL" : "" + KeyRing.Id);
            if (Id == -1)
            {
                Id = dl.AddRecord("key");
            }
            else
            {
                dl.AlterRecord("key", Id);
            }
        }

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

        public void SetKeyType(KeyType type)
        {
            KeyType = type;
            type.keys.Add(this);
            Save();
        }

        public void SetKeyRing(KeyRing ring)
        {
            KeyRing = ring;
            ring.keys.Add(this);
            Save();
        }

        public int CompareTo(Key other)
        {
            return this.Serial.CompareTo(other.Serial);
        }
    }
}
