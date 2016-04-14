using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerHelper;
using System.IO;

namespace KeyManagerData
{
    public abstract class DbSetupManager
    {
        public static String DB_FILENAME = "keyman.sqlite";

        /// <summary>
        /// Gets the full path of the db file (in the solution directory)
        /// </summary>
        /// <returns>The full path as a string</returns>
        public static String GetDBPath()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return appdataPath + "\\KeyManager\\" + DB_FILENAME;
        }

        /// <summary>
        /// Checks if folder and db exist in AppData.  If not, it creates with some
        /// sample data.
        /// </summary>
        public static void CheckDBFolder()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string keymanagerPath = appdataPath + "\\" + "KeyManager";
            if (!Directory.Exists(keymanagerPath))
            {
                // create it
                //System.Security.AccessControl.DirectorySecurity security = new System.Security.AccessControl.DirectorySecurity();
                Directory.CreateDirectory(keymanagerPath);
            }
            if (!File.Exists(GetDBPath()))
            {
                // create it
                CreateDatabase();
                PopulateSampleData();
            }
        }

        /// <summary>
        /// Gets an open connection to the database.  Must remember to close!
        /// </summary>
        /// <returns>An open connection</returns>
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + GetDBPath() +";Version=3;");
            connection.Open();
            return connection;
        }

        /// <summary>
        /// If db file doesn't already exist, creates the file, and fills with empty tables.
        /// </summary>
        /// <returns>true on success</returns>
        public static bool CreateDatabase()
        {
            String path = GetDBPath();
            if (!System.IO.File.Exists(path))
            {
                try {
                    SQLiteConnection.CreateFile(path);

                    // fill 'er up! Create some sql strings.
                    String CREATE_KEY_TABLE = "CREATE TABLE 'key' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Serial' TEXT, 'Keytype' INTEGER,'Keyring' INTEGER)";
                    String CREATE_PERSONNEL_TABLE = "CREATE TABLE 'personnel' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Username' TEXT,'Password' TEXT,'First Name' TEXT,'Last Name' TEXT,'IsAdministrator' INTEGER DEFAULT (0),'PermitLevel' INTEGER DEFAULT(0))";
                    String CREATE_LOCK_TABLE = "CREATE TABLE 'lock' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT)";
                    String CREATE_KEYTYPE_TABLE = "CREATE TABLE 'keytype' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT,'PermitLevel' INTEGER NOT NULL DEFAULT (0))";
                    String CREATE_DOOR_TABLE = "CREATE TABLE 'door' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'room_number' TEXT,'lock' INTEGER NOT NULL,'door_image' TEXT)";
                    String CREATE_LOCATION_TABLE = "CREATE TABLE 'location' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Name' TEXT,'image' TEXT)";
                    String CREATE_KEYRING_TABLE = "CREATE TABLE 'keyring' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Name' TEXT, 'owner' INTEGER)";
                    String CREATE_DOORLOCATION_TABLE = "CREATE TABLE 'door_to_location' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Door' INTEGER NOT NULL,'Location' INTEGER NOT NULL,'X' INTEGER,'Y' INTEGER,'Width' INTEGER,'Height' INTEGER)";
                    String CREATE_KEYTYPELOCK_TABLE = "CREATE TABLE 'keytype_to_lock' ('Keytype' INTEGER NOT NULL,'Lock' INTEGER NOT NULL)";
                    String CREATE_CHECKOUT_TABLE = "CREATE TABLE 'checkout' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Person' INTEGER NOT NULL,'Key' INTEGER,'Keyring' INTEGER,'IsReturned' INTEGER,'Date' TEXT NOT NULL)";
                    String CREATE_MAPPOINT_TABLE = "CREATE TABLE 'mappoint' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Door' INTEGER NOT NULL, 'Map' INTEGER NOT NULL, 'x' INTEGER NOT NULL, 'y' INTEGER NOT NULL)";

                    // connect, and execute the strings as commands.
                    SQLiteConnection conn = GetConnection();
                    SQLiteCommand command;

                    command = new SQLiteCommand(CREATE_KEY_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_PERSONNEL_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_LOCK_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_KEYTYPE_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_DOOR_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_LOCATION_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_KEYRING_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_DOORLOCATION_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_KEYTYPELOCK_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_CHECKOUT_TABLE, conn);
                    command.ExecuteNonQuery();

                    command = new SQLiteCommand(CREATE_MAPPOINT_TABLE, conn);
                    command.ExecuteNonQuery();

                    conn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false; // encountered a problem.
                }
            }
            return false; // db already seems to exist.
        }

        /// <summary>
        /// Erases the database file
        /// </summary>
        /// <returns>true on successful erase</returns>
        public static bool DeleteDatabase()
        {
            try
            {
                System.IO.File.Delete(GetDBPath());
                return true; // deleted.
            }
            catch (Exception e)
            {
                return false; // couldn't delete
            }
        }

        /// <summary>
        /// Creates an empty database file with structure, erasing existing one if need be
        /// </summary>
        /// <returns>true on success</returns>
        public static bool RefreshDatabase()
        {
            if (System.IO.File.Exists(GetDBPath()))
            {
                if (DeleteDatabase())
                {
                    return CreateDatabase();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return CreateDatabase();
            }
        }

        public static bool EmptyDatabase()
        {
            try
            {
                SQLiteConnection conn = GetConnection();

                String[] deleteStatements =
                {
                    "DELETE FROM checkout",
                    "DELETE FROM door",
                    "DELETE FROM door_to_location",
                    "DELETE FROM key",
                    "DELETE FROM keyring",
                    "DELETE FROM keytype",
                    "DELETE FROM keytype_to_lock",
                    "DELETE FROM location",
                    "DELETE FROM lock",
                    "DELETE FROM personnel",
                    "DELETE FROM mappoint"
                };

                SQLiteCommand command;
                foreach (String sql in deleteStatements)
                {
                    command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                }
                
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// If database exists, adds some sample data to it.
        /// </summary>
        /// <returns></returns>
        public static bool PopulateSampleData()
        {
            try {
                KeyManagerHelper.Hash hasher = new KeyManagerHelper.Hash();
                SQLiteConnection conn = GetConnection();
                String[] insertStatements =
                {
                    // three personnel
                    "INSERT INTO personnel ('Username', 'Password', 'First Name', 'Last Name', 'IsAdministrator') VALUES ('papa', '" + hasher.getHash("smurf") + "', 'Papa', 'Smurf', 1)", // admin user
                    "INSERT INTO personnel ('Username', 'Password', 'First Name', 'Last Name', 'IsAdministrator') VALUES ('brainy', '" + hasher.getHash("smurf") + "', 'Brainy', 'Smurf', 0)", // normal user
                    "INSERT INTO personnel ('First Name', 'Last Name', 'IsAdministrator') VALUES ('Handy', 'Smurf', 0)", // non-user
                    // 7 locks, only have ID
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",
                    "INSERT INTO lock DEFAULT VALUES",

                    // doors - three offices share a lock.
                    "INSERT INTO door ('room_number', 'lock') VALUES ('A100', 1)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('A101', 1)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('A102', 1)",
                    // doors - three offices with distinct locks.
                    "INSERT INTO door ('room_number', 'lock') VALUES ('B100', 2)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('B101', 3)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('B102', 4)",
                    // doors - two bathrooms share a lock.
                    "INSERT INTO door ('room_number', 'lock') VALUES ('A Bathroom', 5)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('B Bathroom', 5)",
                    // doors - two entrances with distinct locks.
                    "INSERT INTO door ('room_number', 'lock') VALUES ('Front Entrance', 6)",
                    "INSERT INTO door ('room_number', 'lock') VALUES ('Back Entrance', 7)",

                    // groups, aka locations
                    "INSERT INTO location ('Name') VALUES ('A Wing')",
                    "INSERT INTO location ('Name') VALUES ('B Wing')",
                    "INSERT INTO location ('Name') VALUES ('Offices')",
                    "INSERT INTO location ('Name') VALUES ('Entrances')",
                    "INSERT INTO location ('Name') VALUES ('All Doors')",

                    // join doors to groups - A Wing
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (1, 1)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (2, 1)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (3, 1)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (7, 1)",
                    // join doors to groups - B Wing
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (4, 2)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (5, 2)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (6, 2)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (8, 2)",
                    // join doors to groups - Offices
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (1, 3)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (2, 3)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (3, 3)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (4, 3)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (5, 3)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (6, 3)",
                    // join doors to groups - Entrances
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (9, 4)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (10, 4)",
                    // join doors to groups - All Doors
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (1, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (2, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (3, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (4, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (5, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (6, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (7, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (8, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (9, 5)",
                    "INSERT INTO door_to_location ('Door', 'Location') VALUES (10, 5)",

                    // keytypes
                    "INSERT INTO keytype ('Name') VALUES ('A Offices')",
                    "INSERT INTO keytype ('Name') VALUES ('B Offices')",
                    "INSERT INTO keytype ('Name') VALUES ('B100')",
                    "INSERT INTO keytype ('Name') VALUES ('B101')",
                    "INSERT INTO keytype ('Name') VALUES ('B102')",
                    "INSERT INTO keytype ('Name') VALUES ('Bathrooms')",
                    "INSERT INTO keytype ('Name') VALUES ('Entrances')",
                    "INSERT INTO keytype ('Name') VALUES ('Maintenance')", // can open bathrooms and entrances
                    "INSERT INTO keytype ('Name') VALUES ('All Offices')",
                    "INSERT INTO keytype ('Name') VALUES ('Master')",

                    // join keytypes to locks
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (1, 1)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (2, 2)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (2, 3)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (2, 4)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (3, 2)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (4, 3)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (5, 4)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (6, 5)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (7, 6)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (7, 7)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (8, 6)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (8, 7)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (8, 5)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (9, 1)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (9, 2)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (9, 3)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (9, 4)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 1)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 2)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 3)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 4)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 5)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 6)",
                    "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (10, 7)",

                    // create some keyrings
                    "INSERT INTO keyring ('Name', 'owner') VALUES ('Master Set', 3)",
                    "INSERT INTO keyring ('Name', 'owner') VALUES ('Janitor Set', 3)",
                    "INSERT INTO keyring ('Name', 'owner') VALUES ('Prof Smurf Set', 1)",

                    // three copies of every key, some added to keyrings.
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('A999a', 1, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('A999b', 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('A999c', 1)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('B999a', 2, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B999b', 2)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B999c', 2)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('B100a', 3, 1)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('B100b', 3, 3)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B100c', 3)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('B101a', 4, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B101b', 4)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B101c', 4)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('B102a', 5, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B102b', 5)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('B102c', 5)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('BATHa', 6, 1)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('BATHb', 6, 2)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('BATHc', 6)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('ENTRa', 7, 1)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('ENTRb', 7, 3)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('ENTRc', 7, 2)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('MNTa', 8, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('MNTb', 8)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('MNTc', 8)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('OFFCa', 9, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('OFFCb', 9)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('OFFCc', 9)",
                    "INSERT INTO key ('Serial', 'Keytype', 'Keyring') VALUES ('MSTRa', 10, 1)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('MSTRb', 10)",
                    "INSERT INTO key ('Serial', 'Keytype') VALUES ('MSTRc', 10)",

                    // let papa smurf have his keys checked out
                    "INSERT INTO checkout ('Person', 'Keyring', 'Date') VALUES (1, 3, '2016-01-01')",

                    "INSERT INTO checkout ('Person', 'Key', 'Date') VALUES (1, 2, '2016-01-01')",
                    "INSERT INTO checkout ('Person', 'Key', 'Date') VALUES (1, 3, '2016-01-01')",
                    "INSERT INTO checkout ('Person', 'Key', 'Date') VALUES (1, 5, '2016-01-01')",
                    "INSERT INTO checkout ('Person', 'Key', 'Date') VALUES (1, 6, '2016-01-01')"
                };

                SQLiteCommand command;
                foreach (String sql in insertStatements)
                {
                    command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Evaluates an sqlite file to see if it matches the required format before replacing.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool EvaluateExternalDB(string path)
        {
            if (!path.ToUpper().EndsWith(".SQLITE")) { return false; }

            try
            {
                string[] names = { "key", "personnel", "lock", "keytype", "door", "location", "keyring", "door_to_location", "keytype_to_lock", "checkout", "mappoint" };
                List<String> unfoundTableNames = new List<String>(names);

                SQLiteConnection connection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
                connection.Open();

                string sql = "SELECT name FROM sqlite_master WHERE type='table'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                string name;
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    if (unfoundTableNames.Contains(name)) { unfoundTableNames.Remove(name); }
                }
                connection.Close();

                return (unfoundTableNames.Count == 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
