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

        // only set if checked out as a loose key, not part of a ring.
        public Checkout checkout;

        /// <summary>
        /// Remove this key from the database. Does not update OOP.
        /// </summary>
        /// <returns>true on success - should always return true.</returns>
        public bool Delete()
        {
            DataLayer dl = new DataLayer();
            dl.DeleteRecord("key", Id);

            return true;
        }

        /// <summary>
        /// Update or Create this key in the db, including associated keytype and keyring (if any)
        /// Convenience methods exist for setkeytype and setkeyring
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Serial", Serial);
            dl.AddValue("Keytype", KeyType == null ? null : "" + KeyType.Id);
            dl.AddValue("Keyring", KeyRing == null ? null : "" + KeyRing.Id);
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
            if (type != null)
            {
                type.keys.Add(this);
            }
            Save();
        }

        public void SetKeyRing(KeyRing ring)
        {
            KeyRing = ring;
            if (ring != null)
            {
                ring.keys.Add(this);
            }
            Save();
        }

        public int CompareTo(Key other)
        {
            return this.Serial.CompareTo(other.Serial);
        }
    }
}
