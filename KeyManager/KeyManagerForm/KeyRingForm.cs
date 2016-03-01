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
    public partial class KeyRingForm : Form
    {
        ObjectHolder objects;

        public KeyRingForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            initializeKeySetTab();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

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
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            if (ring != null)
            {
                groupBoxKeysetManage.Enabled = true;
                buttonSaveKeysetChanges.Enabled = false;
                labelKeysetTitle.Text = (String)listBoxKeysets.SelectedItem;

                String line;
                if (ring.keys != null)
                {
                    // populate keys in this keyring
                    listBoxKeysInKeyset.Items.Clear();
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

        private void listBoxKeysInKeyset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKeysNotInKeyset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
