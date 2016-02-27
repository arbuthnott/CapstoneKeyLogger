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
        List<bool> isStringList;
        public DataLayer()
        {
            properties = new List<string>();
            values = new List<string>();
            isStringList = new List<bool>();
        }

        public void AddValue(bool isString, string Type, string Value)
        {
            isStringList.Add(isString);
            properties.Add(Type);
            values.Add(Value);
        }

        public int AddRecord(string Type)
        {
            db = DbSetupManager.GetConnection();
            using (command = new SQLiteCommand(db))
            {
                command.CommandText = "INSERT INTO " + Type + " (";
                for (int count = 0; count < properties.Count; count++)
                {

                    command.CommandText += "'" + properties[count] + "'";
                    if ((count + 1) < properties.Count) { command.CommandText += ", "; }
                }
                command.CommandText += ") VALUES (";
                for (int count = 0; count < values.Count; count++)
                {
                    if (isStringList[count])
                    {
                        command.CommandText += "'" + values[count] + "'";
                    }
                    else
                    {
                        command.CommandText += values[count];
                    }
                    if ((count + 1) < values.Count) { command.CommandText += ", "; }
                }
                command.CommandText += ")";
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
                command.CommandText = "UPDATE " + Type + " SET ";
                for (int count = 0; count < properties.Count; count++)
                {
                    command.CommandText += "'" + properties[count] + "' = ";
                    if (isStringList[count])
                    {
                        command.CommandText += "'" + values[count] + "'";
                    }
                    else
                    {
                        command.CommandText += values[count];
                    }
                    if ((count + 1) < properties.Count) { command.CommandText += ", "; }
                }
                command.CommandText += " WHERE ID = " + id;
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
