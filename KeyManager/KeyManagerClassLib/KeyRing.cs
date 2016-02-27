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

        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue(true, "Name", Name);
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

        public void AddKey(Key key)
        {
            keys.Add(key);
            key.KeyRing = this;
            DataLayer dl = new DataLayer();
            dl.AddValue(false, "Keyring", "" + Id);
            dl.AlterRecord("key", key.Id);
        }

        public void RemoveKey(Key key)
        {
            if (keys.Contains(key))
            {
                keys.Remove(key);
                key.KeyRing = null;
                DataLayer dl = new DataLayer();
                dl.AddValue(false, "Keyring", "NULL");
                dl.AlterRecord("key", key.Id);
            }
        }

        public int CompareTo(KeyRing other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
