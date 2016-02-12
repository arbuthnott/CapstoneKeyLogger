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
        //private int id;
        //private string roomNumber;
        //private int lockId;
        //private string doorImage;
        
        // list property
        public List<KeyType> keytypes; // of keytypes that can open this door
        
        //Properties
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int LockId { get; set; }
        public string DoorImage { get; set; }

        //Default constructor
        public Door()
        {
            Id = 0;
            RoomNumber = "Room";
            LockId = -1;
            DoorImage = "Image";
        }

        //Constructor
        public Door(int pId, string pRoomNumber, int pLockId, string pDoorImage)
        {
            Id = pId;
            RoomNumber = pRoomNumber;
            LockId = pLockId;
            DoorImage = pDoorImage;
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



