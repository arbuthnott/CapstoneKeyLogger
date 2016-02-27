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
    public partial class PersonnelForm : Form
    {
        ObjectHolder objects;

        public PersonnelForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
            initializePersonnelTab();
        }

        /// <summary>
        /// Setup Personnel Tab
        ///     - Fill list box with all Personnel
        /// </summary>
        public void initializePersonnelTab()
        {
            refreshPersonnelList();
        }

        public void refreshPersonnelList()
        {
            // load list of all personnel
            listBoxPersonnel.Items.Clear();
            foreach (Personnel person in objects.personnel)
            {
                listBoxPersonnel.Items.Add(person.FirstName + " " + person.LastName);
            }
        }

        /// <summary>
        /// Perform Search
        ///     - on keystroke, compare input to users first and last name ignoring case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            String[] terms = tbSearch.Text.Split(' ');
            List<Personnel> matchedPersonnel = new List<Personnel>();

            // TODO - Fun fuzzy searching

            foreach (Personnel person in objects.personnel)
            {
                foreach (String term in terms)
                {
                    if (person.FirstName.ToLower().Contains(term.ToLower()) || person.LastName.ToLower().Contains(term.ToLower()))
                        matchedPersonnel.Add(person);
                }
            }

            // populate results
            listBoxPersonnel.Items.Clear();
            foreach (Personnel person in matchedPersonnel)
            {
                listBoxPersonnel.Items.Add(person.FirstName + " " + person.LastName);
            }
        }

        /// <summary>
        /// Select person from listbox
        ///     - populate detailed information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO - better way to determined selected user?
            String[] name = listBoxPersonnel.SelectedItem.ToString().Split(' ');
            foreach (Personnel person in objects.personnel)
            {
                if (person.FirstName.Equals(name[0]) && person.LastName.Equals(name[1]))
                {
                    tbFirstName.Text = person.FirstName;
                    tbLastName.Text = person.LastName;
                    tbUsername.Text = person.UserName;
                    if (person.IsAdmin)
                        cbAccountType.SelectedIndex = 1;
                    else
                        cbAccountType.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Toggle edit form for user details
        /// </summary>
        public void toggleDetailsEditing()
        {
            if (tbUsername.Enabled)
            {
                // On Save - Disable Form
                tbUsername.Enabled = false;
                tbFirstName.Enabled = false;
                tbLastName.Enabled = false;
                cbAccountType.Enabled = false;
                btnEditUser.Text = "Edit";

                SaveUserDetails();
            }
            else
            {
                // On Edit - Enable Form
                tbUsername.Enabled = true;
                tbFirstName.Enabled = true;
                tbLastName.Enabled = true;
                cbAccountType.Enabled = true;
                btnEditUser.Text = "Save";
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            toggleDetailsEditing();
        }

        public void SaveUserDetails()
        {
            // TODO - better way to determined selected user?            
            String[] name = listBoxPersonnel.SelectedItem.ToString().Split(' ');
            foreach (Personnel person in objects.personnel)
            {
                if (person.FirstName.Equals(name[0]) && person.LastName.Equals(name[1]))
                {
                    person.FirstName = tbFirstName.Text;
                    person.LastName = tbLastName.Text;
                    person.UserName = tbUsername.Text;
                    if (cbAccountType.SelectedIndex == 1)
                        person.IsAdmin = true;
                    else
                        person.IsAdmin = false;
                }
            }
            refreshPersonnelList();
        }

        /// <summary>
        /// Create a New User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Personnel newPerson = new Personnel();
            objects.personnel.Add(newPerson);
            listBoxPersonnel.Items.Add(newPerson.FirstName + " " + newPerson.LastName);
            listBoxPersonnel.SelectedIndex = listBoxPersonnel.Items.Count - 1;
            toggleDetailsEditing();
            tbFirstName.Focus();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pbFloorPlan_Click(object sender, EventArgs e)
        {

        }

        private void pbFloorPlan_MouseMove(object sender, MouseEventArgs e)
        {
            Console.Out.WriteLine(e.X + " " + e.Y);
        }

        
    }
}
