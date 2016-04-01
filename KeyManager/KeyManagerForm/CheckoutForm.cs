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

            SetUpPersonnel();
            PopulateList();
        }

        private void SetUpPersonnel()
        {
            listPeople.View = View.Details;
            listPeople.GridLines = true;
            listPeople.FullRowSelect = true;

            listPeople.Columns.Add("Personnel", 80);
            listPeople.Columns.Add("Date", 80);
            listPeople.Columns.Add("Key Rings", 100);
            listPeople.Columns.Add("Loose Keys", 100);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            listPeople.SmallImageList = imgList;
        }

        private void PopulateList()
        {
            ListViewItem item;
            String nameStr, keyringStr, keyStr, dateStr;
            DateTime date;
            List<Key> checkedKeys = new List<Key>();
            List<KeyRing> checkedRings = new List<KeyRing>();
            foreach (Personnel person in objects.personnel)
            {
                nameStr = person.FirstName + " " + person.LastName;
                keyringStr = "";
                keyStr = "";
                dateStr = "";
                date = new DateTime();
                checkedKeys.Clear();
                checkedRings.Clear();
                foreach (Checkout checkout in objects.checkouts)
                {
                    if (checkout.Person == person && !checkout.IsReturned)
                    {
                        if (dateStr == "" || checkout.Date < date)
                        {
                            date = checkout.Date;
                            dateStr = date.ToShortDateString();
                        }
                        
                        if (checkout.Key != null)
                        {
                            checkedKeys.Add(checkout.Key);
                            keyStr += checkout.Key.Serial + ", ";
                        }
                        if (checkout.KeyRing != null)
                        {
                            checkedRings.Add(checkout.KeyRing);
                            keyringStr += checkout.KeyRing.Name + ", ";
                        }
                    }
                }
                // remove the last commas
                if (keyStr.Length > 0)
                {
                    keyStr = keyStr.Substring(0, keyStr.Length - 2);
                }
                if (keyringStr.Length > 0)
                {
                    keyringStr = keyringStr.Substring(0, keyringStr.Length - 2);
                }

                string[] args = { nameStr, dateStr, keyringStr, keyStr };
                item = new ListViewItem(args);

                listPeople.Items.Add(item);
            }
        }

        private void listPeople_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
