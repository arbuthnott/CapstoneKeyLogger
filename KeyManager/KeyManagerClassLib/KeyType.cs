using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class KeyType
    {
        //Members
        int id;
        string name;
        int permitLevel;

        // list properties
        List<Door> doors; // doors this keytype can open
        List<Key> keys; // list of keys of this type (can also use to tell how many of this type)
        

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int PermitLevel { get; set; }

        //Default constructor
        public KeyType()
        {
            id = 0;
            name = "Name";
            permitLevel = 0;
        }

        //Constructor
        public KeyType(int pId, string pName, int pPermitLevel)
        {
            id = 0;
            name = "Name";
            permitLevel = 0;
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
    }
}
