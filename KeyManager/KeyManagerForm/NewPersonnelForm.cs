using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyManagerClassLib;

namespace KeyManagerForm
{
    public partial class NewPersonnelForm : Form
    {
        private ObjectHolder objects;
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Font normalFont = new Font("sans-serif", 8.5f);

        public NewPersonnelForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            SetupResultsView();
            PopulateResults("");
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateResults(textBoxSearch.Text);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // TODO: show a new personnel form.
        }

        private void listViewResults_DoubleClick(object sender, EventArgs e)
        {
            // TODO: if clicked a row, open edit form for that personnel.
        }

        private void SetupResultsView()
        {
            listViewResults.View = View.Details;
            listViewResults.GridLines = true;
            listViewResults.FullRowSelect = true;

            listViewResults.Columns.Add("Username", 100);
            listViewResults.Columns.Add("Full Name", 100);
            listViewResults.Columns.Add("Permissions", 80);
            listViewResults.Columns.Add("Checked-out Rings", 150);
            listViewResults.Columns.Add("Checked-out Keys", 150);

            // the following serves to resize the rows.
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            listViewResults.SmallImageList = imgList;
        }

        private void PopulateResults(string searchTerm)
        {
            listViewResults.Items.Clear();
            string userName, fullName, permission, ringList, keyList;

            bool isOdd = true;
            ListViewItem row;
            foreach (Personnel person in objects.personnel)
            {
                userName = "" + person.UserName;
                fullName = person.FirstName + " " + person.LastName;
                permission = person.IsAdmin ? "Admin" : "User";
                if (userName == "") { permission = "None"; } // hack
                ringList = "None";
                keyList = "None";
                if (person.Keyrings.Count > 0)
                {
                    ringList = "";
                    foreach (KeyRing ring in person.Keyrings)
                    {
                        ringList += ring.Name + ", ";
                    }
                    ringList = ringList.Substring(0, ringList.Length - 2); // remove last comma
                }
                if (person.Keys.Count > 0)
                {
                    keyList = "";
                    foreach (Key key in person.Keys)
                    {
                        keyList += key.Serial + ", ";
                    }
                    keyList = keyList.Substring(0, keyList.Length - 2); // remove last comma
                }

                if (searchTerm == "" || (userName + fullName + permission + ringList + keyList).ToUpper().Contains(searchTerm.ToUpper()))
                {
                    // add the item.
                    string[] args = { userName, fullName, permission, ringList, keyList };
                    row = new ListViewItem(args);
                    row.BackColor = isOdd ? lightBlue : evenLighterBlue;
                    row.Font = normalFont;

                    listViewResults.Items.Add(row);
                    isOdd = !isOdd;
                }
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // TODO: enable sort-by on some columns?
        }

        
    }
}
