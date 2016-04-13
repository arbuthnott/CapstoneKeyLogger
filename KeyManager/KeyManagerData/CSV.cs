using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerData
{
    class CSV
    {
        DataLayer dl;

        public CSV()
        {
            dl = new DataLayer();
        }

        public string GetCSV()
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
            ListForCSV.Add(dl.GetAllRecords("key_to_lock"));
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
                if (count == 8) table = "[key_to_lock]";
                if (count == 9) table = "[checkout]";

                returnstring += table + Environment.NewLine;
                foreach (String str in list)
                {
                    returnstring += str + Environment.NewLine;
                }
            }

            return returnstring;
        }

        public void InsertCSV()
        {

        }
    }
}
