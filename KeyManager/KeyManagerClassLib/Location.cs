using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;
using System.Data.SQLite;

namespace KeyManagerClassLib
{
    public class Location : IComparable<Location>
    {
        // list property
        public List<Door> doors = new List<Door>(); // list of doors in this group/location

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Deletes this Location, and all references to it in db
        /// Does not update the OOP.
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            foreach (Door door in doors.ToArray()) // used ToArray to avoid modifying the list I'm iterating over.
            {
                RemoveDoor(door);
            }
            DataLayer dl = new DataLayer();
            dl.DeleteRecord("location", Id);
            return true;
        }

        /// <summary>
        /// Create or update this location in the db.  Does not update doors in the group.
        /// For that use AddDoor and RemoveDoor methods.
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Name", Name);
            dl.AddValue("image", Image);
            if (Id == -1)
            {
                Id = dl.AddRecord("location");
            }
            else
            {
                dl.AlterRecord("location", Id);
            }
        }

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

        /// <summary>
        /// Add a door to this group.  Affects OOP and database.
        /// </summary>
        /// <param name="door"></param>
        public void AddDoor(Door door)
        {
            doors.Add(door);
            DataLayer dl = new DataLayer();
            dl.AddValue("Door", "" + door.Id);
            dl.AddValue("Location", "" + Id);
            dl.AddRecord("door_to_location");
        }

        /// <summary>
        /// Remove a door from this group.  Affects OOP and Database.
        /// </summary>
        /// <param name="door"></param>
        public void RemoveDoor(Door door)
        {
            doors.Remove(door);
            // can't use DataLayer for this.
            SQLiteConnection conn = DbSetupManager.GetConnection();
            SQLiteCommand command = new SQLiteCommand(conn);
            command.CommandText = "DELETE FROM door_to_location WHERE Door = " + door.Id + " AND Location = " + Id;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public int CompareTo(Location other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
