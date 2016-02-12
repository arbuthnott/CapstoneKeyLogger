using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class ObjectHolder
    {
        public List<Door> doors = new List<Door>();
        public List<Key> keys = new List<Key>();
        public List<KeyRing> keyrings = new List<KeyRing>();
        public List<KeyType> keytypes = new List<KeyType>();
        public List<Location> locations = new List<Location>();
        public List<Personnel> personnel = new List<Personnel>();

        public ObjectHolder()
        {
            SQLiteConnection conn = DbSetupManager.GetConnection();

            // load all the self-contained object.
            loadDoors(conn);
            loadKeyTypes(conn);
            loadKeys(conn);
            loadKeyrings(conn);
            loadLocations(conn);
            loadPersonnel(conn);

            // populate all the connection lists.

            conn.Close();
        }

        private void loadPersonnel(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Username, Password, \"First Name\", \"Last Name\", isAdministrator, PermitLevel FROM personnel", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Personnel per;
            while (reader.Read())
            {
                per = new Personnel(reader.GetInt16(0), reader.IsDBNull(1) ? null : reader.GetString(1), reader.IsDBNull(2) ? null : reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetInt16(6));
                personnel.Add(per);
            }
        }

        private void loadLocations(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Name, image FROM location", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Location loc;
            while (reader.Read())
            {
                loc = new Location(reader.GetInt16(0), reader.GetString(1), reader.IsDBNull(2) ? null : reader.GetString(2));
                locations.Add(loc);
            }
        }

        private void loadKeyTypes(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Name, PermitLevel FROM keytype", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            KeyType type;
            while (reader.Read())
            {
                type = new KeyType(reader.GetInt16(0), reader.GetString(1), reader.GetInt16(2));
                keytypes.Add(type);
            }
        }

        private void loadKeyrings(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Name FROM keyring", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            KeyRing ring;
            while (reader.Read())
            {
                ring = new KeyRing(reader.GetInt16(0), reader.GetString(1));
                keyrings.Add(ring);
            }
        }

        private void loadKeys(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Serial FROM key", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Key key;
            while (reader.Read())
            {
                key = new Key(reader.GetInt16(0), reader.GetString(1), false, false);
                keys.Add(key);
            }
        }

        private void loadDoors(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, room_number, lock, door_image FROM door", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Door door;
            while (reader.Read())
            {
                door = new Door(reader.GetInt16(0), reader.GetString(1), reader.GetInt16(2), reader.IsDBNull(3) ? null :reader.GetString(3));
                doors.Add(door);
            }
        }
    }
}
