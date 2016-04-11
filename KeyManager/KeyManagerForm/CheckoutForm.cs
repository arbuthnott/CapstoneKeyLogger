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

        string personnelHint = 
            "Expand (click the '+') to see keys and\n" +
            "key rings checked-out by each person.\n\n" +
            "Double-click a key or key ring to check-in\n" +
            "that item.";
        string keyringHint =
            "Greyed-out key rings are checked out (hover\n" +
            "to see who has them). Drag free key rings" +
            "onto a Person to check-out.";
        string keyHint =
            "Greyed-out keys are checked out (hover to\n" +
            "see who has them). Drag free keys onto a\n" +
            "Person to check-out.";

        public CheckoutForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            PopulatePeople();
            PopulateRings();
            PopulateKeys();
        }

        // populate with all personnel
        private void PopulatePeople()
        {
            treeViewPeople.BeginUpdate();
            treeViewPeople.Nodes.Clear();

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

        // populate with checked-in keyrings from objects
        private void PopulateRings()
        {
            treeViewRings.BeginUpdate();
            treeViewRings.Nodes.Clear();

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

        // populate with checked-in, loose keys from objects.
        private void PopulateKeys()
        {
            treeViewKeys.BeginUpdate();
            treeViewKeys.Nodes.Clear();

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

        // key list - initiate drag
        private void treeViewKeys_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewKeys.GetNodeAt(e.Location);
            // only drag if on a node that is not checked out already.
            if (nodeToDrag != null && ((Key)nodeToDrag.Tag).checkout == null)
            {
                treeViewKeys.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // keyring list - initiate drag
        private void treeViewRings_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewRings.GetNodeAt(e.Location);
            // only drag if on a keyring node that is not checked out.
            if (nodeToDrag != null && nodeToDrag.Level == 0 && ((KeyRing)nodeToDrag.Tag).checkout == null)
            {
                treeViewRings.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // personnel list - dragenter effect
        private void treeViewPeople_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // personnel list - conclude drag-in
        private void treeViewPeople_DragDrop(object sender, DragEventArgs e)
        {
            // check for some "do-not-proceed" conditions
            if (!e.Data.GetDataPresent(typeof(TreeNode))) { return; }
            Point dropLoc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeViewPeople.GetNodeAt(dropLoc);
            if (targetNode == null) { return; }

            // find the root node (the person) for the node dropped into
            while (targetNode.Level > 0) { targetNode = targetNode.Parent; }
            Personnel person = (Personnel)targetNode.Tag;

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            // check for key or keyring
            if (draggedNode.Tag.GetType() == typeof(Key))
            {
                Key draggedKey = (Key)draggedNode.Tag;
                // update OOP and database:
                Checkout chk = new Checkout(person, draggedKey);
                chk.Save();
                // do the ui manually for now.
                draggedNode.ForeColor = dimTextColor;
                TreeNode newNode = targetNode.Nodes.Add(draggedKey.Serial);
                newNode.Tag = draggedKey;
                newNode.BackColor = evenLighterBlue;
                newNode.NodeFont = normalFont;

                targetNode.Expand();
            }
            else if (draggedNode.Tag.GetType() == typeof(KeyRing))
            {
                KeyRing draggedRing = (KeyRing)draggedNode.Tag;
                // update OOP and database:
                Checkout chk = new Checkout(person, draggedRing);
                chk.Save();
                // do the ui manually for now.
                draggedNode.ForeColor = dimTextColor;
                TreeNode subNode, newNode = targetNode.Nodes.Add(draggedRing.Name);
                newNode.Tag = draggedRing;
                newNode.BackColor = evenLighterBlue;
                newNode.NodeFont = normalFont;
                foreach (Key key in draggedRing.keys)
                {
                    subNode = newNode.Nodes.Add(key.Serial);
                    subNode.Tag = key;
                    subNode.BackColor = evenLighterBlue;
                    subNode.NodeFont = normalFont;
                }

                targetNode.Expand();
            }            
        }

        // personnel list - check-in keys or keyrings
        private void treeViewPeople_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                // double clicked a person.
                Personnel person = (Personnel)e.Node.Tag;
                DialogResult result = MessageBox.Show(
                    "Has " + person.FirstName + " " + person.LastName + " returned all keys?",
                    "Check in All?",
                    MessageBoxButtons.OKCancel
                );
                if (result == DialogResult.OK)
                {
                    foreach(KeyRing ring in person.Keyrings.ToArray())
                    {
                        ring.checkout.Return();
                    }
                    foreach(Key key in person.Keys.ToArray())
                    {
                        key.checkout.Return();
                    }
                    PopulateKeys();
                    PopulatePeople();
                    PopulateRings();
                }
            }
            else if (e.Node.Level == 1 && e.Node.Tag.GetType() == typeof(Key))
            {
                // a loose key
                Key key = (Key)e.Node.Tag;
                Personnel person = (Personnel)e.Node.Parent.Tag;
                DialogResult result = MessageBox.Show(
                    "Has " + person.FirstName + " " + person.LastName + " returned Key " + key.Serial + "?",
                    "Check-in Key?",
                    MessageBoxButtons.OKCancel
                );

                if (result == DialogResult.OK)
                {
                    key.checkout.Return();
                    PopulateKeys();
                    PopulatePeople();
                }
            }
            else if (e.Node.Level == 1)
            {
                // a keyring
                KeyRing ring = (KeyRing)e.Node.Tag;
                Personnel person = (Personnel)e.Node.Parent.Tag;
                DialogResult result = MessageBox.Show(
                    "Has " + person.FirstName + " " + person.LastName + " returned Key Ring: " + ring.Name + "?",
                    "Check-in Key Ring?",
                    MessageBoxButtons.OKCancel
                );

                if (result == DialogResult.OK)
                {
                    ring.checkout.Return();
                    PopulateRings();
                    PopulatePeople();
                }
            }
            else
            {
                // a key from a keyring
                KeyRing ring = (KeyRing)e.Node.Parent.Tag;
                Personnel person = (Personnel)e.Node.Parent.Parent.Tag;
                DialogResult result = MessageBox.Show(
                    "Has " + person.FirstName + " " + person.LastName + " returned Key Ring: " + ring.Name + "?",
                    "Check-in Key Ring?",
                    MessageBoxButtons.OKCancel
                );

                if (result == DialogResult.OK)
                {
                    ring.checkout.Return();
                    PopulateRings();
                    PopulatePeople();
                }
            }
        }

        // tooltip for personnel
        private void treeViewPeople_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            toolTipCheckout.Hide(treeViewPeople);
            if (e.Node.Level == 0 && !e.Node.IsExpanded)
            {
                if (e.Node.Nodes.Count == 0)
                {
                    toolTipCheckout.Show("No keys currently checked out", treeViewPeople);
                }
                else
                {
                    toolTipCheckout.Show("Expand to see checked-out Keys and Key Rings", treeViewPeople);
                }
            }
            else if (e.Node.Level == 0)
            {
                toolTipCheckout.Show("Double click to check-in all Keys and Key Rings", treeViewPeople);
            }
            else if (e.Node.Level == 1)
            {
                toolTipCheckout.Show("Double click to check-in", treeViewPeople);
            }
        }

        // tooltip for keys
        private void treeViewKeys_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            toolTipCheckout.Hide(treeViewKeys);
            if (((Key)e.Node.Tag).checkout == null)
            {
                // this key is available
                toolTipCheckout.Show("Drag onto a Person to check-out key", treeViewKeys);
            }
            else
            {
                // key is already checked out
                Personnel person = ((Key)e.Node.Tag).checkout.Person;
                toolTipCheckout.Show("Checked out to " + person.FirstName + " " + person.LastName, treeViewKeys);
            }
        }

        // tooltip for keyrings
        private void treeViewRings_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node.Level == 0 && ((KeyRing)e.Node.Tag).checkout == null)
            {
                // this ring is available
                toolTipCheckout.Hide(treeViewRings);
                toolTipCheckout.Show("Drag onto a Person to check-out Key Ring", treeViewRings);
            }
            else if (e.Node.Level == 0)
            {
                // keyring already checked out
                toolTipCheckout.Hide(treeViewRings);
                Personnel person = ((KeyRing)e.Node.Tag).checkout.Person;
                toolTipCheckout.Show("Checked out to " + person.FirstName + " " + person.LastName, treeViewRings);
            }
        }

        // methods to show help messages / instructions
        private void buttonPersonnelHint_MouseHover(object sender, EventArgs e)
        {
            toolTipCheckout.Show(personnelHint, buttonPersonnelHint);
        }

        private void buttonPersonnelHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(personnelHint);
        }

        private void buttonKeyringHint_MouseHover(object sender, EventArgs e)
        {
            toolTipCheckout.Show(keyringHint, buttonKeyringHint);
        }

        private void buttonKeyringHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(keyringHint);
        }

        private void buttonKeyHint_MouseHover(object sender, EventArgs e)
        {
            toolTipCheckout.Show(keyHint, buttonKeyHint);
        }

        private void buttonKeyHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(keyHint);
        }
    }
}
