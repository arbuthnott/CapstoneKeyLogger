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
    public partial class Login : Form
    {
        //private MainForm mainForm;
        private MDI_ParentForm parentForm;

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;
            UserLogin userlogin = new UserLogin(username, password);
            if (userlogin.LogIn())
            {

                //mainForm = new MainForm(this, userlogin.IsAdmin);
                //mainForm.Show();
                parentForm = new MDI_ParentForm(this, userlogin.IsAdmin);
                parentForm.Show();
                this.Hide();
            }
            else
            {
                lblIncorrect.Visible = true;
            }
        }

        /// <summary>
        /// This method is activated by the Mainform when a user is logging out.
        /// Kills the Mainform and blanks the entered username and password.
        /// </summary>
        public void Logout()
        {
            // unset all the data
            lblIncorrect.Visible = false;
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbUsername.Focus();
            parentForm.Close();
            parentForm = null;
            this.Show();
        }
    }
}
