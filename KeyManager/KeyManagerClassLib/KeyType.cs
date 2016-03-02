using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class KeyType : IComparable<KeyType>
    {
        // list properties
        public List<Door> doors = new List<Door>(); // doors this keytype can open
        public List<Key> keys = new List<Key>(); // list of keys of this type (can also use to tell how many of this type)
        
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int PermitLevel { get; set; }

        /// <summary>
        /// Delete the keytype only if it has no associated keys.
        /// Deletes associations to existing locks
        /// does not update the OOP.
        /// </summary>
        /// <returns>true if successful, false if keys of this type forbid deletion</returns>
        public bool Delete()
        {
            if (keys.Count > 0)
            {
                return false;
            }
            foreach (Door door in doors)
            {
                door.DisconnectKeyType(this);
            }
            DataLayer dl = new DataLayer();
            dl.DeleteRecord("keytype", Id);
            return true;
        }

        /// <summary>
        /// Create or update this keytype in the database.  Does not affect associated doors
        /// or keys.  To affect these in db, use ConnectToDoor, DisconnectDoor, and
        /// ConnectToKey methods.
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Name", Name);
            dl.AddValue("PermitLevel", "" + PermitLevel);
            if (Id == -1)
            {
                Id = dl.AddRecord("keytype");
            }
            else
            {
                dl.AlterRecord("keytype", Id);
            }
        }

        //Default constructor
        public KeyType()
        {
            Id = 0;
            Name = "Name";
            PermitLevel = 0;
        }

        //Constructor
        public KeyType(int pId, string pName, int pPermitLevel)
        {
            Id = pId;
            Name = pName;
            PermitLevel = pPermitLevel;
        }

        /// <summary>
        /// Attach to a door in the OOP and the database
        /// </summary>
        /// <param name="door"></param>
        public void ConnectToDoor(Door door)
        {
            door.ConnectKeyType(this);
        }

        /// <summary>
        /// Dissociate from a door in the OOP and the database
        /// </summary>
        /// <param name="door"></param>
        public void DisconnectDoor(Door door)
        {
            door.DisconnectKeyType(this);
        }

        /// <summary>
        /// Connect a key to this type in both OOP and database
        /// </summary>
        /// <param name="key"></param>
        public void ConnectToKey(Key key)
        {
            key.SetKeyType(this);
        }

        public int CompareTo(KeyType other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
