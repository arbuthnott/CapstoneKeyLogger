using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class KeyRing
    {
        //Members
        int id;
        string name;

        /*
        SUGGESTIONED PROPERTIES:
        List<Key> keys; // keys in this keyring
        */

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        //Default constructor
        public KeyRing()
        {
            id = 0;
            name = "Name";
        }

        //Constructor
        public KeyRing(int pId, string pName)
        {
            id = pId;
            name = pName;
        }
    }
}
