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

namespace KeyManagerForm
{
    public partial class KeyDialog : Form
    {
        private ObjectHolder objects;
        public Key key;

        public KeyDialog(ObjectHolder objects, Key ky = null)
        {
            InitializeComponent();
            this.objects = objects;
            this.key = ky;
            foreach (KeyType type in objects.keytypes)
            {
                comboBoxType.Items.Add(type.Name);
            }
            if (key == null)
            {
                key = new Key(-1, "", false, false);
                this.Text = "New Key Copy";
            }
            else
            {
                textBoxSerial.Text = key.Serial;
                checkBoxBroken.Checked = key.Broken;
                checkBoxMissing.Checked = key.Missing;
                comboBoxType.SelectedItem = key.KeyType.Name;
            }
            buttonSave.Enabled = false;
        }

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            
        }

        private void checkBoxBroken_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void checkBoxMissing_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxSerial.Text == "")
            {
                MessageBox.Show("The identifier cannot be blank", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a type for the key", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                key.Serial = textBoxSerial.Text;
                key.Broken = checkBoxBroken.Checked;
                key.Missing = checkBoxMissing.Checked;
                foreach (KeyType type in objects.keytypes)
                {
                    if (type.Name == (string)comboBoxType.SelectedItem)
                    {
                        key.KeyType = type;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
