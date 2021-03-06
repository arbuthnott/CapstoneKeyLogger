﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerData
{
    public class CSV
    {
        DataLayer dl;
        SQLiteConnection conn;
        private string HEADER = "// KEYMANAGER CSV EXPORT";

        public CSV()
        {
            dl = new DataLayer();
        }

        public string GetCSV()
        {
            try
            {
                string returnstring = "";

                string table = "";
                int count = 0;
                List<List<String>> ListForCSV = new List<List<string>>();
                ListForCSV.Add(dl.GetAllRecords("key"));
                ListForCSV.Add(dl.GetAllRecords("personnel"));
                ListForCSV.Add(dl.GetAllRecords("lock"));
                ListForCSV.Add(dl.GetAllRecords("keytype"));
                ListForCSV.Add(dl.GetAllRecords("door"));
                ListForCSV.Add(dl.GetAllRecords("location"));
                ListForCSV.Add(dl.GetAllRecords("keyring"));
                ListForCSV.Add(dl.GetAllRecords("door_to_location"));
                ListForCSV.Add(dl.GetAllRecords("keytype_to_lock"));
                ListForCSV.Add(dl.GetAllRecords("checkout"));
                foreach (List<String> list in ListForCSV)
                {

                    if (count == 0) table = "[key]";
                    if (count == 1) table = "[personnel]";
                    if (count == 2) table = "[lock]";
                    if (count == 3) table = "[keytype]";
                    if (count == 4) table = "[door]";
                    if (count == 5) table = "[location]";
                    if (count == 6) table = "[keyring]";
                    if (count == 7) table = "[door_to_location]";
                    if (count == 8) table = "[keytype_to_lock]";
                    if (count == 9) table = "[checkout]";

                    returnstring += table + Environment.NewLine;
                    foreach (String str in list)
                    {
                        returnstring += str + Environment.NewLine;
                    }
                    count++;
                }
                
                string headerstring = HEADER + Environment.NewLine;
                headerstring += "// CREATED ON " + DateTime.Now.ToLongDateString() + Environment.NewLine;
                return headerstring + returnstring;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        String escapeString(String text)
        {
            // Escape single quotes (used for values) 
            // with doubledup quotes (the sqlite equivalent to \')
            return text.Replace("'", "''");
        }

        void Insertion(String table, String[] args)
        {
            // replace black arguments with NULL
            for (int idx = 0; idx < args.Length; idx++)
            {
                args[idx] = args[idx].Replace("COMMA", ",");
                if (args[idx].Length == 0)
                {
                    args[idx] = "NULL";
                }
            }

            string command = "";
            if (table == "[key]")
            {
                command = "INSERT INTO key ('ID', 'Serial', 'Keytype', 'Keyring') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "', " + escapeString(args[2]) + ", " + escapeString(args[3]) + ")";
            }
            if (table == "[personnel]")
            {
                command = "INSERT INTO personnel ('ID', 'Username', 'Password', 'First Name', 'Last Name', 'IsAdministrator') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "', '" + escapeString(args[2]) + "', '" + escapeString(args[3]) + "', '" + escapeString(args[4]) + "', " + escapeString(args[5]) + ")";
            }
            if (table == "[lock]")
            {
                command = "INSERT INTO lock ('ID') VALUES (" + escapeString(args[0]) + ")";
            }
            if (table == "[keytype]")
            {
                command = "INSERT INTO keytype ('ID', 'Name') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "')";
            }
            if (table == "[door]")
            {
                command = "INSERT INTO door ('ID', 'room_number', 'lock') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "', " + escapeString(args[2]) + ")";
            }
            if (table == "[location]")
            {
                command = "INSERT INTO location ('ID', 'Name') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "')";
            }
            if (table == "[keyring]")
            {
                command = "INSERT INTO keyring ('ID', 'Name', 'owner') VALUES (" + escapeString(args[0]) + ", '" + escapeString(args[1]) + "', " + escapeString(args[2]) + ")";
            }
            if (table == "[door_to_location]")
            {
                command = "INSERT INTO door_to_location ('ID', 'Door', 'Location') VALUES (" + escapeString(args[0]) + ", " + escapeString(args[1]) + ", " + escapeString(args[2]) + ")";
            }
            if (table == "[keytype_to_lock]")
            {
                command = "INSERT INTO keytype_to_lock ('Keytype', 'Lock') VALUES (" + escapeString(args[0]) + ", " + escapeString(args[1]) + ")";
            }
            if (table == "[checkout]")
            {
                command = "INSERT INTO checkout ('ID', 'Person', 'Key', 'Keyring', 'IsReturned', 'Date') VALUES (" + escapeString(args[0]) + ", " + escapeString(args[1]) + ", " + escapeString(args[2]) + ", " + escapeString(args[3]) + ", " + escapeString(args[4]) + ", '" + escapeString(args[5]) + "')";
            }

            if (command != "")
            {
                command = command.Replace("'NULL'", "NULL"); // don't insert the string 'NULL'
                SQLiteCommand sqlcommand = new SQLiteCommand(command, conn);
                sqlcommand.ExecuteNonQuery();
            }
        }

        public string InsertCSV(string csv)
        {
            conn = DbSetupManager.GetConnection();
            try
            {
                using (StreamReader reader = new StreamReader(csv))
                {
                    DbSetupManager.EmptyDatabase();

                    string table = "[key]";
                    string line;

                    // check for the recognizable header
                    line = reader.ReadLine();
                    if (!line.StartsWith(HEADER))
                    {
                        return "refuse"; // this is not the csv you are looking for!
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("//"))
                        { }
                        else if (line.StartsWith("["))
                        {
                            table = line.TrimEnd(' ');
                        }
                        else
                        {
                            string[] inputs = line.Split(',');
                            Insertion(table, inputs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return "error";
            }
            conn.Close();
            return "complete";
        }
    }
}
