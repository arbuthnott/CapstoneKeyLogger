using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyManagerData;
using KeyManagerClassLib;

namespace KeyManagerForm
{
    public partial class DoorGroupForm : Form
    {
        ObjectHolder objects;

        public DoorGroupForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            initializeDoorGroupTab();
        }

        /// <summary>
        /// Clear and populate listboxes etc from the OOP.
        /// </summary>
        private void initializeDoorGroupTab()
        {
            groupBoxDoorGroupManage.Enabled = false;
            buttonDoorGroupTabAddDoor.Enabled = false;
            buttonDoorGroupTabRemoveDoor.Enabled = false;

            // add door groups
            listBoxDoorGroupTabGroups.Items.Clear();
            foreach (Location loc in objects.locations)
            {
                listBoxDoorGroupTabGroups.Items.Add(loc.Name);
            }
        }

        /// <summary>
        /// View details (and enable editing) of the selected door group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDoorGroupTabGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxDoorGroupManage.Enabled = true;
            listBoxDoorGroupTabInGroup.SelectedIndex = -1;
            listBoxDoorGroupTabNotInGroup.SelectedIndex = -1;
            listBoxDoorGroupTabInGroup.Items.Clear();
            listBoxDoorGroupTabNotInGroup.Items.Clear();
            foreach (Location loc in objects.locations)
            {
                if (loc.Name == (string)listBoxDoorGroupTabGroups.SelectedItem)
                {
                    labelDoorGroupTabGroupTitle.Text = loc.Name;
                    // populate the door lists
                    foreach (Door door in objects.doors)
                    {
                        listBoxDoorGroupTabNotInGroup.Items.Add(door.RoomNumber);
                    }
                    foreach (Door door in loc.doors)
                    {
                        listBoxDoorGroupTabInGroup.Items.Add(door.RoomNumber);
                        listBoxDoorGroupTabNotInGroup.Items.Remove(door.RoomNumber);
                    }
                }
            }
        }

        /// <summary>
        /// Enable a door-in-group's removal if selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDoorGroupTabInGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDoorGroupTabRemoveDoor.Enabled = listBoxDoorGroupTabInGroup.SelectedIndex != -1;
        }

        /// <summary>
        /// Enable a door-not-in-group's addition to the group if selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDoorGroupTabNotInGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDoorGroupTabAddDoor.Enabled = listBoxDoorGroupTabNotInGroup.SelectedIndex != -1;
        }

        /// <summary>
        /// Removed selected door from the group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoorGroupTabRemoveDoor_Click(object sender, EventArgs e)
        {
            Location loc = objects.getLocationByName((string)listBoxDoorGroupTabGroups.SelectedItem);
            Door door = objects.getDoorByRoomNumber((string)listBoxDoorGroupTabInGroup.SelectedItem);

            if (loc != null && door != null)
            {
                // update the OOP and database
                loc.RemoveDoor(door);

                // update the UI
                initializeDoorGroupTab();
                listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
            }
        }

        /// <summary>
        /// Add selected door to the group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoorGroupTabAddDoor_Click(object sender, EventArgs e)
        {
            Location loc = objects.getLocationByName((string)listBoxDoorGroupTabGroups.SelectedItem);
            Door door = objects.getDoorByRoomNumber((string)listBoxDoorGroupTabNotInGroup.SelectedItem);

            if (loc != null && door != null)
            {
                // update the OOP and database
                loc.AddDoor(door);

                // update the UI
                initializeDoorGroupTab();
                listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
            }
        }

        private void buttonDoorGroupTabNewGroup_Click(object sender, EventArgs e)
        {
            // use a dialog to create a new door group
            DoorGroupDialog dgd = new DoorGroupDialog();
            if (dgd.ShowDialog() == DialogResult.OK)
            {
                // update the OOP and the database
                Location loc = dgd.location;
                loc.Save();
                objects.locations.Add(loc);
                // redisplay
                initializeDoorGroupTab();
                listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
            }
            dgd.Close();
        }

        private void buttonDoorGroupTabEditGroup_Click(object sender, EventArgs e)
        {
            Location loc = objects.getLocationByName((string)listBoxDoorGroupTabGroups.SelectedItem);
            if (loc != null)
            {
                //open a dialog to change the name or other details
                DoorGroupDialog dgd = new DoorGroupDialog(loc);
                if (dgd.ShowDialog() == DialogResult.OK)
                {
                    // update the Door Group - OOP and database.
                    loc.Name = dgd.location.Name;
                    loc.Save();
                    // redisplay
                    initializeDoorGroupTab();
                    listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
                }
                dgd.Close();
            }
        }

        private void buttonDoorGroupTabDelete_Click(object sender, EventArgs e)
        {
            Location loc = objects.getLocationByName((string)listBoxDoorGroupTabGroups.SelectedItem);
            if (loc != null)
            {
                // confirm the delete
                DialogResult result = MessageBox.Show("Really delete the group " + loc.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // update OOP and database
                    loc.Delete();
                    objects.locations.Remove(loc);

                    // redisplay
                    initializeDoorGroupTab();
                }
            }
        }
    }
}
