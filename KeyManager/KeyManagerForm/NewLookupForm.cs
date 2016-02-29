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
    public partial class NewLookupForm : Form
    {
        private ObjectHolder objects;

        public NewLookupForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

 
            PopulateListKeys();
        }



        public void PopulateListKeys()
        {
            listKeys.View = View.Details;
            listKeys.GridLines = true;
            listKeys.FullRowSelect = true;

            listKeys.Columns.Add("Keys", 100);
            listKeys.Columns.Add("Type", 100);
            listKeys.Columns.Add("Ring", 100);
            listKeys.Columns.Add("Person", 150);
            listKeys.Columns.Add("Doors", 200);
            

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            listKeys.SmallImageList = imgList;

            Color lightBlue = Color.FromArgb(166, 227, 247);
            Color evenLighterBlue = Color.FromArgb(220, 241, 247);

            int count = 0;
            foreach (Key key in objects.keys)
            {
                // Get doors this key can open
                String doors = "";
                foreach (Door door in objects.doors)
                {
                    foreach (KeyType type in door.keytypes)
                    {
                        if (type.Name.Equals(key.KeyType.Name))
                            doors = doors + door.RoomNumber + ", ";
                    }
                }

                String ring = "Not Assigned";
                if (key.KeyRing != null)
                    ring = key.KeyRing.Name;

                String[] args = {key.Serial, key.KeyType.Name, ring, " ", doors};
                ListViewItem row = new ListViewItem(args);

                if (count % 2 == 0)
                    row.BackColor = lightBlue;
                else
                    row.BackColor = evenLighterBlue;
                count++;

                listKeys.Items.Add(row);
            }
        }

        private void NewLookupForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
