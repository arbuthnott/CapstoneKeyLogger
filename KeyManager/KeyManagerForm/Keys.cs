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
    public partial class Keys : Form
    {
        ObjectHolder objects;

        public Keys(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            initializeKeyTab();
        }

        private void initializeKeyTab()
        {
            //groupBoxKeyManage.Enabled = false;  -- Where is this??
            buttonKeyTabEditType.Enabled = false;
            buttonKeyTabEditKey.Enabled = false;
            buttonKeyTabAddDoor.Enabled = false;
            buttonKeyTabAddGroup.Enabled = false;
            foreach (KeyType type in objects.keytypes)
            {
                comboBoxKeyTabKeyType.Items.Add(type.Name);
            }
            foreach (Key key in objects.keys)
            {
                comboBoxKeyTabKey.Items.Add(key.Serial);
            }
        }

        private void setKeytabKeytype(KeyType type)
        {
            //groupBoxKeyManage.Enabled = true;  -- Where is this??
            buttonKeyTabEditType.Enabled = true;
            listBoxKeyTabKeys.Items.Clear();
            foreach (Key key in type.keys)
            {
                listBoxKeyTabKeys.Items.Add(key.Serial);
            }
            labelKeyTabKeyTypeTitle.Text = "Key Type: " + type.Name;
            listBoxKeyTabDoors.Items.Clear();
            comboBoxKeyTabDoors.SelectedIndex = -1;
            comboBoxKeyTabDoors.Items.Clear();
            foreach (Door door in objects.doors)
            {
                if (type.doors.Contains(door))
                {
                    listBoxKeyTabDoors.Items.Add(door.RoomNumber);
                }
                else
                {
                    comboBoxKeyTabDoors.Items.Add(door.RoomNumber);
                }
            }
            listBoxKeyTabDoorGroups.Items.Clear();
            comboBoxKeyTabDoorGroups.SelectedIndex = -1;
            comboBoxKeyTabDoorGroups.Items.Clear();
            foreach (Location loc in objects.locations)
            {
                if (!loc.doors.Except(type.doors).Any()) // this checks if type.doors contains loc.doors
                {
                    listBoxKeyTabDoorGroups.Items.Add(loc.Name);
                }
                else
                {
                    comboBoxKeyTabDoorGroups.Items.Add(loc.Name);
                }
            }
        }

        private void comboBoxKeyTabKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKeyTabKey.SelectedIndex = -1;
            if (comboBoxKeyTabKeyType.SelectedIndex != -1)
            {
                buttonKeyTabEditKey.Enabled = false;

                foreach (KeyType type in objects.keytypes)
                {
                    if (type.Name == (string)comboBoxKeyTabKeyType.SelectedItem)
                    {
                        setKeytabKeytype(type);
                    }
                }
            }
        }

        private void comboBoxKeyTabKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKeyTabKey.SelectedIndex != -1)
            {
                foreach (Key key in objects.keys)
                {
                    if (key.Serial == (string)comboBoxKeyTabKey.SelectedItem)
                    {
                        KeyType type = key.KeyType;
                        comboBoxKeyTabKeyType.SelectedIndex = comboBoxKeyTabKeyType.Items.IndexOf(type.Name);
                        //setKeytabKeytype(type);

                        listBoxKeyTabKeys.SelectedIndex = listBoxKeyTabKeys.Items.IndexOf(key.Serial);
                        buttonKeyTabEditKey.Enabled = true;
                    }
                }
            }
        }

        private void listBoxKeyTabKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKeyTabKeys.SelectedIndex != 1)
            {
                buttonKeyTabEditKey.Enabled = true;
            }
        }

        private void comboBoxKeyTabDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonKeyTabAddDoor.Enabled = (comboBoxKeyTabDoors.SelectedIndex != -1);
        }

        private void comboBoxKeyTabDoorGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonKeyTabAddGroup.Enabled = (comboBoxKeyTabDoorGroups.SelectedIndex != -1);
        }

        private void buttonKeyTabNewType_Click(object sender, EventArgs e)
        {
            //TODO open dialog to create new KeyType
        }

        private void buttonKeyTabEditType_Click(object sender, EventArgs e)
        {
            //TODO open dialog to edit selected keytype
        }

        private void buttonKeyTabNewKey_Click(object sender, EventArgs e)
        {
            //TODO open dialog to create new key (default to selected keytype if any)
        }

        private void buttonKeyTabEditKey_Click(object sender, EventArgs e)
        {
            //TODO open dialog to edit selected key
        }

        private void buttonKeyTabAddDoor_Click(object sender, EventArgs e)
        {
            //TODO connect the selected door to selected keytype and update UI
        }

        private void buttonKeyTabAddGroup_Click(object sender, EventArgs e)
        {
            //TODO connect all doors in selected doorgroup to selected keytype and update UI.
        }

        private void pictureBoxKeyTab_Click(object sender, EventArgs e)
        {

        }

        private void listBoxKeyTabDoors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKeyTabDoorGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
