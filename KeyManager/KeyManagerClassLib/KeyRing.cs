using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class KeyRing : IComparable<KeyRing>
    {
        // list property
        public List<Key> keys = new List<Key>(); // keys in this keyring
        
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Create or update this keyring in the db.  Does not update associated keys.
        /// To associate keys use AddKey and RemoveKey methods.
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Name", Name);
            if (Id == -1)
            {
                Id = dl.AddRecord("keyring");
            }
            else
            {
                dl.AlterRecord("keyring", Id);
            }
        }

        //Default constructor
        public KeyRing()
        {
            Id = -1;
            Name = "Name";
        }

        //Constructor
        public KeyRing(int pId, string pName)
        {
            Id = pId;
            Name = pName;
        }

        /// <summary>
        /// Add a key to this ring.  Affects OOP and db.
        /// </summary>
        /// <param name="key"></param>
        public void AddKey(Key key)
        {
            keys.Add(key);
            key.KeyRing = this;
            DataLayer dl = new DataLayer();
            dl.AddValue("Keyring", "" + Id);
            dl.AlterRecord("key", key.Id);
        }

        /// <summary>
        /// Remove a key from this ring.  Affects OOP and db.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveKey(Key key)
        {
            if (keys.Contains(key))
            {
                keys.Remove(key);
                key.KeyRing = null;
                DataLayer dl = new DataLayer();
                dl.AddValue("Keyring", "NULL");
                dl.AlterRecord("key", key.Id);
            }
        }

        public int CompareTo(KeyRing other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
