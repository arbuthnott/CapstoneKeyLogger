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
    public partial class DoorsForm : Form
    {
        ObjectHolder objects;

        public DoorsForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;
        }

        private void lbxKeysAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
