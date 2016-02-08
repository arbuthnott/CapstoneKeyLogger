using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerData;
using KeyManagerClassLib;

namespace KeyManagerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunTestDB(); // creates and reads from a stubbed, sample db

            String username = "papa";
            String password = "smurf";
            UserLogin userlogin = new UserLogin(username, password);
            Console.WriteLine("Trying a good login: " + userlogin.LogIn());
            userlogin.LogOut();

            password = "woops";
            userlogin = new UserLogin(username, password);
            Console.WriteLine("Trying a bad login: " + userlogin.LogIn());
            userlogin.LogOut();

            

            Console.Read();
            
        }

        private static void RunTestDB()
        {
            // Only needed the following line once.
            // the database is created in the Console Project /bin/Debug/
            SQLiteConnection.CreateFile("testdb.sqlite");

            SQLiteConnection connection = new SQLiteConnection("Data Source=testdb.sqlite;Version=3;");
            connection.Open();

            // do data stuff here!
            String sql = "CREATE TABLE student (first_name VARCHAR(20), last_name VARCHAR(20))";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            // only needed the following once.
            command.ExecuteNonQuery(); // apparently there are types of executes depending on query type/returns/etc
            // all the following INSERTs have the execution commented out to avoid duplicating.
            sql = "INSERT INTO student (first_name, last_name) values ('Michael', 'Ahearn')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO student (first_name, last_name) values ('Chris', 'Arbuthnott')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO student (first_name, last_name) values ('Jared', 'Everett')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO student (first_name, last_name) values ('Ryan', 'Hackett')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO student (first_name, last_name) values ('James', 'Hale')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();

            sql = "SELECT * FROM student WHERE first_name LIKE 'J%'";
            command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader(); // the execute to return results
            while (reader.Read())
            {
                Console.WriteLine("First Name: " + reader["first_name"] + ", Last Name: " + reader["last_name"]);
            }
            connection.Close();

            // test deletion.
            //System.IO.File.Delete("testdb.sqlite");

            Console.Read();
        }
    }
}
