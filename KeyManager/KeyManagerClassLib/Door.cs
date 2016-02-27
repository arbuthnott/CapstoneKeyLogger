using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;
using System.Data.SQLite;

namespace KeyManagerClassLib
{
    public class Door : IComparable<Door>
    {
        // list property
        public List<KeyType> keytypes = new List<KeyType>(); // of keytypes that can open this door
        
        //Properties
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int LockId { get; set; }
        public string DoorImage { get; set; }

        public void Save()
        {
            DataLayer dl;
            if (LockId == -1) // have to create a new lock object
            {
                // can't use DataLayer for this one!
                SQLiteConnection conn = DbSetupManager.GetConnection();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "INSERT INTO lock DEFAULT VALUES";
                command.ExecuteNonQuery();
                LockId = (int)conn.LastInsertRowId;
                conn.Close();
            }

            dl = new DataLayer();
            dl.AddValue(true, "room_number", RoomNumber);
            dl.AddValue(false, "lock", "" + LockId);
            dl.AddValue(true, "door_image", DoorImage);
            if (Id == -1)
            {
                Id = dl.AddRecord("door");
            }
            else
            {
                dl.AlterRecord("door", Id);
            }
        }

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

        /// <summary>
        /// Connects the input keytype to this door's lock in the db.
        /// </summary>
        /// <param name="type"></param>
        public void ConnectKeyType(KeyType type)
        {
            keytypes.Add(type);
            DataLayer dl = new DataLayer();
            dl.AddValue(false, "Keytype", "" + type.Id);
            dl.AddValue(false, "Lock", "" + Id);
            dl.AddRecord("keytype_to_lock");
        }

        /// <summary>
        /// Disconnects the input keytype from this door's lock in the db.
        /// </summary>
        /// <param name="type"></param>
        public void DisconnectKeyType(KeyType type)
        {
            keytypes.Remove(type);
            // can't use DataLayer for this!
            SQLiteConnection conn = DbSetupManager.GetConnection();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = "DELETE FROM keytype_to_lock WHERE Lock = " + LockId + " AND Keytype = " + type.Id;
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Note, the list of keytypes in the OOP must be updated separately to match!
        /// Only used for existing lockids.
        /// </summary>
        /// <param name="lockid">The new lock id of an existing lock</param>
        /// <param name="newTypes">List of keytypes connected to the new id</param>
        public void SetLockId(int lockid, List<KeyType> newTypes)
        {
            LockId = lockid;
            DataLayer dl = new DataLayer();
            dl.AddValue(false, "lock", "" + lockid);
            dl.AlterRecord("door", Id);

            keytypes.Clear();
            foreach (KeyType type in newTypes)
            {
                keytypes.Add(type);
                type.doors.Add(this);
            }
        }

        public int CompareTo(Door other)
        {
            return this.RoomNumber.CompareTo(other.RoomNumber);
        }

        
    }
}



