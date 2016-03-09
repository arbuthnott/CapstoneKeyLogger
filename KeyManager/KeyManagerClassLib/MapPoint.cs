using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class MapPoint
    {
        /*
        This is just a simple storage container for map data points
        I dont know how much more complex this will get.
        If nothing else is added, we could prooably move location data (x,y,which map) into the doors
        - Jared
        */

        public int Id;
        public int x;
        public int y;
        public Door door;
        public int floor; // I called this 'Map' in the database
        public bool selected = false;

        public MapPoint(int x, int y, Door door, int floor, int id = -1)
        {
            this.Id = id;
            this.x = x;
            this.y = y;
            this.door = door;
            this.floor = floor;
        }

        /// <summary>
        /// Save this MapPoint to the db. Must still add it to OOP lists
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Door", "" + door.Id);
            dl.AddValue("x", "" + x);
            dl.AddValue("y", "" + y);
            dl.AddValue("Map", "" + floor);

            if (Id == -1)
            {
                Id = dl.AddRecord("mappoint");
            }
            else
            {
                dl.AlterRecord("mappoint", Id);
            }
        }

        /// <summary>
        /// Delete the mappoint from the db. Must still update the OOP lists
        /// </summary>
        /// <returns>true if successful</returns>
        public bool Delete()
        {
            DataLayer dl = new DataLayer();
            dl.DeleteRecord("mappoint", Id);
            return true;
        }
    }
}
