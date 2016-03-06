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
    public partial class KeysForm : Form
    {
        ObjectHolder objects;

        public KeysForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            initializeKeyTab();
        }

        private void initializeKeyTab()
        {
            groupBoxKeyManage.Enabled = false;
            buttonKeyTabEditType.Enabled = false;
            buttonKeyTabEditKey.Enabled = false;
            buttonKeyTabDeleteType.Enabled = false;
            buttonKeytabDeleteKey.Enabled = false;
            buttonKeyTabAddDoor.Enabled = false;
            buttonKeyTabAddGroup.Enabled = false;
            buttonKeyTabRemoveDoor.Enabled = false;
            buttonKeyTabRemoveGroup.Enabled = false;
            comboBoxKeyTabKeyType.Items.Clear();
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
            groupBoxKeyManage.Enabled = true;
            labelKeyTabKeyTypeTitle.Text = "Key Type: " + type.Name;
            buttonKeyTabEditType.Enabled = true;
            buttonKeyTabDeleteType.Enabled = true;

            // list of keys ui
            listBoxKeyTabKeys.Items.Clear();
            foreach (Key key in type.keys)
            {
                listBoxKeyTabKeys.Items.Add(key.Serial);
            }
            listBoxKeyTabKeys.SelectedIndex = -1;

            // list of doors in ui
            listBoxKeyTabDoors.SelectedIndex = -1;
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

            // list of door groups in ui
            listBoxKeyTabDoorGroups.SelectedIndex = -1;
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
                buttonKeytabDeleteKey.Enabled = false;

                KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
                if (type != null)
                {
                    setKeytabKeytype(type);
                }
            }
        }

        private void comboBoxKeyTabKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key key = objects.getKeyBySerial((string)comboBoxKeyTabKey.SelectedItem);
            if (key != null)
            {
                KeyType type = key.KeyType;
                comboBoxKeyTabKeyType.SelectedIndex = comboBoxKeyTabKeyType.Items.IndexOf(type.Name);

                listBoxKeyTabKeys.SelectedIndex = listBoxKeyTabKeys.Items.IndexOf(key.Serial);
                buttonKeyTabEditKey.Enabled = true;
                buttonKeytabDeleteKey.Enabled = true;
            }
        }

        private void listBoxKeyTabKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonKeyTabEditKey.Enabled = listBoxKeyTabKeys.SelectedIndex != -1;
            buttonKeytabDeleteKey.Enabled = listBoxKeyTabKeys.SelectedIndex != -1;
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
            KeytypeDialog ktd = new KeytypeDialog();
            DialogResult result = ktd.ShowDialog();
            if (result == DialogResult.OK)
            {
                KeyType type = ktd.keytype;
                objects.keytypes.Add(type); // updates the OOP
                type.Save(); // updates the database

                // update the UI
                comboBoxKeyTabKeyType.Items.Add(type.Name);
                setKeytabKeytype(type);
            }
        }

        private void buttonKeyTabEditType_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            if (type != null)
            {
                KeytypeDialog ktd = new KeytypeDialog(type);
                DialogResult result = ktd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    type.Save(); // updates the database

                    // update the UI
                    initializeKeyTab();
                    setKeytabKeytype(type);
                }
            }
        }

        private void buttonKeyTabNewKey_Click(object sender, EventArgs e)
        {
            Key key = null;
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            if (type != null)
            {
                key = new Key(-1, "", false, false);
                key.KeyType = type;
            }

            KeyDialog kd = new KeyDialog(objects, key);
            DialogResult result = kd.ShowDialog();
            if (result == DialogResult.OK)
            {
                key = kd.key;
                // update the OOP
                objects.keys.Add(key);
                key.KeyType.keys.Add(key);
                if (key.KeyRing != null)
                {
                    key.KeyRing.keys.Add(key);
                }

                // update the database
                key.Save();

                // update the UI
                comboBoxKeyTabKey.Items.Add(key.Serial);
                setKeytabKeytype(key.KeyType);
                listBoxKeyTabKeys.SelectedItem = key.Serial;
            }
        }

        private void buttonKeyTabEditKey_Click(object sender, EventArgs e)
        {
            Key key = objects.getKeyBySerial((string)listBoxKeyTabKeys.SelectedItem);
            if (key != null)
            {
                KeyDialog kd = new KeyDialog(objects, key);
                DialogResult result = kd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // update OOP.
                    foreach (KeyType type in objects.keytypes)
                    {
                        type.keys.Remove(key);
                    }
                    foreach (KeyRing ring in objects.keyrings)
                    {
                        ring.keys.Remove(key);
                    }
                    key.KeyType.keys.Add(key);
                    if (key.KeyRing != null)
                    {
                        key.KeyRing.keys.Add(key);
                    }

                    // update the database
                    key.Save();

                    // update the ui
                    initializeKeyTab();
                    setKeytabKeytype(key.KeyType);
                    listBoxKeyTabKeys.SelectedItem = key.Serial;
                }
            }
        }

        private void buttonKeyTabAddDoor_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            Door door = objects.getDoorByRoomNumber((string)comboBoxKeyTabDoors.SelectedItem);
            if (type != null && door != null)
            {
                // update OOP and db
                door.ConnectKeyType(type);

                // update ui
                setKeytabKeytype(type);
            }
        }

        private void buttonKeyTabAddGroup_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            Location loc = objects.getLocationByName((string)comboBoxKeyTabDoorGroups.SelectedItem);
            if (type != null && loc != null)
            {
                // update the db and OOP
                foreach (Door door in loc.doors)
                {
                    door.ConnectKeyType(type);
                }

                // update the ui
                setKeytabKeytype(type);
            }
        }

        private void listBoxKeyTabDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonKeyTabRemoveDoor.Enabled = listBoxKeyTabDoors.SelectedIndex != -1;
        }

        private void listBoxKeyTabDoorGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonKeyTabRemoveGroup.Enabled = listBoxKeyTabDoorGroups.SelectedIndex != -1;
        }

        private void buttonKeyTabDeleteType_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            if (type != null)
            {
                // confirm the delete
                DialogResult result = MessageBox.Show("Really delete the key type " + type.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // check if db delete is possible, and if so update db and OOP
                    if (type.Delete())
                    {
                        // remove from OOP
                        objects.keytypes.Remove(type);

                        // update ui
                        comboBoxKeyTabKeyType.Text = "";
                        initializeKeyTab();
                    }
                    else
                    {
                        // delete not possible.  Inform the user.
                        MessageBox.Show("Key Manager has keys of this type on record.\nBefore deleting this keytype you must delete or those keys, or assign them to a new type.", "Cannot Delete");
                    }
                }
            }
        }

        private void buttonKeytabDeleteKey_Click(object sender, EventArgs e)
        {
            Key key = objects.getKeyBySerial((string)listBoxKeyTabKeys.SelectedItem);
            if (key != null)
            {
                // confirm the delete
                DialogResult result = MessageBox.Show("Really delete the key " + key.Serial + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // update OOP and database
                    key.KeyType.keys.Remove(key);
                    if (key.KeyRing != null)
                    {
                        key.KeyRing.keys.Remove(key);
                    }
                    key.Delete();

                    // redisplay
                    setKeytabKeytype(key.KeyType);
                }
            }
        }

        private void buttonKeyTabRemoveDoor_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            Door door = objects.getDoorByRoomNumber((string)listBoxKeyTabDoors.SelectedItem);
            if (type != null && door != null)
            {
                // update OOP and db
                door.DisconnectKeyType(type);

                // update ui
                setKeytabKeytype(type);
            }
        }

        private void buttonKeyTabRemoveGroup_Click(object sender, EventArgs e)
        {
            KeyType type = objects.getKeyTypeByName((string)comboBoxKeyTabKeyType.SelectedItem);
            Location loc = objects.getLocationByName((string)listBoxKeyTabDoorGroups.SelectedItem);
            if (type != null && loc != null)
            {
                // update the db and OOP
                foreach (Door door in loc.doors)
                {
                    door.DisconnectKeyType(type);
                }

                // update the ui
                setKeytabKeytype(type);
            }
        }
    }
}
