using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class KeyType
    {
        //Members
        int id;
        string name;
        int permitLevel;

        /*
        SUGGESTIONED PROPERTIES:
        List<Door> doors; // doors this keytype can open
        List<Key> keys; // list of keys of this type (can also use to tell how many of this type)
        */

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
    }
}
