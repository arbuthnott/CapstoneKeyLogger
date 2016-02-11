using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class DoorLocation
    {
        /*
        SUGGESTION: may not need this class!
        */

        private int id;
        private Door door;
        private Location location;
        private int xCoord;
        private int yCoord;
        private int width;
        private int height;

        public int Id { get; set; }
        public int Door { get; set; }
        public int Location { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //Default constructor
        public DoorLocation()
        {
            id = 0;
            door = new Door();
            location = new Location();
            xCoord = 0;
            yCoord = 0;
            width = 0;
            height = 0;
        }

        //Constructor
        public DoorLocation(int pId, Door pDoor, Location pLocation, int pXCoord, int pYCoord, int pWidth, int pHeight)
        {
            id = pId;
            door = pDoor;
            location = pLocation;
            xCoord = pXCoord;
            yCoord = pYCoord;
            width = pWidth;
            height = pHeight;
        }
    }
}


