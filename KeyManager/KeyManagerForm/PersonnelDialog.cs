using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyManagerClassLib;
using KeyManagerHelper;

namespace KeyManagerForm
{
    public partial class PersonnelDialog : Form
    {
        public Personnel person;

        // setup for a new Personnel object
        public PersonnelDialog()
        {
            InitializeComponent();
            person = new Personnel();
            buttonDelete.Visible = false;

            comboBoxType.SelectedIndex = 0;
        }

        // setup to edit input person
        public PersonnelDialog(Personnel person)
        {
            InitializeComponent();
            this.person = person;

            this.Text = "Edit Personnel";
            labelTitle.Text = "Edit Personnel";
            labelSubtitle.Text = "Edit details as needed";
            buttonCreate.Text = "Update";
            labelPassword.Text = "Change Password:";

            textBoxFirst.Text = person.FirstName;
            textBoxLast.Text = person.LastName;
            if (person.UserName == null)
            {
                comboBoxType.SelectedIndex = 0;
            }
            else
            {
                comboBoxType.SelectedIndex = person.IsAdmin ? 2 : 1;
                textBoxUsername.Text = person.UserName;
            }
            buttonCreate.Enabled = false;
        }

        private bool Validate()
        {
            if (textBoxFirst.Text.Length < 1) { return false; }
            if (textBoxLast.Text.Length < 1) { return false; }
            if (comboBoxType.SelectedIndex != 0)
            {
                if (textBoxUsername.Text.Length < 1) { return false; }
                if (textBoxPasswordConfirm.Text != textBoxPassword.Text) { return false; }
                if (person.Id == -1 || person.UserName == null) // a new software user, password required
                {
                    if (textBoxPassword.Text.Length < 1) { return false; }
                }
            }

            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // update the person to match
            person.FirstName = textBoxFirst.Text;
            person.LastName = textBoxLast.Text;
            person.IsAdmin = comboBoxType.SelectedIndex == 2;
            person.UserName = textBoxUsername.Text.Length > 0 ? textBoxUsername.Text : null;
            if (groupBoxUser.Enabled)
            {
                person.Password = (new Hash()).getHash(textBoxPassword.Text);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxUser.Enabled = comboBoxType.SelectedIndex != 0;
            if (!groupBoxUser.Enabled)
            {
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
            buttonCreate.Enabled = Validate();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length == 0)
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.Enabled = false;
            }
            else
            {
                textBoxPasswordConfirm.Enabled = true;
            }
            buttonCreate.Enabled = Validate();
        }

        private void textBoxFirst_TextChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = Validate();
        }

        private void textBoxLast_TextChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = Validate();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = Validate();
        }

        private void textBoxPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = Validate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Really delete Personnel: " + person.FirstName + " " + person.LastName + "?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel
            );
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.No; // use to indicate person should be deleted
            }
        }
    }
}
