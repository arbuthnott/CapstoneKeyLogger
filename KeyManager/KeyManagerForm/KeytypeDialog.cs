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
    public partial class KeytypeDialog : Form
    {
        public KeyType keytype;

        public KeytypeDialog(KeyType type = null)
        {
            InitializeComponent();
            keytype = type;

            if (keytype != null)
            {
                textBoxName.Text = keytype.Name;
            }
            else
            {
                this.Text = "New Keytype";
                keytype = new KeyType(-1, "", 0);
            }
            buttonSave.Enabled = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Name cannot be blank", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                keytype.Name = textBoxName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
