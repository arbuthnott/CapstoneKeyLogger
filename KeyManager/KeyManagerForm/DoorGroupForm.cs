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
                    labelDoorGroupTabGroupTitle.Text = "Door Group: " + loc.Name;
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

        private void listBoxDoorGroupTabInGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDoorGroupTabRemoveDoor.Enabled = listBoxDoorGroupTabInGroup.SelectedIndex != -1;
        }

        private void listBoxDoorGroupTabNotInGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDoorGroupTabAddDoor.Enabled = listBoxDoorGroupTabNotInGroup.SelectedIndex != -1;
        }

        private void buttonDoorGroupTabRemoveDoor_Click(object sender, EventArgs e)
        {
            foreach (Location loc in objects.locations)
            {
                if (loc.Name == (string)listBoxDoorGroupTabGroups.SelectedItem)
                {
                    Door door = null;
                    foreach (Door dr in loc.doors)
                    {
                        if (dr.RoomNumber == (string)listBoxDoorGroupTabInGroup.SelectedItem)
                        {
                            door = dr;
                        }
                    }
                    // update the OOP - later bring in the database too.
                    loc.RemoveDoor(door);

                    // update the UI
                    initializeDoorGroupTab();
                    listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
                }
            }
        }

        private void buttonDoorGroupTabAddDoor_Click(object sender, EventArgs e)
        {
            foreach (Location loc in objects.locations)
            {
                if (loc.Name == (string)listBoxDoorGroupTabGroups.SelectedItem)
                {
                    Door door = null;
                    foreach (Door dr in objects.doors)
                    {
                        if (dr.RoomNumber == (string)listBoxDoorGroupTabNotInGroup.SelectedItem)
                        {
                            door = dr;
                        }
                    }
                    // update the OOP - later bring in the database too.
                    loc.AddDoor(door);

                    // update the UI
                    initializeDoorGroupTab();
                    listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
                }
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
            /********************
             This code broke when it was moved out of Mainform.cs due to listBoxKeysets element.
             Will come back and fix.
             - Jared
            *********************/


            //open a dialog to change the name or other details
            foreach (Location loc in objects.locations)
            {
                if (loc.Name == (string)listBoxDoorGroupTabGroups.SelectedItem)
                {
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
        }
    }
}
