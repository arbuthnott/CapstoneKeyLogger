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

                MainForm frm = new MainForm(userlogin.IsAdmin);
                frm.Show();
                
            }
            else
            {
                lblIncorrect.Visible = true;
            }

            //userlogin.LogOut();

            //password = "woops";
            //userlogin = new UserLogin(username, password);
            //Console.WriteLine("Trying a bad login: " + userlogin.LogIn());
            //userlogin.LogOut();
        }

        private void lblIncorrect_Click(object sender, EventArgs e)
        {

        }
    }
}
