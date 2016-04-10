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
            PersonnelDialog pdialog = new PersonnelDialog();
            DialogResult result = pdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Personnel person = pdialog.person;
                objects.personnel.Add(person);
                person.Save();

                PopulateResults("");
            }
        }

        private void listViewResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO: show a dialog to edit selected row.
            ListViewItem item = listViewResults.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Personnel person = (Personnel)item.Tag;
                PersonnelDialog pdialog = new PersonnelDialog(person);
                DialogResult result = pdialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // person already updated in place - just commit to the db
                    person.Save();
                    PopulateResults(textBoxSearch.Text);
                }
                else if (result == DialogResult.No)
                {
                    // a signal to delete this person.
                    person.Delete();
                    objects.personnel.Remove(person);
                    PopulateResults(textBoxSearch.Text);
                }
                pdialog.Dispose();
            }
        }

        private void SetupResultsView()
        {
            listViewResults.View = View.Details;
            listViewResults.GridLines = true;
            listViewResults.FullRowSelect = true;

            listViewResults.Columns.Add("Username", 100);
            listViewResults.Columns.Add("Full Name", 100);
            listViewResults.Columns.Add("Permissions", 90);
            listViewResults.Columns.Add("Checked-out Rings", 150);
            listViewResults.Columns.Add("Checked-out Keys", 150);

            // the following serves to resize the rows.
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            listViewResults.SmallImageList = imgList;
        }

        private void PopulateResults(string searchTerm)
        {
            PopulateResults(objects.personnel, searchTerm);
        }

        private void PopulateResults(List<Personnel> people, string searchTerm)
        {
            listViewResults.Items.Clear();
            string userName, fullName, permission, ringList, keyList;

            bool isOdd = true;
            ListViewItem row;
            foreach (Personnel person in people)
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
                    row.Tag = person;
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
            List<Personnel> people = objects.personnel;
            switch (e.Column)
            {
                case 0:
                    // username
                    people.Sort((x, y) => (x.UserName != null ? x.UserName : "zzz").CompareTo(y.UserName != null ? y.UserName : "zzz"));
                    PopulateResults(people, textBoxSearch.Text);
                    break;
                case 1:
                    // fullname
                    people.Sort((x, y) => (x.FirstName + " " + x.LastName).CompareTo(y.FirstName + " " + y.LastName));
                    PopulateResults(people, textBoxSearch.Text);
                    break;
                case 2:
                    // permissions
                    people.Sort((x, y) => (x.UserName == null ? "zzz" : "" + (!x.IsAdmin).ToString()).CompareTo(y.UserName == null ? "zzz" : "" + (!y.IsAdmin).ToString()));
                    PopulateResults(people, textBoxSearch.Text);
                    break;
                case 3:
                    // keyrings
                    people.Sort((x, y) => -1 * x.Keyrings.Count.CompareTo(y.Keyrings.Count));
                    PopulateResults(people, textBoxSearch.Text);
                    break;
                case 4:
                    // keys
                    people.Sort((x, y) => -1* x.Keys.Count.CompareTo(y.Keys.Count));
                    PopulateResults(people, textBoxSearch.Text);
                    break;
                default:
                    break;
            }
        }

        
    }
}
