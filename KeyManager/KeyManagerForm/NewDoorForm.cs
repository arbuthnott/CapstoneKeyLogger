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
    public partial class NewDoorForm : Form
    {
        private ObjectHolder objects;
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Font normalFont = new Font("sans-serif", 8.5f);

        public NewDoorForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            SetupResultsView();
            PopulateResults("");
        }

        private void SetupResultsView()
        {
            listViewResults.View = View.Details;
            listViewResults.GridLines = true;
            listViewResults.FullRowSelect = true;
            listViewResults.LabelWrap = true;

            listViewResults.Columns.Add("RoomNumber", 100);
            listViewResults.Columns.Add("Groups", 160);
            listViewResults.Columns.Add("Key Types", 160);
            listViewResults.Columns.Add("Keys", 160);

            // the following serves to resize the rows.
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 48);
            listViewResults.SmallImageList = imgList;
        }

        private void PopulateResults(string searchTerm)
        {
            PopulateResults(objects.doors, searchTerm);
        }

        private void PopulateResults(List<Door> doors, string searchTerm)
        {
            listViewResults.Items.Clear();
            string room, groups, types, keys;

            bool isOdd = true;
            ListViewItem row;
            foreach (Door door in doors)
            {
                room = door.RoomNumber;
                groups = "";
                types = "";
                keys = "";
                foreach (Location loc in objects.locations)
                {
                    if (loc.doors.Contains(door))
                    {
                        groups += loc.Name + ", ";
                    }
                }
                foreach (KeyType type in door.keytypes)
                {
                    types += type.Name + ", ";
                    foreach (Key key in type.keys)
                    {
                        keys += key.Serial + ", ";
                    }
                }
                if (groups.Length == 0)
                {
                    groups = "None";
                }
                else
                {
                    groups = groups.Substring(0, groups.Length - 2); // remove last comma
                }
                if (types.Length == 0)
                {
                    types = "None";
                }
                else
                {
                    types = types.Substring(0, types.Length - 2); // remove last comma
                }
                if (keys.Length == 0)
                {
                    keys = "None";
                }
                else
                {
                    keys = keys.Substring(0, keys.Length - 2); // remove last comma
                }

                if (searchTerm == "" || (room + groups + types + keys).ToUpper().Contains(searchTerm.ToUpper()))
                {
                    // add the item.
                    string[] args = { room, groups, types, keys };
                    row = new ListViewItem(args);
                    row.Tag = door;
                    row.BackColor = isOdd ? lightBlue : evenLighterBlue;
                    row.Font = normalFont;

                    listViewResults.Items.Add(row);
                    isOdd = !isOdd;
                }
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<Door> doors = objects.doors;
            switch (e.Column)
            {
                case 0:
                    // room
                    doors.Sort((x, y) => x.RoomNumber.CompareTo(y.RoomNumber));
                    PopulateResults(doors, textBoxSearch.Text);
                    break;
                case 2:
                    // keytypes
                    doors.Sort((x, y) => -1 * x.keytypes.Count.CompareTo(y.keytypes.Count));
                    PopulateResults(doors, textBoxSearch.Text);
                    break;
                default:
                    break;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // TODO: open form to create new door
            DoorDialog dd = new DoorDialog(objects, (MDI_ParentForm)MdiParent);
            DialogResult result = dd.ShowDialog();
            if (result == DialogResult.OK)
            {
                // create the door
            }
            dd.Dispose();
        }

        private void listViewResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO: show a dialog to edit selected row.
            ListViewItem item = listViewResults.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                Door door = (Door)item.Tag;
                DoorDialog dd = new DoorDialog(objects, (MDI_ParentForm)MdiParent, door);
                DialogResult result = dd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // update the door
                }
                else if (result == DialogResult.No) // sign to delete the door
                {
                    // delete it.
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateResults(textBoxSearch.Text);
        }
    }
}
