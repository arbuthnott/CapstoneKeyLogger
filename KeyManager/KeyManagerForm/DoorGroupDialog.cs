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
    public partial class DoorGroupDialog : Form
    {
        public Location location;

        public DoorGroupDialog(Location loc = null)
        {
            InitializeComponent();
            location = loc;

            if (location != null)
            {
                textBoxName.Text = location.Name;
            }
            else
            {
                Text = "New Door Group";
                location = new Location(-1, "", "");
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
                location.Name = textBoxName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
