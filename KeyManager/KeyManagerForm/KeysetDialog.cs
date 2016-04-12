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
    public partial class KeysetDialog : Form
    {
        public KeyRing ring;

        public KeysetDialog(KeyRing rng = null)
        {
            InitializeComponent();
            ring = rng;

            if (ring != null)
            {
                textBoxName.Text = ring.Name;
            }
            else
            {
                Text = "New Key Ring";
                ring = new KeyRing(-1, "");
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
                MessageBox.Show("The name cannot be blank", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ring.Name = textBoxName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
