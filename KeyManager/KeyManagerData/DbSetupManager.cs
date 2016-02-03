using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
            String dir = System.Reflection.Assembly.GetExecutingAssembly().Location; // current working dir
            // get parent several times to back out of <PROJECT>/bin/Debug/ to solution dir.
            dir = System.IO.Directory.GetParent(dir).FullName;
            dir = System.IO.Directory.GetParent(dir).FullName;
            dir = System.IO.Directory.GetParent(dir).FullName;
            dir = System.IO.Directory.GetParent(dir).FullName;
            return dir + "\\" + DB_FILENAME;
        }

        /// <summary>
        /// Gets an open connection to the database.  Must remember to close!
        /// </summary>
        /// <returns>An open connection</returns>
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + GetDBPath() +";Version=3;");
            connection.Open();
            return connection; // stub
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
                    String CREATE_KEYTYPE_TABLE = "CREATE TABLE 'keytype' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'PermitLevel' INTEGER NOT NULL DEFAULT (0))";
                    String CREATE_DOOR_TABLE = "CREATE TABLE 'door' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'room_number' TEXT,'lock' INTEGER NOT NULL,'door_image' TEXT)";
                    String CREATE_LOCATION_TABLE = "CREATE TABLE 'location' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Name' TEXT,'image' TEXT)";
                    String CREATE_KEYRING_TABLE = "CREATE TABLE 'keyring' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Name' TEXT)";
                    String CREATE_DOORLOCATION_TABLE = "CREATE TABLE 'door_to_location' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Door' INTEGER NOT NULL,'Location' INTEGER NOT NULL,'X' INTEGER,'Y' INTEGER,'Width' INTEGER,'Height' INTEGER)";
                    String CREATE_KEYTYPELOCK_TABLE = "CREATE TABLE 'keytype_to_lock' ('Keytype' INTEGER NOT NULL,'Lock' INTEGER NOT NULL)";
                    String CREATE_CHECKOUT_TABLE = "CREATE TABLE 'checkout' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT,'Person' INTEGER NOT NULL,'Key' INTEGER,'Keyring' INTEGER,'IsReturned' INTEGER,'Date' TEXT NOT NULL)";

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
            catch (Exception)
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
                    "DELETE * FROM checkout",
                    "DELETE * FROM door",
                    "DELETE * FROM door_to_location",
                    "DELETE * FROM key",
                    "DELETE * FROM keyring",
                    "DELETE * FROM keytype",
                    "DELETE * FROM keytype_to_lock",
                    "DELETE * FROM location",
                    "DELETE * FROM lock",
                    "DELETE * FROM personnel"
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
                SQLiteConnection conn = GetConnection();
                String[] insertStatements =
                {
                    "",
                    "",
                    "",
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
    }
}
