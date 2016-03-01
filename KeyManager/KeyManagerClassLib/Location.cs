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

        public void AddDoor(Door door)
        {
            doors.Add(door);
            DataLayer dl = new DataLayer();
            dl.AddValue("Door", "" + door.Id);
            dl.AddValue("Location", "" + Id);
            dl.AddRecord("door_to_location");
        }

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
