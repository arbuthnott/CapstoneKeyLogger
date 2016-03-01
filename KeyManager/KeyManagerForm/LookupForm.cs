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
    public partial class LookupForm : Form
    {
        ObjectHolder objects;

        public LookupForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            initializeLookupTab();
        }

        private void initializeLookupTab()
        {
            foreach (Door door in objects.doors)
            {
                comboBoxDoorLookup.Items.Add(door.RoomNumber);
            }
            foreach (KeyType type in objects.keytypes)
            {
                comboBoxKeytypeLookup.Items.Add(type.Name);
            }
            foreach (Key key in objects.keys)
            {
                comboBoxKeyserialLookup.Items.Add(key.Serial);
            }
        }

        private void comboBoxDoorLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDoorLookup.SelectedIndex == -1)
            {
                return; // the box was just blanked out.
            }
            // blank out the other two drop-downs
            comboBoxKeytypeLookup.SelectedIndex = -1;
            comboBoxKeyserialLookup.SelectedIndex = -1;

            // lookup the door data and populate the lists.
            string selectedDoor = (string)comboBoxDoorLookup.SelectedItem;
            listBoxLookupKeysets.Items.Clear();
            labelLookupResultsTitle.Text = "Results for Door: " + selectedDoor;

            // set key types for door
            textBoxLookupKeysets.Text = "Keytypes that open door " + selectedDoor;
            foreach (KeyType type in objects.keytypes)
            {
                foreach (Door door in type.doors)
                {
                    if (door.RoomNumber.Equals(selectedDoor))
                    {
                        listBoxLookupKeysets.Items.Add(type.Name);
                    }
                }
            }

            // set keys for door
            textBoxLookupKeys.Text = "Keys that open door " + selectedDoor;
            listBoxLookupKeys.Items.Clear();
            foreach (Door door in objects.doors)
            {
                if (door.RoomNumber.Equals(selectedDoor))
                {
                    if (door.keytypes != null)
                    {
                        foreach (KeyType type in door.keytypes)
                        {
                            foreach (Key key in type.keys)
                            {
                                listBoxLookupKeys.Items.Add(key.Serial);
                            }
                        }
                    }
                }
            }

            // set keyrings for doors
            textBoxLookupKeyrings.Text = "Keyrings that can open " + selectedDoor;
            listBoxLookupKeyrings.Items.Clear();
            foreach (Door door in objects.doors)
            {
                if (door.RoomNumber.Equals(selectedDoor))
                {
                    if (door.keytypes != null)
                    {
                        foreach (KeyType type in door.keytypes)
                        {
                            foreach (Key key in type.keys)
                            {
                                if (key.KeyRing != null)
                                {
                                    if (!listBoxLookupKeyrings.Items.Contains(key.KeyRing.Name))
                                        listBoxLookupKeyrings.Items.Add(key.KeyRing.Name);
                                }
                            }
                        }
                    }
                }
            }

            // doors related to the door
            textBoxLookupDoors.Text = "Selected Door";
            listBoxLookupDoors.Items.Clear();
            listBoxLookupDoors.Items.Add(selectedDoor);

        }

        private void comboBoxKeytypeLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKeytypeLookup.SelectedIndex == -1)
            {
                return; // the box was just blanked out.
            }
            // blank out the other two drop-downs
            comboBoxDoorLookup.SelectedIndex = -1;
            comboBoxKeyserialLookup.SelectedIndex = -1;

            // lookup the door data and populate the lists.
            string selectedKeyType = (string)comboBoxKeytypeLookup.SelectedItem;
            listBoxLookupKeysets.Items.Clear();
            labelLookupResultsTitle.Text = "Results for Key Type: " + selectedKeyType;

            // set key types
            textBoxLookupKeysets.Text = "Selected Key Type";
            listBoxLookupKeysets.Items.Add(selectedKeyType);

            // keys for this keytype
            textBoxLookupKeys.Text = "Keys that are of type " + selectedKeyType;
            listBoxLookupKeys.Items.Clear();
            foreach (KeyType type in objects.keytypes)
            {
                if (type.Name.Equals(selectedKeyType))
                {
                    foreach (Key key in type.keys)
                    {
                        listBoxLookupKeys.Items.Add(key.Serial);
                    }
                }
            }

            // keyrings of this type
            textBoxLookupKeyrings.Text = "Keyrings that have key type " + selectedKeyType;
            listBoxLookupKeyrings.Items.Clear();
            foreach (KeyType type in objects.keytypes)
            {
                if (type.Name.Equals(selectedKeyType))
                {
                    foreach (Key key in type.keys)
                    {
                        if (key.KeyRing != null)
                            if (!listBoxLookupKeyrings.Items.Contains(key.KeyRing.Name))
                                listBoxLookupKeyrings.Items.Add(key.KeyRing.Name);
                    }
                }
            }

            // doors that this key type opens
            textBoxLookupDoors.Text = "Doors that this key type opens";
            listBoxLookupDoors.Items.Clear();
            foreach (KeyType type in objects.keytypes)
            {
                if (type.Name.Equals(selectedKeyType))
                {
                    foreach (Door door in type.doors)
                    {
                        listBoxLookupDoors.Items.Add(door.RoomNumber);
                    }
                }
            }

        }

        private void comboBoxKeyserialLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKeyserialLookup.SelectedIndex == -1)
            {
                return; // the box was just blanked out.
            }
            // blank out the other two drop-downs
            comboBoxKeytypeLookup.SelectedIndex = -1;
            comboBoxDoorLookup.SelectedIndex = -1;

            // lookup the key data and populate the lists.
            string selectedSerial = (string)comboBoxKeyserialLookup.SelectedItem;
            listBoxLookupKeysets.Items.Clear();
            labelLookupResultsTitle.Text = "Results for Serial #: " + selectedSerial;

            // set key types for door
            textBoxLookupKeysets.Text = "Keytypes for serial #: " + selectedSerial;
            foreach (Key key in objects.keys)
            {
                if (key.Serial.Equals(selectedSerial))
                {
                    listBoxLookupKeysets.Items.Add(key.KeyType.Name);
                }
            }

            // keys for this serial
            textBoxLookupKeys.Text = "Key(s) with serial #: " + selectedSerial;
            listBoxLookupKeys.Items.Clear();
            foreach (Key key in objects.keys)
            {
                if (key.Serial.Equals(selectedSerial))
                    listBoxLookupKeys.Items.Add(key.Serial);
            }

            // keyrings for this serial
            textBoxLookupKeyrings.Text = "Keyrings that contain serial #: " + selectedSerial;
            listBoxLookupKeyrings.Items.Clear();
            foreach (KeyType type in objects.keytypes)
            {
                foreach (Key key in type.keys)
                {
                    if (key.Serial.Equals(selectedSerial))
                        listBoxLookupKeyrings.Items.Add(type.Name);
                }
            }

            // doors that this key opens
            textBoxLookupDoors.Text = "Doors that this key opens";
            listBoxLookupDoors.Items.Clear();
            foreach (KeyType type in objects.keytypes)
            {
                foreach (Key key in type.keys)
                {
                    if (key.Serial.Equals(selectedSerial))
                    {
                        foreach (Door door in type.doors)
                        {
                            listBoxLookupDoors.Items.Add(door.RoomNumber);
                        }
                    }
                }
            }
        }

       
    }
}
