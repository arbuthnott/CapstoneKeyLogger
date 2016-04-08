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
    public partial class CheckoutForm : Form
    {
        private ObjectHolder objects;

        public CheckoutForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            PopulatePeople();
        }

        private void PopulatePeople()
        {
            treeViewPeople.BeginUpdate();


            Color lightBlue = Color.FromArgb(166, 227, 247);
            TreeNode node;
            bool isOdd = true;
            foreach (Personnel person in objects.personnel)
            {
                node = treeViewPeople.Nodes.Add(person.FirstName + " " + person.LastName);
                node.Tag = person; // so we can fetch data later
                
                if (isOdd) { node.BackColor = lightBlue; }
                isOdd = !isOdd;
            }

            treeViewPeople.EndUpdate();
        }
    }
}
