using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyManagerForm
{
    public partial class MainForm : Form
    {
        private bool isAdmin = false;

        public MainForm(bool admin)
        {
            InitializeComponent();
            if (admin)
                isAdmin = true;

            if (admin)
                lblAdmin.Text = "Hello, Administrator";
            else
                lblAdmin.Text = "Hello User";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // logout functionality here!!
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // logout functionality here!!
        }
    }
}
