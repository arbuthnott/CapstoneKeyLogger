using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class Location
    {
        //Members
        int id;
        string name;
        string image;

        /*
        SUGGESTIONED PROPERTIES:
        List<Door> doors; // list of doors in this group/location
        */

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        //Default constructor
        public Location()
        {
            id = 0;
            name = "Name";
            image = "Image";
        }

        //Constructor
        public Location(int pId, string pName, string pImage)
        {
            id = pId;
            name = pName;
            image = pImage;
        }
    }
}
