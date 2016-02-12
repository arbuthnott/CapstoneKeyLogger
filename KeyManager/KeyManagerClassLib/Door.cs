using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class Door
    {
        //Members
        private int id;
        private string roomNumber;
        private int lockId;
        private string doorImage;
        
        // list property
        List<KeyType> keytypes; // of keytypes that can open this door
        
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
            lockId = -1;
            doorImage = "Image";
        }

        //Constructor
        public Door(int pId, string pRoomNumber, int pLockId, string pDoorImage)
        {
            id = pId;
            roomNumber = pRoomNumber;
            lockId = pLockId;
            doorImage = pDoorImage;
        }

        public void ConnectKeyType(KeyType type)
        {
            if (keytypes == null)
            {
                keytypes = new List<KeyType>();
            }
            keytypes.Add(type);
        }
    }
}



