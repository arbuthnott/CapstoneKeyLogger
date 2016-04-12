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
    public partial class DoorDialog : Form
    {
        private ObjectHolder objects;
        private MDI_ParentForm parent;
        public Door door;

        // some ui constants
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Color dimTextColor = Color.FromArgb(130, 130, 130);
        Font normalFont = new Font("sans-serif", 8.5f);
        Font bitBiggerFont = new Font("sans-serif", 11);

        string unlockingHint =
            "These are the keys that unlock this door.\n" +
            "You can drag in or out from the other list\n" +
            "to update.";
        string keyHint =
            "These are the keys that do not unlock this\n" +
            "door. You can drag in or out from the other\n" +
            "list to update.";
        string lockHint =
            "Only use this if the door's lock is identical to\n" +
            "another door's lock. This will make updates to\n" +
            "one door affect all others with the same lock.";

        // Constructor to setup for a new door.
        public DoorDialog(ObjectHolder objects, MDI_ParentForm parent)
        {
            InitializeComponent();
            this.objects = objects;
            this.parent = parent;

            this.door = new Door();

            buttonDelete.Visible = false;
            buttonMap.Visible = false;
            PopulateKeyTree();
            PopulateComboBox();
        }

        // Constructor to edit an existing door
        public DoorDialog(ObjectHolder objects, MDI_ParentForm parent, Door door)
        {
            InitializeComponent();
            this.objects = objects;
            this.parent = parent;

            this.door = door;
            textBoxRoom.Text = door.RoomNumber;
            labelTitle.Text = "Edit Door";
            this.Text = "Edit Door";
            buttonCreate.Text = "Update";

            PopulateKeyTree();
            PopulateUnlockingTree();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            comboBoxLock.Items.Clear();
            List<Door> source = new List<Door>();
            source.Add(new Door(-1, "Not Applicable", -1, "image"));
            source.AddRange(objects.doors);
            comboBoxLock.DataSource = source;
            comboBoxLock.DisplayMember = "RoomNumber";
            comboBoxLock.SelectedIndex = 0;
        }

        private void PopulateKeyTree()
        {
            treeViewKeys.Nodes.Clear();
            TreeNode typeNode, keyNode;
            bool isOdd = true;
            foreach (KeyType type in objects.keytypes)
            {
                if (!door.keytypes.Contains(type))
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
                    }
                }
            }
        }

        private void PopulateUnlockingTree()
        {
            treeViewUnlocking.Nodes.Clear();
            TreeNode typeNode, keyNode;
            bool isOdd = true;
            foreach (KeyType type in door.keytypes)
            {
                typeNode = treeViewUnlocking.Nodes.Add(type.Name);
                typeNode.Tag = type;
                typeNode.BackColor = isOdd ? lightBlue : Color.White;
                isOdd = !isOdd;
                foreach (Key key in type.keys)
                {
                    keyNode = typeNode.Nodes.Add(key.Serial);
                    keyNode.Tag = key;
                    keyNode.NodeFont = normalFont;
                    keyNode.BackColor = evenLighterBlue;
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // update the door first!
            door.RoomNumber = textBoxRoom.Text;
            if (comboBoxLock.SelectedIndex > 0)
            {
                door.LockId = ((Door)comboBoxLock.SelectedItem).LockId;
                door.keytypes.Clear();
                door.keytypes.AddRange(((Door)comboBoxLock.SelectedItem).keytypes);
            }
            else
            {
                door.keytypes.Clear();
                foreach(TreeNode node in treeViewUnlocking.Nodes)
                {
                    door.keytypes.Add((KeyType)node.Tag);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Really delete Door: " + door.RoomNumber + "?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel
            );
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.No; // use to indicate person should be deleted
            }
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void textBoxRoom_TextChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = textBoxRoom.Text.Length > 0;
        }

        // initiate drag from keys
        private void treeViewKeys_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewKeys.GetNodeAt(e.Location);
            // only drag if at top (keytype) level.
            if (nodeToDrag != null && nodeToDrag.Level == 0)
            {
                treeViewKeys.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // drag-in visual effect for unlocking
        private void treeViewUnlocking_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (!treeViewUnlocking.Nodes.Contains(draggedNode))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        // complete drag into unlocking keys
        private void treeViewUnlocking_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (!treeViewUnlocking.Nodes.Contains(draggedNode))
                {
                    KeyType type = (KeyType)draggedNode.Tag;

                    // only modify the ui for now - data only on confirm.
                    treeViewKeys.Nodes.Remove(draggedNode);
                    bool isOdd = true;
                    foreach (TreeNode node in treeViewKeys.Nodes)
                    {
                        node.BackColor = isOdd ? lightBlue : Color.White;
                        isOdd = !isOdd;
                    }

                    isOdd = treeViewUnlocking.Nodes.Count % 2 == 0;
                    treeViewUnlocking.Nodes.Add(draggedNode);
                    draggedNode.BackColor = isOdd ? lightBlue : Color.White;

                    buttonCreate.Enabled = textBoxRoom.Text.Length > 0;
                }
            }
        }

        // initiate drag from unlocking keys
        private void treeViewUnlocking_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewUnlocking.GetNodeAt(e.Location);
            // only drag if at top (keytype) level.
            if (nodeToDrag != null && nodeToDrag.Level == 0)
            {
                treeViewUnlocking.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // drag in effect for keys
        private void treeViewKeys_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (!treeViewKeys.Nodes.Contains(draggedNode))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        // complete drag-drop into keys
        private void treeViewKeys_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (!treeViewKeys.Nodes.Contains(draggedNode))
                {
                    KeyType type = (KeyType)draggedNode.Tag;

                    // only modify the ui for now - data only on confirm.
                    treeViewUnlocking.Nodes.Remove(draggedNode);
                    bool isOdd = true;
                    foreach (TreeNode node in treeViewUnlocking.Nodes)
                    {
                        node.BackColor = isOdd ? lightBlue : Color.White;
                        isOdd = !isOdd;
                    }

                    isOdd = treeViewKeys.Nodes.Count % 2 == 0;
                    treeViewKeys.Nodes.Add(draggedNode);
                    draggedNode.BackColor = isOdd ? lightBlue : Color.White;

                    buttonCreate.Enabled = textBoxRoom.Text.Length > 0;
                }
            }
        }

        private void comboBoxLock_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = textBoxRoom.Text.Length > 0;
            Door comboDoor = (Door)comboBoxLock.SelectedItem;
            if (comboDoor.Id == -1)
            {
                // reset the unlocking keys
                if (door.Id == -1)
                {
                    // this is a new door
                    PopulateKeyTree();
                    treeViewUnlocking.Nodes.Clear();
                }
                else
                {
                    // existing door
                    PopulateKeyTree();
                    PopulateUnlockingTree();
                }
            }
            else
            {
                // repopulate the two lists.
                TreeNode typeNode, keyNode;
                bool oddUnlock = true, oddKey = true;
                treeViewUnlocking.Nodes.Clear();
                treeViewKeys.Nodes.Clear();

                foreach (KeyType type in objects.keytypes)
                {
                    if (comboDoor.keytypes.Contains(type))
                    {
                        // in the unlocking list
                        typeNode = treeViewUnlocking.Nodes.Add(type.Name);
                        typeNode.BackColor = oddUnlock ? lightBlue : Color.White;
                        oddUnlock = !oddUnlock;
                        foreach (Key key in type.keys)
                        {
                            keyNode = typeNode.Nodes.Add(key.Serial);
                            keyNode.Tag = key;
                            keyNode.NodeFont = normalFont;
                            keyNode.BackColor = evenLighterBlue;
                        }
                    }
                    else
                    {
                        // in the key list
                        typeNode = treeViewKeys.Nodes.Add(type.Name);
                        typeNode.BackColor = oddKey ? lightBlue : Color.White;
                        oddKey = !oddKey;
                        foreach (Key key in type.keys)
                        {
                            keyNode = typeNode.Nodes.Add(key.Serial);
                            keyNode.Tag = key;
                            keyNode.NodeFont = normalFont;
                            keyNode.BackColor = evenLighterBlue;
                        }
                    }
                }
            }
        }

        // tooltip and help methods.
        private void buttonLockHint_MouseHover(object sender, EventArgs e)
        {
            toolTipDoor.Show(lockHint, buttonLockHint);
        }

        private void buttonLockHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lockHint);
        }

        private void buttonUnlockingHint_MouseHover(object sender, EventArgs e)
        {
            toolTipDoor.Show(unlockingHint, buttonUnlockingHint);
        }

        private void buttonUnlockingHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(unlockingHint);
        }

        private void buttonKeyHint_MouseHover(object sender, EventArgs e)
        {
            toolTipDoor.Show(keyHint, buttonKeyHint);
        }

        private void buttonKeyHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(keyHint);
        }
    }
}
