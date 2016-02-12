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
            connectDoors(conn); // also populates doors list of keytypes.
            connectKeyRings(conn); // also sets KeyRing and KeyType properties of Key objects
            connectKeyTypes(conn);
            connectLocations(conn);

            conn.Close();
        }

        private void connectLocations(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Door, Location FROM door_to_location", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Location loc;
            while (reader.Read())
            {
                loc = getLocationById(reader.GetInt16(1));
                loc.ConnectToDoor(getDoorById(reader.GetInt16(0)));
            }
        }

        private void connectKeyTypes(SQLiteConnection conn)
        {
            // already connected to doors, just need list of keys.
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Keytype FROM key", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            KeyType type;
            while (reader.Read())
            {
                type = getKeyTypeById(reader.GetInt16(1));
                type.ConnectToKey(getKeyById(reader.GetInt16(0)));
            }
        }

        private void connectKeyRings(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Keyring, Keytype FROM key", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            KeyRing ring;
            Key key;
            while (reader.Read())
            {
                key = getKeyById(reader.GetInt16(0));
                key.KeyType = getKeyTypeById(reader.GetInt16(2));
                if (!reader.IsDBNull(1))
                {
                    ring = getKeyRingById(reader.GetInt16(1));
                    ring.AddKey(key);
                    key.KeyRing = ring;
                }
            }
        }

        private void connectDoors(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Keytype, Lock FROM keytype_to_lock", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Door door;
            KeyType type;
            while (reader.Read())
            {
                door = getDoorByLockId(reader.GetInt16(1));
                type = getKeyTypeById(reader.GetInt16(0));
                door.ConnectKeyType(type);
                type.ConnectToDoor(door);
            }
        }

        public KeyRing getKeyRingByName(string name)
        {
            if (keyrings != null)
            {
                foreach (KeyRing ring in keyrings)
                {
                    if (ring.Name.Equals(name))
                    {
                        return ring;
                    }
                }
            }
            return null;
        }

        public Location getLocationById(int id)
        {
            if (locations != null)
            {
                foreach (Location loc in locations)
                {
                    if (loc.Id == id)
                    {
                        return loc;
                    }
                }
            }
            return null;
        }

        public Key getKeyById(int id)
        {
            if (keys != null)
            {
                foreach (Key key in keys)
                {
                    if (key.Id == id)
                    {
                        return key;
                    }
                }
            }
            return null;
        }

        public KeyRing getKeyRingById(int id)
        {
            if (keyrings != null)
            {
                foreach (KeyRing ring in keyrings)
                {
                    if (ring.Id == id)
                    {
                        return ring;
                    }
                }
            }
            return null;
        }

        public Door getDoorById(int id)
        {
            if (doors != null)
            {
                foreach (Door door in doors)
                {
                    if (door.Id == id)
                    {
                        return door;
                    }
                }
            }
            return null;
        }

        public Door getDoorByLockId(int id)
        {
            // PROBLEM: DISCONNECT BETWEEN PRIVATE AND PUBLIC PROPERTIES OF DOOR
            if (doors != null)
            {
                foreach (Door door in doors)
                {
                    if (door.LockId == id)
                    {
                        return door;
                    }
                }
            }
            return null;
        }

        public KeyType getKeyTypeById(int id)
        {
            if (keytypes != null)
            {
                foreach (KeyType type in keytypes)
                {
                    if (type.Id == id)
                    {
                        return type;
                    }
                }
            }
            return null;
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
