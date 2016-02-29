using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
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

            SetupList();
            PopulateListKeys("");
            lblTitle.Focus();
            
        }

        public void SetupList()
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
        }

        public void PopulateListKeys(String searchString)
        {
            listKeys.Items.Clear();

            bool doSearch = false;
            if (searchString.Length > 0)
                doSearch = true;

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

                String[] args = { key.Serial, key.KeyType.Name, ring, " ", doors };

                if (doSearch)
                {
                    if (DoSearch(searchString, args))
                    {
                        // add key to list
                        ListViewItem row = new ListViewItem(args);
                        if (count % 2 == 0)
                            row.BackColor = lightBlue;
                        else
                            row.BackColor = evenLighterBlue;
                        count++;
                        listKeys.Items.Add(row);
                    }
                }
                else
                {
                    // add key to list
                    ListViewItem row = new ListViewItem(args);
                    if (count % 2 == 0)
                        row.BackColor = lightBlue;
                    else
                        row.BackColor = evenLighterBlue;
                    count++;
                    listKeys.Items.Add(row);
                }
            }
        }      

        public bool DoSearch(String searchString, String[] args)
        {
            String[] terms = searchString.Split(' ');
            String simpifiedArgs = "";
            for (int i = 0;i<args.Length;i++)
            {
                if (i==0)
                    simpifiedArgs = args[i];
                else
                    simpifiedArgs = simpifiedArgs + " " + args[i];
            }
            String[] keyValues = simpifiedArgs.Split(' ');

            foreach (String term in terms)
            {
                foreach (String val in keyValues)
                {
                    if (val.ToLower().Contains(term.ToLower()))
                        return true;
                }
            }

            return false;
        }

        private void NewLookupForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PopulateListKeys(tbSearch.Text);
        }

        private void listKeys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listKeys_ColumnClick(object sender, ColumnClickEventArgs e)
        {
           
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
                       
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
                     
        }
    }
}
