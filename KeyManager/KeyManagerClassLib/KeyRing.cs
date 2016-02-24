using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class KeyRing : IComparable<KeyRing>
    {
        //Members
        //int id;
        //string name;

        // list property
        public List<Key> keys; // keys in this keyring
        

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        //Default constructor
        public KeyRing()
        {
            Id = 0;
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
            if (keys == null)
            {
                keys = new List<Key>();
            }
            keys.Add(key);
        }

        public int CompareTo(KeyRing other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
