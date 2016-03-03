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
        List<String> Datatype;
        List<Object> values;
        public DataLayer()
        {
            properties = new List<string>();
            values = new List<Object>();
        }

        public void Clear()
        {
            Datatype = new List<String>();
            properties = new List<String>();
            values = new List<Object>();
        }
        /*
        public void AddColumn(string Column, string Datatype)
        {
            this.properties.Add(Column);
            this.Datatype.Add(Datatype);
        }
        */
        public void AddValue(string Column, string Value)
        {
            properties.Add(Column);
            values.Add(Value);
        }

        // When using this method you will likely need to parse the returned values
        // contained within the returned list, since they are all in string format.
        public List<string> GetRecord(string Type, int Id, int ReturnCount)
        {
            db = DbSetupManager.GetConnection();
            db.Open();
            List<string> returnList = new List<string>();
            using (command = new SQLiteCommand(db))
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM " + Type + " WHERE ID = " + Id.ToString();
                SQLiteDataReader reader = command.ExecuteReader();
                // Should get only one record at a time
                reader.Read();
                for (int count = 0; count < ReturnCount; count++)
                {
                    returnList.Add(reader.GetString(count));
                }
            }
            db.Close();
            return returnList;
        }
        public int AddRecord(string Type)
        {
            db = DbSetupManager.GetConnection();
            db.Open();
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
            db.Open();
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
            db.Open();
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

        // When using this method you will likely need to parse the returned values
        // contained within the returned list, since they are all in string format.
        public List<int> GetJointRecord(string Type, string foreignId, string mainId, int mainValue)
        {
            db = DbSetupManager.GetConnection();
            db.Open();
            List<int> returnList = new List<int>();
            using (command = new SQLiteCommand(db))
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT " + foreignId + " FROM " + Type + " WHERE " + mainId + " = " + mainValue.ToString();
                SQLiteDataReader reader = command.ExecuteReader();
                // Should get only one record at a time
                while (reader.Read())
                {
                    returnList.Add(reader.GetInt32(0));
                }
            }
            db.Close();
            return returnList;
        }

        // Where both columns match, delete record
        public void DeleteJointRecord(string Type, string mainId, string foreignId, int mainValue, int foreignValue)
        {
            db = DbSetupManager.GetConnection();
            db.Open();
            using (command = new SQLiteCommand(db))
            {
                command.CommandText = "DELETE FROM " + Type + " WHERE " + mainId + "=" + mainValue.ToString() + " AND " + foreignId + "=" + foreignValue.ToString();
                int rows = command.ExecuteNonQuery();
            }
            db.Close();
        }

        public void DeleteRecord(string Type, int id)
        {
            db = DbSetupManager.GetConnection();
            db.Open();
            using (command = new SQLiteCommand(db))
            {
                command.CommandText = "DELETE FROM " + Type + " WHERE ID=" + id;
                int rows = command.ExecuteNonQuery();
            }
            db.Close();
        }
    }
}
