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
    //NOTE TO SELF: BRAND-NEW FORM, GET TO WORK! ;)
    public partial class NewKeyringForm : Form
    {
        private ObjectHolder objects;

        // some ui constants
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Color dimTextColor = Color.FromArgb(130, 130, 130);
        Font normalFont = new Font("sans-serif", 8.5f);
        Font bitBiggerFont = new Font("sans-serif", 11);

        string ringHint =
            "Expand (click the '+') to see keys in each ring.\n" +
            "Double-click to remove a key from a ring.";
        string keyHint =
            "Keys are grouped by type, and keys already in a\n" +
            "key ring are greyed out (hover to see which ring\n" +
            "they are in). Drag onto a key ring to add that key.";

        public NewKeyringForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            PopulateKeyRings();
            PopulateKeys();
        }

        private void PopulateKeyRings()
        {
            treeViewRings.Nodes.Clear();
            TreeNode ringNode, keyNode;
            bool isOdd = true;
            foreach (KeyRing ring in objects.keyrings)
            {
                ringNode = treeViewRings.Nodes.Add(ring.Name);
                ringNode.Tag = ring;
                ringNode.BackColor = isOdd ? lightBlue : Color.White;
                isOdd = !isOdd;
                foreach (Key key in ring.keys)
                {
                    keyNode = ringNode.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    keyNode.NodeFont = normalFont;
                    keyNode.BackColor = evenLighterBlue;
                }
            }
        }

        private void PopulateKeys()
        {
            // populate categorized by keytype
            treeViewKeys.Nodes.Clear();
            TreeNode typeNode, keyNode;
            bool isOdd = true;
            foreach (KeyType type in objects.keytypes)
            {
                typeNode = treeViewKeys.Nodes.Add(type.Name);
                typeNode.Tag = type;
                typeNode.BackColor = isOdd ? lightBlue : Color.White;
                isOdd = !isOdd;
                foreach (Key key in type.keys)
                {
                    keyNode = typeNode.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    keyNode.NodeFont = normalFont;
                    keyNode.BackColor = evenLighterBlue;
                    if (key.KeyRing != null)
                    {
                        // already in a keyring
                        keyNode.ForeColor = dimTextColor;
                    }
                }
                typeNode.Expand();
            }
        }

        private void treeViewRings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonDelete.Enabled = (treeViewRings.SelectedNode != null && treeViewRings.SelectedNode.Level == 0);
            buttonRename.Enabled = (treeViewRings.SelectedNode != null && treeViewRings.SelectedNode.Level == 0);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // open a dialog to create
            KeysetDialog ksd = new KeysetDialog();
            DialogResult result = ksd.ShowDialog();
            if (result == DialogResult.OK)
            {
                // get the new ring from the dialog.
                KeyRing ring = ksd.ring;
                objects.keyrings.Add(ring);
                ring.Save();
                // now create the node in the ui
                bool isOdd = treeViewRings.Nodes.Count % 2 == 0;
                TreeNode newNode = treeViewRings.Nodes.Add(ring.Name);
                newNode.Tag = ring;
                newNode.BackColor = isOdd ? lightBlue : Color.White;
            }
            ksd.Dispose();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            // open a dialog to rename
            TreeNode node = treeViewRings.SelectedNode;
            KeyRing ring = (KeyRing)node.Tag;
            KeysetDialog ksd = new KeysetDialog(ring);
            DialogResult result = ksd.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ring modified in place, just save.
                ring.Save();
                node.Text = ring.Name;
            }
            ksd.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // verify the deletion
            TreeNode node = treeViewRings.SelectedNode;
            KeyRing ring = (KeyRing)node.Tag;
            DialogResult result = MessageBox.Show("Really delete keyring: " + ring.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                ring.Delete();
                objects.keyrings.Remove(ring);
                // now the ui
                treeViewRings.Nodes.Remove(node);
                bool isOdd = true;
                foreach (TreeNode nd in treeViewRings.Nodes)
                {
                    nd.BackColor = isOdd ? lightBlue : Color.White;
                    isOdd = !isOdd;
                }
                PopulateKeys();
            }
        }

        // initiate drag and drop from key view
        private void treeViewKeys_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewKeys.GetNodeAt(e.Location);
            // only drag a key that is not in a keyring already.
            if (nodeToDrag != null && nodeToDrag.Level == 1 && ((Key)nodeToDrag.Tag).KeyRing == null)
            {
                treeViewKeys.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // effect for drag-in
        private void treeViewRings_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // complete drag-drop into keyring
        private void treeViewRings_DragDrop(object sender, DragEventArgs e)
        {
            // check for some "do-not-proceed" conditions
            if (!e.Data.GetDataPresent(typeof(TreeNode))) { return; }
            Point dropLoc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeViewRings.GetNodeAt(dropLoc);
            if (targetNode == null) { return; }

            // make sure target is a keyring, not a key.
            if (targetNode.Level > 0) { targetNode = targetNode.Parent; }
            KeyRing ring = (KeyRing)targetNode.Tag;

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Key key = (Key)draggedNode.Tag;
            // add the key
            ring.AddKey(key);
            // update the ui
            draggedNode.ForeColor = dimTextColor;
            TreeNode newNode = targetNode.Nodes.Add(key.Serial);
            newNode.BackColor = evenLighterBlue;
            newNode.NodeFont = normalFont;
            targetNode.Expand();
        }

        private void treeViewRings_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1) // it is a key
            {
                Key key = (Key)e.Node.Tag;
                KeyRing ring = (KeyRing)e.Node.Parent.Tag;
                ring.RemoveKey(key);
                e.Node.Parent.Nodes.Remove(e.Node);
                PopulateKeys();
            }
            else if (e.Node.Level == 0) // it is a keyring
            {
                KeyRing ring = (KeyRing)e.Node.Tag;
                DialogResult result = MessageBox.Show("Remove all keys from the key ring: " + ring.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    foreach (Key key in ring.keys.ToArray())
                    {
                        ring.RemoveKey(key);
                    }
                    e.Node.Nodes.Clear();
                    PopulateKeys();
                }
            }
        }

        // tooltip and hint stuff
        private void buttonRingHint_MouseHover(object sender, EventArgs e)
        {
            toolTipRing.Show(ringHint, buttonRingHint);
        }

        private void buttonRingHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ringHint);
        }

        private void buttonKeyHint_MouseHover(object sender, EventArgs e)
        {
            toolTipRing.Show(keyHint, buttonKeyHint);
        }

        private void buttonKeyHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(keyHint);
        }

        private void treeViewRings_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                toolTipRing.Show("Double-click to remove key", treeViewRings);
            }
            else if (e.Node.IsExpanded)
            {
                toolTipRing.Show("Double-click to remove all keys", treeViewRings);
            }
            else
            {
                toolTipRing.Show("Expand to see keys in this ring", treeViewRings);
            }
        }

        private void treeViewKeys_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (((Key)e.Node.Tag).KeyRing == null)
                {
                    toolTipRing.Show("Drag onto a key ring to add", treeViewKeys);
                }
                else
                {
                    toolTipRing.Show("Already in key ring: " + ((Key)e.Node.Tag).KeyRing.Name, treeViewKeys);
                }
            }
        }
    }
}
