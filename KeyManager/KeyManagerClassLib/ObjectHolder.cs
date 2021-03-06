﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerData;

namespace KeyManagerClassLib
{
    /// <summary>
    /// A class to reference OOP objects.  Also responsible for creating these objects from
    /// the database.
    /// </summary>
    public class ObjectHolder
    {
        // object lists
        public List<Door> doors = new List<Door>();
        public List<Key> keys = new List<Key>();
        public List<KeyRing> keyrings = new List<KeyRing>();
        public List<KeyType> keytypes = new List<KeyType>();
        public List<Location> locations = new List<Location>();
        public List<Personnel> personnel = new List<Personnel>();
        public List<Checkout> checkouts = new List<Checkout>();
        public List<MapPoint> mappoints = new List<MapPoint>();

        public ObjectHolder()
        {
            SQLiteConnection conn = DbSetupManager.GetConnection();

            // load all the self-contained object.
            loadDoors(conn);
            loadKeyTypes(conn);
            loadKeys(conn);
            loadPersonnel(conn);
            loadKeyrings(conn);
            loadLocations(conn);
            loadCheckouts(conn);
            loadMapPoints(conn);

            // sort the lists
            doors.Sort();
            keys.Sort();
            keyrings.Sort();
            keytypes.Sort();
            locations.Sort();
            personnel.Sort();
            checkouts.Sort();

            // populate all the connection lists.
            connectDoors(conn); // also populates doors list of keytypes.
            connectKeyRings(conn); // also sets KeyRing and KeyType properties of Key objects
            connectKeyTypes(conn);
            connectLocations(conn);

            conn.Close();
        }

        /*********************************************************
        * HELPER FUNCTIONS to find objects by certain properties
        *********************************************************/

