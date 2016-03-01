using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

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

        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Name", Name);
            dl.AddValue("PermitLevel", "" + PermitLevel);
            if (Id == -1)
            {
                Id = dl.AddRecord("keytype");
            }
            else
            {
                dl.AlterRecord("keytype", Id);
            }
        }

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
            door.ConnectKeyType(this);
        }

        public void DisconnectDoor(Door door)
        {
            door.DisconnectKeyType(this);
        }

        public void ConnectToKey(Key key)
        {
            key.SetKeyType(this);
        }

        public int CompareTo(KeyType other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
