using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class Door
    {
        //Members
        private int id;
        private string roomNumber;
        private Lock doorLock;
        private string doorImage;

        /*
        SUGGESTED PROPERTIES
        List<KeyType> keytypes; // of keytypes that can open this door
        */

        //Properties
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public Lock DoorLock { get; set; }
        public string DoorImage { get; set; }

        //Default constructor
        public Door()
        {
            id = 0;
            roomNumber = "Room";
            doorLock = new Lock();
            doorImage = "Image";
        }

        //Constructor
        public Door(int pId, string pRoomNumber, Lock pDoorLock, string pDoorImage)
        {
            id = pId;
            roomNumber = pRoomNumber;
            doorLock = pDoorLock;
            doorImage = pDoorImage;
        }
    }
}