        public Checkout getCheckoutById(int id)
        {
            if (checkouts != null)
            {
                foreach (Checkout checkout in checkouts)
                {
                    if (checkout.Id.Equals(id))
                    {
                        return checkout;
                    }
                }
            }
            return null;
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

        public Location getLocationByName(string name)
        {
            foreach (Location loc in locations)
            {
                if (loc.Name == name)
                {
                    return loc;
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

        public Key getKeyBySerial(string serial)
        {
            foreach (Key key in keys)
            {
                if (key.Serial == serial)
                {
                    return key;
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

        public Door getDoorByRoomNumber(string room)
        {
            foreach (Door door in doors)
            {
                if (door.RoomNumber == room)
                {
                    return door;
                }
            }
            return null;
        }

        public List<Door> getDoorsByLockId(int id)
        {
            if (doors != null)
            {
                List<Door> doorsForLock = new List<Door>();
                foreach (Door door in doors)
                {
                    if (door.LockId == id)
                    {
                        doorsForLock.Add(door);
                    }
                }
                return doorsForLock;
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

        public KeyType getKeyTypeByName(string name)
        {
            foreach (KeyType type in keytypes)
            {
                if (type.Name == name)
                {
                    return type;
                }
            }
            return null;
        }

        public Personnel GetPersonnelById(int id)
        {
            foreach (Personnel person in personnel)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public List<MapPoint> GetMapPointsByDoor(Door door)
        {
            List<MapPoint> pointList = new List<MapPoint>();
            foreach (MapPoint point in mappoints)
            {
                if (point.door == door)
                {
                    pointList.Add(point);
                }
            }
            return pointList;
        }

        public List<MapPoint> GetMapPointsByGroup(Location loc)
        {
            List<MapPoint> pointList = new List<MapPoint>();
            foreach (MapPoint point in mappoints)
            {
                if (loc.doors.Contains(point.door))
                {
                    pointList.Add(point);
                }
            }
            return pointList;
        }

        public void UpdateLockData(Door guideDoor)
        {
            // reset all OOP associations based on input door's lock id, and keytype list.
            // first handle lock data in db:
            foreach (KeyType type in keytypes)
            {
                if (guideDoor.keytypes.Contains(type))
                {
                    guideDoor.ConnectKeyType(type);
                }
                else
                {
                    guideDoor.DisconnectKeyType(type);
                }
            }
            // now update all the OOP:
            foreach (Door door in doors)
            {
                if (door.LockId == guideDoor.LockId)
                {
                    foreach (KeyType type in keytypes)
                    {
                        if (guideDoor.keytypes.Contains(type))
                        {
                            if (!door.keytypes.Contains(type)) { door.keytypes.Add(type); }
                            if (!type.doors.Contains(door)) { type.doors.Add(door); }
                        }
                        else
                        {
                            door.keytypes.Remove(type);
                            type.doors.Remove(door);
                        }
                    }
                }
            }
        }

        /*******************************************************************************
        * LOAD FUNCTIONS to load objects from database with their basic data properties
        *******************************************************************************/

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
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Name, owner FROM keyring", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            KeyRing ring;
            while (reader.Read())
            {
                ring = new KeyRing(reader.GetInt16(0), reader.GetString(1));
                if (!reader.IsDBNull(2))
                {
                    ring.owner = GetPersonnelById(reader.GetInt16(2));
                }
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
                door = new Door(reader.GetInt16(0), reader.GetString(1), reader.GetInt16(2), reader.IsDBNull(3) ? null : reader.GetString(3));
                doors.Add(door);
            }
        }

        private void loadCheckouts(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Person, Key, Keyring, IsReturned, Date from checkout", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Checkout checkout;
            while (reader.Read())
            {
                checkout = new Checkout(
                    reader.GetInt16(0),
                    GetPersonnelById(reader.GetInt16(1)),
                    reader.IsDBNull(2) ? null : getKeyById(reader.GetInt16(2)),
                    reader.IsDBNull(3) ? null : getKeyRingById(reader.GetInt16(3)),
                    reader.IsDBNull(4) ? false : reader.GetInt16(4) > 0,
                    DateTime.Parse(reader.GetString(5))
                );
                checkouts.Add(checkout);

                // now connect personnel with their checked out stuff
                if (!checkout.IsReturned)
                {
                    if (checkout.KeyRing != null)
                    {
                        checkout.Person.Keyrings.Add(checkout.KeyRing);
                        checkout.KeyRing.checkout = checkout;
                    }
                    if (checkout.Key != null)
                    {
                        checkout.Person.Keys.Add(checkout.Key);
                        checkout.Key.checkout = checkout;
                    }
                }
            }
        }

        private void loadMapPoints(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Door, Map, x, y from mappoint", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            MapPoint point;
            while (reader.Read())
            {
                point = new MapPoint(
                    reader.GetInt16(3),
                    reader.GetInt16(4),
                    getDoorById(reader.GetInt16(1)),
                    reader.GetInt16(2),
                    reader.GetInt16(0)
                );
                mappoints.Add(point);
            }
        }

        /*******************************************************************************
        * CONNECT FUNCTIONS to populate aggregation properties or lists
        *******************************************************************************/

        private void connectLocations(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Door, Location FROM door_to_location", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            Location loc;
            while (reader.Read())
            {
                loc = getLocationById(reader.GetInt16(1));
                loc.doors.Add(getDoorById(reader.GetInt16(0)));
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
                type.keys.Add(getKeyById(reader.GetInt16(0)));
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
                    ring.keys.Add(key);
                    key.KeyRing = ring;   
                }
            }
        }

        private void connectDoors(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Keytype, Lock FROM keytype_to_lock", conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Door> myDoors;
            KeyType type;
            while (reader.Read())
            {
                myDoors = getDoorsByLockId(reader.GetInt16(1));
                type = getKeyTypeById(reader.GetInt16(0));
                foreach (Door door in myDoors)
                {
                    door.keytypes.Add(type);
                    type.doors.Add(door);
                }
            }
        }
  
    }
}
