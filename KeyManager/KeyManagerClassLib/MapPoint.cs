using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int x;
        public int y;
        public Door door;
        public int floor;
        public bool selected = false;

        public MapPoint(int x, int y, Door door, int floor)
        {
            this.x = x;
            this.y = y;
            this.door = door;
            this.floor = floor;
        }
    }
}
