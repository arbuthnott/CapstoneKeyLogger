﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using KeyManagerData;
using KeyManagerClassLib;

namespace KeyManagerForm
{
    public partial class MainForm : Form
    {
        private bool isAdmin = false;
        private Login loginForm;
        private bool loggingOut = false;
        private ObjectHolder objects;

        public MainForm(Login lgnForm, bool admin)
        {
            InitializeComponent();
            objects = new ObjectHolder();
            initializeLookupTab();
            if (admin)
            {
                isAdmin = true;
                
                initializeKeySetTab();
            }

            if (admin)
                lblAdmin.Text = "Hello, Administrator";
            else
            {
                lblAdmin.Text = "Hello User";
                tabControl.TabPages.Remove(tabPageKeysets);
            }
            this.loginForm = lgnForm;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggingOut = true;
            loginForm.Logout();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            loggingOut = true;
            loginForm.Logout();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loggingOut)
            {
                loginForm.Close();
            }
        }

        /*********************************************
        * KEYSET TAB STUFF
        *********************************************/
        
        private void initializeKeySetTab()
        {
            groupBoxKeysetManage.Enabled = false;
            foreach (KeyRing ring in objects.keyrings)
            {
                listBoxKeysets.Items.Add(ring.Name);
            }
        }

        private void listBoxKeysets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // display details of selected keyset for management.
            // may need to refactor to use OOP Classes.

            // check if discarding changes
            if (buttonSaveKeysetChanges.Enabled)
            {
                DialogResult confirmResult = MessageBox.Show("Do you want to save changes to this keyset?", "Save Changes?", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // save the changes before proceding!
                    buttonSaveKeysetChanges_Click(null, null);
                }
            }
            groupBoxKeysetManage.Enabled = true;
            buttonSaveKeysetChanges.Enabled = false;
            labelKeysetTitle.Text = (String)listBoxKeysets.SelectedItem;

            // populate keys in this keyring
            listBoxKeysInKeyset.Items.Clear();
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            String line;
            foreach (Key key in ring.keys)
            {
                line = key.Serial + " (" + key.KeyType.Name + ")";
                listBoxKeysInKeyset.Items.Add(line);
            }

            // populate keys available
            listBoxKeysNotInKeyset.Items.Clear();
            foreach (Key key in objects.keys)
            {
                line = key.Serial + " (" + key.KeyType.Name + ")";
                if (key.KeyRing == null)
                {
                    listBoxKeysNotInKeyset.Items.Add(line);
                }
            }
        }

        private void buttonCreateKeyset_Click(object sender, EventArgs e)
        {
            // use a dialog to create a new keyset?
        }

        private void buttonKeysetEdit_Click(object sender, EventArgs e)
        {
            // open a dialog to change the name or other details (owner?)
        }

        private void buttonAddKeysetKey_Click(object sender, EventArgs e)
        {
            // move the list items.
            if (listBoxKeysNotInKeyset.SelectedIndex != -1)
            {
                // update the UI - no OOP or Database changes yet.
                buttonSaveKeysetChanges.Enabled = true;
                string line = (string)listBoxKeysNotInKeyset.SelectedItem;
                listBoxKeysNotInKeyset.Items.Remove(line);
                listBoxKeysInKeyset.Items.Add(line);
            }
        }

        private void buttonRemoveKeysetKey_Click(object sender, EventArgs e)
        {
            // move the list items.
            if (listBoxKeysInKeyset.SelectedIndex != -1)
            {
                // update the UI - no OOP or Database changes yet.
                buttonSaveKeysetChanges.Enabled = true;
                string line = (string)listBoxKeysInKeyset.SelectedItem;
                listBoxKeysInKeyset.Items.Remove(line);
                listBoxKeysNotInKeyset.Items.Add(line);
            }
        }

        private void buttonSaveKeysetChanges_Click(object sender, EventArgs e)
        {
            // TEMPORARY HACK to update the OOP only.
            // later implement OOP and database changes together.
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            ring.keys.Clear();
            string entry;
            foreach (Key key in objects.keys)
            {
                // put keys into the set
                for (int idx = 0; idx < listBoxKeysInKeyset.Items.Count; idx++)
                {
                    entry = (string)listBoxKeysInKeyset.Items[idx];
                    if (entry.StartsWith(key.Serial))
                    {
                        key.KeyRing = ring;
                        ring.AddKey(key);
                    }
                }
                // ensure excluded keys not in the set
                for (int idx = 0; idx < listBoxKeysNotInKeyset.Items.Count; idx++)
                {
                    entry = (string)listBoxKeysNotInKeyset.Items[idx];
                    if (entry.StartsWith(key.Serial))
                    {
                        key.KeyRing = null;
                    }
                }
            }
            // END TEMPORARY HACK
            
            // update the ui
            buttonSaveKeysetChanges.Enabled = false;
            MessageBox.Show("Changes saved.");
        }

        /*********************************************
        * LOOKUP TAB STUFF
        *********************************************/

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
