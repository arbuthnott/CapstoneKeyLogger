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
    public partial class AddMapPointDialog : Form
    {
        ObjectHolder objects;
        public Door door;

        public AddMapPointDialog(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
        }

        private void AddMapPointDialog_Load(object sender, EventArgs e)
        {
            foreach (Door door in objects.doors)
            {
                cbDoors.Items.Add(door.RoomNumber);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbDoors.SelectedItem.ToString().Equals(""))
            {
                MessageBox.Show("Please select a door", "Select Door", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                foreach (Door door in objects.doors)
                {
                    if (cbDoors.SelectedItem.ToString().Equals(door.RoomNumber))
                        this.door = door;
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
