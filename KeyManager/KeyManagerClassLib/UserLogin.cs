using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerHelper;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class UserLogin
    {
        private SQLiteConnection connection;//Not sure if this and the next two will work, since the references and using statments for the corresponding libraries aren't working.  
        private SQLiteCommand command;
        private SQLiteDataReader reader;
        
        private string userName;//Submitted username.
        private string password;//Submitted password.         
        private string sql = "SELECT * FROM personnel WHERE Username = _userName AND Password = _password";//Query to check if there are any rows that contain both the username and password. 
        private bool loggedIn;//Set to true if user is logged in, false if they aren't. 
        private Boolean isAdmin = false;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="pUserName">userName</param>
        /// <param name="pPassword">password</param>
        public UserLogin(string pUserName, string pPassword)
        {
            KeyManagerHelper.Hash hasher = new KeyManagerHelper.Hash();
            userName = pUserName;
            password = hasher.getHash(pPassword);
          // replaced the placeholders in the sql.
            sql = sql.Replace("_userName", "'" + userName + "'");
            sql = sql.Replace("_password", "'" + password + "'");
        }

        /// <summary>
        /// Returns username. Included in case we needed it. 
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }

        /// <summary>
        /// Returns password. Included in case we need it. 
        /// </summary>
        public string Password
        {
            get { return password; }
        }

        public Boolean IsAdmin
        {
            get { return isAdmin;  }
        }

        /// <summary>
        /// Returns connection object. I'm assuming that this connection would remain open while the program is used, and will only close when the user logs out or exits. 
        /// </summary>
        public SQLiteConnection Connection
        {
            get { return connection; }
        }

        /// <summary>
        /// Runs query to check for presence of submitted username / password combination in database.
        /// Returns true and keeps connection open for further use if valid; returns false and closes connection if invalid. 
        /// </summary>
        /// <returns>loggedIn</returns>
        public bool LogIn()
        {
            //connection = new SQLiteConnection("Data Source=testdb.sqlite;Version=3;");//Connect to database, open, and run command. 
            //connection.Open();
            // replaced your connection with the one I'm certain has the right location. It returns an open connection.
            connection = DbSetupManager.GetConnection();
            command = new SQLiteCommand(sql, connection);
            reader = command.ExecuteReader();//I'm assuming this sets up a cursor behind the scenes, which the reader uses to cycle through returned rows.            

            if (!reader.Read())//Not sure if this is a valid use, since I can't test it. Basically, if the query returns no rows, the login fails.
            {               
                loggedIn = false;
                LogOut();//Closes the connection, since it's no longer needed. 
            }

            else//A row was returned, so login was successful. 
            {
                isAdmin = reader.GetBoolean(5);
                loggedIn = true;
            }
            
            connection.Close(); 
            return loggedIn;
        }

        /// <summary>
        /// Basic logout method. 
        /// </summary>
        public void LogOut()
        {
            // I moved the close connection to the login method for now. - Jared
            //connection.Close();
            loggedIn = false;
        }
    }
}
