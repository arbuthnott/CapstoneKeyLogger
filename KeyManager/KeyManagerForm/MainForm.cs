using System;
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
                lblAdmin.Text = "Hello, Administrator";
                isAdmin = true;
                initializeKeyTab();
                initializeKeySetTab();
                initializeDoorGroupTab();
                initializePersonnelTab();
            }  

            else
            {
                lblAdmin.Text = "Hello User";
                tabControl.TabPages.Remove(tabPageKeysets);
                tabControl.TabPages.Remove(tabPageKeys);
                tabControl.TabPages.Remove(tabPageDoorgroups);
                tabControl.TabPages.Remove(tabPagePersonnel);
            }

            this.loginForm = lgnForm;
            initializeCheckoutTab();//Depends on admin value. Must be placed after it's determined. 
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
        * CHECKOUT TAB STUFF
        *********************************************/

        private void initializeCheckoutTab()
        {
            if(isAdmin == false)
            {                           
                groupBoxCheckoutsEditCheckout.Visible = false;
                groupBoxCheckoutViewCheckouts.Visible = false;
            } 

            listBoxCheckoutCheckouts.Items.Clear();

            //Populate listbox with current checkouts.
            FillCheckoutList();            
            
            //Populate personnel comboboxes. 
            listBoxCheckoutPersonnel.Items.Clear();
            foreach (Personnel person in objects.personnel)
            {
                comboBoxCheckoutPersonnelFilter.Items.Add(person.FirstName + ' ' + person.LastName);
                comboBoxCheckoutAddPersonnel.Items.Add(person.FirstName + ' ' + person.LastName);
            }

            //Populate keyring comboboxes.
            listBoxCheckoutKeyRing.Items.Clear();
            foreach (KeyRing ring in objects.keyrings)
            {
                comboBoxCheckoutKeyRingFilter.Items.Add(ring.Name);
                comboBoxCheckoutAddKeyRing.Items.Add(ring.Name);
                comboBoxCheckoutNewCheckout.Items.Add(ring.Name);
            }
        }

        private void FillCheckoutList()
        {
            listBoxCheckoutCheckouts.Items.Clear();
            foreach (Checkout checkout in objects.checkouts)
            {
                
                listBoxCheckoutCheckouts.Items.Add(checkout.Id);
            }
        }

        private void buttonCheckoutDeleteCheckout_Click(object sender, EventArgs e)
        {

            Checkout deleteCheckout = new Checkout();

            if(listBoxCheckoutCheckouts.SelectedIndex != -1)
            {
                //Remove selected checkout from listbox
                int selectedItem = (int)listBoxCheckoutCheckouts.SelectedItem;                         
                listBoxCheckoutCheckouts.Items.Remove(selectedItem);                

                //Remove selected checkout from Objects list
                foreach (Checkout checkout in objects.checkouts)
                {
                    if (checkout.Id == selectedItem)
                    {
                        deleteCheckout = checkout;   
                    }
                }

                objects.checkouts.Remove(deleteCheckout);

                //Delete selected checkout from Database.
                deleteCheckout.Delete();
                

            }   
      
            //TODO remove selected items from checkout object when implemented. 
        }

        private void buttonCheckoutAddCheckout_Click(object sender, EventArgs e)
        {
            listBoxCheckoutCheckouts.Items.Add(1);//Testing. 
            //TODO create dialog that will hold values for new checkout. 
        }

        private void comboBoxCheckoutNewCheckout_SelectedIndexChanged(object sender, EventArgs e)
        {                      
            
            //TODO 
        }

        private void buttonCheckoutNewCheckout_Click(object sender, EventArgs e)
        {                       
            
            if (comboBoxCheckoutNewCheckout.SelectedIndex != -1)
            {
                Checkout checkout = new Checkout();
                checkout.Id = -1;
                checkout.Person = objects.personnel.ElementAt(0);//Takes first record in personnel table - STUB.            

                foreach (KeyRing keyring in objects.keyrings)
                {
                    if (keyring.Name == (string)comboBoxCheckoutNewCheckout.SelectedItem)
                    {
                        checkout.KeyRing = objects.getKeyRingByName((string)comboBoxCheckoutNewCheckout.SelectedItem);
                    }
                }

                objects.checkouts.Add(checkout);
                checkout.Save();                
                MessageBox.Show("New checkout generated.", "New Checkout Generated");
            }

            else
            {
                MessageBox.Show("Must select Key Ring to generate checkout", "Select Key Ring");
            }

            FillCheckoutList();

           
        }
            
        

        private void listBoxCheckoutCheckouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO populate listBoxCheckoutPersonnel and listBoxCheckoutKeyRing with values depending on currently selected checkout. 
        }

        private void comboBoxCheckoutPersonnelFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO change contents of listCheckoutCheckouts based on personnel selected. 
        }

        private void comboBoxCheckoutKeyRingFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO change contents of listCheckoutCheckouts based on keyring selected. 
        }

        private void buttonCheckoutRemoveFilters_Click(object sender, EventArgs e)
        {

        }

        private void listBoxCheckoutPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCheckoutAddPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCheckoutAddPersonnel_Click(object sender, EventArgs e)
        {
            if (comboBoxCheckoutAddPersonnel.SelectedIndex != -1)
            {
                if (listBoxCheckoutPersonnel.FindString(comboBoxCheckoutAddPersonnel.SelectedItem.ToString(), -1) == -1)
                {
                    listBoxCheckoutPersonnel.Items.Add(comboBoxCheckoutAddPersonnel.SelectedItem);
                }

                else
                {
                    MessageBox.Show("Selected personnel already in checkout", "Selection Error");
                }

            }

            else
            {
                MessageBox.Show("Must select Personnel to add", "Select Personnel");
            }   
        }

        private void listBoxCheckoutKeyRing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCheckoutAddKeyRing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCheckoutAddKeyRing_Click(object sender, EventArgs e)
        {
            
            //If a value is selected from the combo box, check it against the current items in the list. If it doesn't exist, add it. 
            if(comboBoxCheckoutAddKeyRing.SelectedIndex != -1)
            {
                if (listBoxCheckoutKeyRing.FindString(comboBoxCheckoutAddKeyRing.SelectedItem.ToString(), -1) == -1)
                {
                    listBoxCheckoutKeyRing.Items.Add(comboBoxCheckoutAddKeyRing.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Selected keyring already in checkout", "Selection Error");
                }
                    
            }

            else
            {
                 MessageBox.Show("Must select Key Ring to add", "Select Key Ring");
            }                  
        }

        private void buttonCheckoutSaveChanges_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckoutEditCheckout_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckoutRemovePersonnel_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCheckoutRemoveKeyRing_Click(object sender, EventArgs e)
        {

        }

        /*********************************************
        * KEYSET TAB STUFF
        *********************************************/
        
        private void initializeKeySetTab()
        {
            groupBoxKeysetManage.Enabled = false;
            listBoxKeysets.Items.Clear();
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
            if (ring.keys != null)
            {
                foreach (Key key in ring.keys)
                {
                    line = key.Serial + " (" + key.KeyType.Name + ")";
                    listBoxKeysInKeyset.Items.Add(line);
                }
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
            // use a dialog to create a new keyset
            KeysetDialog ksd = new KeysetDialog();
            if (ksd.ShowDialog() == DialogResult.OK)
            {
                // update the OOP - for now OOP only!
                KeyRing ring = ksd.ring;
                ring.Save();
                objects.keyrings.Add(ring);
                // redisplay
                initializeKeySetTab();
                listBoxKeysets.SelectedItem = ring.Name;
            }
            ksd.Close();
        }

        private void buttonKeysetEdit_Click(object sender, EventArgs e)
        {
            // open a dialog to change the name or other details
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            KeysetDialog ksd = new KeysetDialog(ring);
            if (ksd.ShowDialog() == DialogResult.OK)
            {
                // update the keyset - for now OOP only!
                ring.Name = ksd.ring.Name;
                ring.Save();
                // redisplay
                initializeKeySetTab();
                listBoxKeysets.SelectedItem = ring.Name;
            }
            ksd.Close();
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
            KeyRing ring = objects.getKeyRingByName(labelKeysetTitle.Text);

            // remove all keys.
            foreach (Key key in objects.keys)
            {
                ring.RemoveKey(key);
            }
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



        /*********************************************
        * KEY/KEYTYPE TAB STUFF
        *********************************************/

        private void initializeKeyTab()
        {
            groupBoxKeyManage.Enabled = false;
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
            groupBoxKeyManage.Enabled = true;
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

        /*********************************************
        * DOOR GROUP TAB STUFF
        *********************************************/

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
                    loc.doors.Remove(door);

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
                    loc.doors.Add(door);

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
                // update the OOP - for now OOP only!
                Location loc = dgd.location;
                objects.locations.Add(loc);
                // redisplay
                initializeDoorGroupTab();
                listBoxDoorGroupTabGroups.SelectedItem = loc.Name;
            }
            dgd.Close();
        }

        private void buttonDoorGroupTabEditGroup_Click(object sender, EventArgs e)
        {
            // open a dialog to change the name or other details
            foreach (Location loc in objects.locations)
            {
                if (loc.Name == (string)listBoxDoorGroupTabGroups.SelectedItem)
                {
                    DoorGroupDialog dgd = new DoorGroupDialog(loc);
                    if (dgd.ShowDialog() == DialogResult.OK)
                    {
                        // update the Door Group - for now OOP only!
                        loc.Name = dgd.location.Name;
                        // redisplay
                        initializeDoorGroupTab();
                        listBoxKeysets.SelectedItem = loc.Name;
                    }
                    dgd.Close();
                }
            }

            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            KeysetDialog ksd = new KeysetDialog(ring);
            if (ksd.ShowDialog() == DialogResult.OK)
            {
                // update the keyset - for now OOP only!
                ring.Name = ksd.ring.Name;
                // redisplay
                initializeKeySetTab();
                listBoxKeysets.SelectedItem = ring.Name;
            }
            ksd.Close();
        }

        /*********************************************
        * PERSONNEL TAB
        *********************************************/

        /// <summary>
        /// Setup Personnel Tab
        ///     - Fill list box with all Personnel
        /// </summary>
        public void initializePersonnelTab()
        {
            refreshPersonnelList();
        }

        public void refreshPersonnelList()
        {
            // load list of all personnel
            listBoxPersonnel.Items.Clear();
            foreach (Personnel person in objects.personnel)
            {
                listBoxPersonnel.Items.Add(person.FirstName + " " + person.LastName);
            }
        }

        /// <summary>
        /// Perform Search
        ///     - on keystroke, compare input to users first and last name ignoring case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            String[] terms = tbSearch.Text.Split(' ');
            List<Personnel> matchedPersonnel = new List<Personnel>(); 

            // TODO - Fun fuzzy searching

            foreach (Personnel person in objects.personnel)
            {
                foreach (String term in terms)
                {
                    if (person.FirstName.ToLower().Contains(term.ToLower()) || person.LastName.ToLower().Contains(term.ToLower()))
                        matchedPersonnel.Add(person);
                }
            }

            // populate results
            listBoxPersonnel.Items.Clear();
            foreach (Personnel person in matchedPersonnel)
            {
                listBoxPersonnel.Items.Add(person.FirstName + " " + person.LastName);
            }
        }

        /// <summary>
        /// Select person from listbox
        ///     - populate detailed information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO - better way to determined selected user?
            String[] name = listBoxPersonnel.SelectedItem.ToString().Split(' ');
            foreach (Personnel person in objects.personnel)
            {
                if (person.FirstName.Equals(name[0]) && person.LastName.Equals(name[1]))
                {
                    tbFirstName.Text = person.FirstName;
                    tbLastName.Text = person.LastName;
                    tbUsername.Text = person.UserName;
                    if (person.IsAdmin)
                        cbAccountType.SelectedIndex = 1;
                    else
                        cbAccountType.SelectedIndex = 0;
                }                   
            }
        }

        /// <summary>
        /// Toggle edit form for user details
        /// </summary>
        public void toggleDetailsEditing()
        {
            if (tbUsername.Enabled)
            {
                // On Save - Disable Form
                tbUsername.Enabled = false;
                tbFirstName.Enabled = false;
                tbLastName.Enabled = false;
                cbAccountType.Enabled = false;
                btnEditUser.Text = "Edit";

                SaveUserDetails();
            }
            else
            {
                // On Edit - Enable Form
                tbUsername.Enabled = true;
                tbFirstName.Enabled = true;
                tbLastName.Enabled = true;
                cbAccountType.Enabled = true;
                btnEditUser.Text = "Save";
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            toggleDetailsEditing();
        }

        public void SaveUserDetails()
        {
            // TODO - better way to determined selected user?            
            String[] name = listBoxPersonnel.SelectedItem.ToString().Split(' ');
            foreach (Personnel person in objects.personnel)
            {
                if (person.FirstName.Equals(name[0]) && person.LastName.Equals(name[1]))
                {
                    person.FirstName = tbFirstName.Text;
                    person.LastName = tbLastName.Text;
                    person.UserName = tbUsername.Text;
                    if (cbAccountType.SelectedIndex == 1)
                        person.IsAdmin = true;
                    else
                        person.IsAdmin = false;
                }
            }
            refreshPersonnelList();
        }

        /// <summary>
        /// Create a New User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Personnel newPerson = new Personnel();
            objects.personnel.Add(newPerson);
            listBoxPersonnel.Items.Add(newPerson.FirstName + " " + newPerson.LastName);
            listBoxPersonnel.SelectedIndex = listBoxPersonnel.Items.Count - 1;
            toggleDetailsEditing();
            tbFirstName.Focus();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pbFloorPlan_Click(object sender, EventArgs e)
        {

        }

        private void pbFloorPlan_MouseMove(object sender, MouseEventArgs e)
        {
            Console.Out.WriteLine(e.X + " " + e.Y);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxCheckoutRegularUser_Enter(object sender, EventArgs e)
        {

        }
    }
}
