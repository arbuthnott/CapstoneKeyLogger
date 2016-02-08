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
        private Login loginForm;
        private bool loggingOut = false;

        public MainForm(Login lgnForm, bool admin)
        {
            InitializeComponent();
            if (admin)
                isAdmin = true;

            if (admin)
                lblAdmin.Text = "Hello, Administrator";
            else
                lblAdmin.Text = "Hello User";
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
    }
}
