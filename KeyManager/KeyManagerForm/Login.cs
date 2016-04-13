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
using System.Data.SQLite;

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

            DbSetupManager.CheckDBFolder(); // verifies db exits, creates if not.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;
            int userId = GetUserID(username, password);
            if (userId != -1)
            {
                parentForm = new MDI_ParentForm(this, userId);
                parentForm.Show();
                this.Hide();
            }
            else
            {
                lblIncorrect.Visible = true;
            }
        }

        private int GetUserID(string username, string password)
        {
            KeyManagerHelper.Hash hasher = new KeyManagerHelper.Hash();
            string hashed = hasher.getHash(password);
            SQLiteConnection conn = DbSetupManager.GetConnection();
            
            SQLiteCommand command = new SQLiteCommand("SELECT ID FROM personnel WHERE Username=@username AND password=@hashed", conn);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("hashed", hashed);

            SQLiteDataReader reader = command.ExecuteReader();
            int retId = -1; // represents not found
            if (reader.Read())
            {
                retId = reader.GetInt16(0);
            }
            conn.Close();
            return retId;
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
