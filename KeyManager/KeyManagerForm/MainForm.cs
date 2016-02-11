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

namespace KeyManagerForm
{
    public partial class MainForm : Form
    {
        private bool isAdmin = false;
        private Login loginForm;
        private bool loggingOut = false;

        public MainForm(Login lgnForm, bool admin)
        {
            InitializeComponent();
            if (admin)
            {
                isAdmin = true;
                // the following function uses stop-gap sql, and should be removed
                // once some OOP ways to do it are available.
                runTemporaryKeysetCode();
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

        private void runTemporaryKeysetCode()
        {
            groupBoxKeysetManage.Enabled = false;

            // populate the list of keysets.
            SQLiteConnection conn = DbSetupManager.GetConnection();
            String sql = "SELECT Name FROM keyring";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBoxKeysets.Items.Add(reader.GetString(0));
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
                }
            }
            groupBoxKeysetManage.Enabled = true;
            buttonSaveKeysetChanges.Enabled = false;
            labelKeysetTitle.Text = (String)listBoxKeysets.SelectedItem;
            // still need to list the keys in the set, and unassigned keys.
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
                buttonSaveKeysetChanges.Enabled = true;
            }
        }

        private void buttonRemoveKeysetKey_Click(object sender, EventArgs e)
        {
            // move the list items.
            if (listBoxKeysInKeyset.SelectedIndex != -1)
            {
                buttonSaveKeysetChanges.Enabled = true;
            }
        }

        private void buttonSaveKeysetChanges_Click(object sender, EventArgs e)
        {
            // apply new key assignments to the keyset.
        }

        /*********************************************
        * KEYSET TAB STUFF
        *********************************************/

        private void comboBoxDoorLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lookup the door data and populate the lists.
        }

        private void comboBoxKeytypeLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lookup the keytype data and populate the lists.
        }

        private void comboBoxKeyserialLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lookup the key data and populate the lists.
        }
    }
}
