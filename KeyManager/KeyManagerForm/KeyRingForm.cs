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

        private void initializeKeySetTab()
        {
            groupBoxKeysetManage.Enabled = false;
            listBoxKeysets.Items.Clear();
            foreach (KeyRing ring in objects.keyrings)
            {
                listBoxKeysets.Items.Add(ring.Name);
            }
            buttonAddKeysetKey.Enabled = false;
            buttonRemoveKeysetKey.Enabled = false;
        }

        private void listBoxKeysets_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxKeysInKeyset.SelectedIndex = -1;
            listBoxKeysNotInKeyset.SelectedIndex = -1;

            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            if (ring != null)
            {
                groupBoxKeysetManage.Enabled = true;
                //buttonSaveKeysetChanges.Enabled = false;
                labelKeysetTitle.Text = (String)listBoxKeysets.SelectedItem;

                if (ring.keys != null)
                {
                    // populate keys in this keyring
                    listBoxKeysInKeyset.Items.Clear();
                    foreach (Key key in ring.keys)
                    {
                        listBoxKeysInKeyset.Items.Add(key.Serial);
                    }
                }

                // populate keys available
                listBoxKeysNotInKeyset.Items.Clear();
                foreach (Key key in objects.keys)
                {
                    if (key.KeyRing == null)
                    {
                        listBoxKeysNotInKeyset.Items.Add(key.Serial);
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
                // update the OOP and the database
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
                // update the oop and the db
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
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            Key key = objects.getKeyBySerial((string)listBoxKeysNotInKeyset.SelectedItem);
            if (ring != null && key != null)
            {
                // the following updates the oop and the database
                ring.AddKey(key);

                // update the ui
                listBoxKeysNotInKeyset.Items.Remove(key.Serial);
                listBoxKeysInKeyset.Items.Add(key.Serial);
            }
        }

        private void buttonRemoveKeysetKey_Click(object sender, EventArgs e)
        {
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            Key key = objects.getKeyBySerial((string)listBoxKeysInKeyset.SelectedItem);
            if (ring != null && key != null)
            {
                // the following up dates the oop and the database
                ring.RemoveKey(key);

                // update the ui
                listBoxKeysNotInKeyset.Items.Add(key.Serial);
                listBoxKeysInKeyset.Items.Remove(key.Serial);
            }
        }

        private void listBoxKeysInKeyset_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveKeysetKey.Enabled = (listBoxKeysInKeyset.SelectedIndex != -1);
        }

        private void listBoxKeysNotInKeyset_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddKeysetKey.Enabled = (listBoxKeysNotInKeyset.SelectedIndex != -1);
        }

        private void buttonKeysetDelete_Click(object sender, EventArgs e)
        {
            KeyRing ring = objects.getKeyRingByName((string)listBoxKeysets.SelectedItem);
            DialogResult result = MessageBox.Show("Confirm Delete", "Really delete Key Ring " + ring.Name + "?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                ring.Delete();
                objects.keyrings.Remove(ring);
            }
            initializeKeySetTab();
        }
    }
}
