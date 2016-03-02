using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using KeyManagerHelper;

namespace KeyManagerData
{
    public class DataLayer
    {
        SQLiteConnection db;
        SQLiteCommand command;
        List<String> properties;
        List<String> values;
        public DataLayer()
        {
            properties = new List<string>();
            values = new List<string>();
        }

        public void AddValue(string Type, string Value)
        {
            properties.Add(Type);
            values.Add(Value);
        }

        public int AddRecord(string Type)
        {
            db = DbSetupManager.GetConnection();
            using (command = new SQLiteCommand(db))
            {
                command.CommandType = System.Data.CommandType.Text;

                // Type is never defined by a user, only by the program
                // thus this should be safe
                command.CommandText = "INSERT INTO " + Type + " (";
                for (int count = 0; count < properties.Count; count++)
                {
                    // Unfortunately, columns cannot be set as parameters
                    command.CommandText += "'" + properties[count] + "'";
                    if ((count + 1) < properties.Count) { command.CommandText += ", "; }
                }
                command.CommandText += ") VALUES (";
                for (int count = 0; count < values.Count; count++)
                {
                    command.CommandText += "@param" + count.ToString();
                    if ((count + 1) < values.Count) { command.CommandText += ", "; }
                }
                command.CommandText += ")";
                for (int count = 0; count < properties.Count; count++)
                {
                    command.Parameters.Add(new SQLiteParameter("@param" + count.ToString(), values[count]));
                }
                int rows = command.ExecuteNonQuery();
            }
            int newId = (int)db.LastInsertRowId;
            db.Close();
            return newId;
        }

        public int AddRecordWithDefault(string Type)
        {
            db = DbSetupManager.GetConnection();
            using (command = new SQLiteCommand(db))
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO " + Type + " DEFAULT VALUES";
                int rows = command.ExecuteNonQuery();
            }
            int newId = (int)db.LastInsertRowId;
            db.Close();
            return newId;
        }

        public void AlterRecord(string Type, int id)
        {
            db = DbSetupManager.GetConnection();
            using (command = new SQLiteCommand(db))
            {
                command.CommandType = System.Data.CommandType.Text;
                
                // Type is never defined by a user, only by the program
                // thus this should be safe
                command.CommandText = "UPDATE " + Type + " SET ";
                for (int count = 0; count < properties.Count; count++)
                {
                    // Unfortunately, columns cannot be set as parameters
                    command.CommandText += "'" + properties[count] + "' = ";
                    command.CommandText += "@param" + count.ToString();
                    if ((count + 1) < properties.Count) { command.CommandText += ", "; }
                }

                // While ID is defined by the user, it can only be an integer
                command.CommandText += " WHERE ID = " + id;

                for (int count = 0; count < properties.Count; count++)
                {
                    command.Parameters.Add(new SQLiteParameter("@param" + count, values[count]));
                }

                int rows = command.ExecuteNonQuery();
            }
            db.Close();
        }

        public void DeleteRecord(string Type, int id)
        {
            db = DbSetupManager.GetConnection();
            using (command = new SQLiteCommand(db))
            {
                command.CommandText = "DELETE FROM " + Type + " WHERE ID=" + id;
                int rows = command.ExecuteNonQuery();
            }
            db.Close();
        }
    }
}
