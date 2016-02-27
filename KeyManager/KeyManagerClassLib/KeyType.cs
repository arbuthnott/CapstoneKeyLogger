using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class KeyType : IComparable<KeyType>
    {
        // list properties
        public List<Door> doors = new List<Door>(); // doors this keytype can open
        public List<Key> keys = new List<Key>(); // list of keys of this type (can also use to tell how many of this type)
        

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int PermitLevel { get; set; }

        //Default constructor
        public KeyType()
        {
            Id = 0;
            Name = "Name";
            PermitLevel = 0;
        }

        //Constructor
        public KeyType(int pId, string pName, int pPermitLevel)
        {
            Id = pId;
            Name = pName;
            PermitLevel = pPermitLevel;
        }

        public void ConnectToDoor(Door door)
        {
            if (doors == null)
            {
                doors = new List<Door>();
            }
            doors.Add(door);
        }

        public void ConnectToKey(Key key)
        {
            if (keys == null)
            {
                keys = new List<Key>();
            }
            keys.Add(key);
        }

        public int CompareTo(KeyType other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
