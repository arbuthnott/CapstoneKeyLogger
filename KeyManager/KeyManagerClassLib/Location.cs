using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class Location : IComparable<Location>
    {
        //Members
        //int id;
        //string name;
        //string image;

        // list property
        public List<Door> doors; // list of doors in this group/location

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        //Default constructor
        public Location()
        {
            Id = 0;
            Name = "Name";
            Image = "Image";
        }

        //Constructor
        public Location(int pId, string pName, string pImage)
        {
            Id = pId;
            Name = pName;
            Image = pImage;
        }

        public void ConnectToDoor(Door door)
        {
            if (doors == null)
            {
                doors = new List<Door>();
            }
            doors.Add(door);
        }

        public int CompareTo(Location other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
