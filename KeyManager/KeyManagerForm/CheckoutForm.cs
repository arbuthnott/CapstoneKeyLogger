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

        // some ui constants
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Color dimTextColor = Color.FromArgb(130, 130, 130);
        Font normalFont = new Font("sans-serif", 8.5f);
        Font bitBiggerFont = new Font("sans-serif", 11);

        public CheckoutForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            PopulatePeople();
            PopulateRings();
            PopulateKeys();
        }

        private void PopulatePeople()
        {
            treeViewPeople.BeginUpdate();

            TreeNode node, ringNode, keyNode;
            bool isOdd = true;
            foreach (Personnel person in objects.personnel)
            {
                node = treeViewPeople.Nodes.Add(person.FirstName + " " + person.LastName);
                node.Tag = person; // so we can fetch data later
                
                // add the keyrings
                foreach(KeyRing ring in person.Keyrings)
                {
                    ringNode = node.Nodes.Add(ring.Name);
                    ringNode.Tag = ring;
                    foreach(Key key in ring.keys)
                    {
                        keyNode = ringNode.Nodes.Add(key.Serial);
                        keyNode.Tag = key;
                        keyNode.BackColor = evenLighterBlue;
                        keyNode.NodeFont = normalFont;
                    }
                    ringNode.BackColor = evenLighterBlue;
                    ringNode.NodeFont = normalFont;
                }

                // add the keys
                foreach (Key key in person.Keys)
                {
                    keyNode = node.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    keyNode.BackColor = evenLighterBlue;
                    keyNode.NodeFont = normalFont;
                }

                if (isOdd) { node.BackColor = lightBlue; }
                node.NodeFont = bitBiggerFont;
                isOdd = !isOdd;
            }

            treeViewPeople.EndUpdate();
        }

        private void PopulateRings()
        {
            treeViewRings.BeginUpdate();

            TreeNode ringNode, keyNode;
            bool isOdd = true;

            foreach (KeyRing ring in objects.keyrings)
            {
                ringNode = treeViewRings.Nodes.Add(ring.Name);
                ringNode.Tag = ring;
                foreach (Key key in ring.keys)
                {
                    keyNode = ringNode.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    keyNode.NodeFont = normalFont;
                    keyNode.BackColor = evenLighterBlue;
                }
                // if item is checked out then dim it.
                if (ring.checkout != null) { ringNode.ForeColor = dimTextColor; }

                if (isOdd) { ringNode.BackColor = lightBlue; }
                isOdd = !isOdd;
            }
            treeViewRings.EndUpdate();
        }

        private void PopulateKeys()
        {
            treeViewKeys.BeginUpdate();

            TreeNode keyNode;
            bool isOdd = true;

            foreach (Key key in objects.keys)
            {
                if (key.KeyRing == null) // only include loose keys
                {
                    keyNode = treeViewKeys.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    
                    // if item is checked out then dim it
                    if (key.checkout != null) { keyNode.ForeColor = dimTextColor; }

                    if (isOdd) { keyNode.BackColor = lightBlue; }
                    isOdd = !isOdd;
                }
            }

            treeViewKeys.EndUpdate();
        }
    }
}
