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
    public partial class NewKeysForm : Form
    {
        private ObjectHolder objects;
        private KeyType selectedType;

        // some ui constants
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Color dimTextColor = Color.FromArgb(130, 130, 130);
        Font normalFont = new Font("sans-serif", 8.5f);
        Font bitBiggerFont = new Font("sans-serif", 11);

        string typeHint =
            "Click on a key type to see details on the right\n" +
            "(Use '+' to expand to see the copies of each type)";
        string unlockableHint =
            "The doors that this key type can unlock. Drag doors\n" +
            "between the two lists to change.";
        string doorHint =
            "The doors that this key type can't unlock.  Drag\n" +
            "dors between the two lists to change.";

        public NewKeysForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            listBoxKeys.BackColor = evenLighterBlue;
            PopulateTypes();
        }

        private void PopulateTypes()
        {
            treeViewTypes.Nodes.Clear();
            TreeNode typeNode, keyNode;
            bool isOdd = true;
            foreach (KeyType type in objects.keytypes)
            {
                typeNode = treeViewTypes.Nodes.Add(type.Name);
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

        // populate the side box
        private void treeViewTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                groupBoxType.Enabled = true;
                ShowKeyType((KeyType)e.Node.Tag);
            }
        }

        private void ShowKeyType(KeyType type)
        {
            selectedType = type;
            labelTypeTitle.Text = "Key Type: " + type.Name;
            listBoxKeys.DataSource = new BindingList<Key>(selectedType.keys);
            listBoxKeys.DisplayMember = "Serial";
            listBoxKeys.SelectedIndex = -1;
            PopulateDoors();
        }

        private void SelectAndExpand(KeyType type)
        {
            foreach (TreeNode node in treeViewTypes.Nodes)
            {
                if ((KeyType)node.Tag == type)
                {
                    treeViewTypes.SelectedNode = node;
                    node.Expand();
                }
            }
        }

        private void PopulateDoors()
        {
            treeViewDoors.Nodes.Clear();
            treeViewUnlockable.Nodes.Clear();
            TreeNode node;
            bool unlockOdd = true, doorOdd = true;
            foreach (Door door in objects.doors)
            {
                if (selectedType.doors.Contains(door))
                {
                    // add to unlockable
                    node = treeViewUnlockable.Nodes.Add(door.RoomNumber);
                    node.Tag = door;
                    node.BackColor = unlockOdd ? lightBlue : Color.White;
                    unlockOdd = !unlockOdd;
                }
                else
                {
                    // add to doors
                    node = treeViewDoors.Nodes.Add(door.RoomNumber);
                    node.Tag = door;
                    node.BackColor = doorOdd ? lightBlue : Color.White;
                    doorOdd = !doorOdd;
                }
            }
        }

        // enable the delete and edit copy buttons, as appropriate.
        private void listBoxKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditKey.Enabled = listBoxKeys.SelectedIndex >= 0;
            buttonDeleteKey.Enabled = listBoxKeys.SelectedIndex >= 0;
        }

        private void buttonCreateType_Click(object sender, EventArgs e)
        {
            KeytypeDialog ktd = new KeytypeDialog();
            DialogResult result = ktd.ShowDialog();
            if (result == DialogResult.OK)
            {
                KeyType type = ktd.keytype;
                type.Save();
                objects.keytypes.Add(type);
                bool isOdd = treeViewTypes.Nodes.Count % 2 == 0;
                TreeNode newNode = treeViewTypes.Nodes.Add(type.Name);
                newNode.Tag = type;
                newNode.BackColor = isOdd ? lightBlue : Color.White;
            }
            ktd.Dispose();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            KeytypeDialog ktd = new KeytypeDialog(selectedType);
            DialogResult result = ktd.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedType.Save();
                foreach (TreeNode node in treeViewTypes.Nodes)
                {
                    if ((KeyType)node.Tag == selectedType)
                    {
                        node.Text = selectedType.Name;
                    }
                }
                labelTypeTitle.Text = "Key Type: " + selectedType.Name;

            }
            ktd.Dispose();
        }

        private void buttonDeleteType_Click(object sender, EventArgs e)
        {
            // verify the delete.
            if (selectedType.keys.Count > 0)
            {
                MessageBox.Show("Cannot delete a key type with existing key copies.\nDelete or reassign all copies first.", "Cannot Delete");
                return;
            }
            DialogResult result = MessageBox.Show("Really delete key type: " + selectedType.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // delete it.
                objects.keytypes.Remove(selectedType);
                selectedType.Delete();
                PopulateTypes();
                groupBoxType.Enabled = false;
            }
        }

        private void buttonCreateCopy_Click(object sender, EventArgs e)
        {
            // open a form to create a key
            KeyDialog keyd = new KeyDialog(objects);
            DialogResult result = keyd.ShowDialog();
            if (result == DialogResult.OK)
            {
                // create the key
                Key key = keyd.key;
                key.KeyType.keys.Add(key);
                objects.keys.Add(key);
                key.Save();
                PopulateTypes();
                SelectAndExpand(key.KeyType);
            }
            keyd.Dispose();
        }

        private void buttonEditKey_Click(object sender, EventArgs e)
        {
            Key key = (Key)listBoxKeys.SelectedItem;
            KeyDialog keyd = new KeyDialog(objects, key);
            DialogResult result = keyd.ShowDialog();
            if (result == DialogResult.OK)
            {
                // update the key
                selectedType.keys.Remove(key);
                key.KeyType.keys.Add(key);
                key.Save();
                PopulateTypes();
                SelectAndExpand(key.KeyType);
            }
            keyd.Dispose();
        }

        private void buttonDeleteKey_Click(object sender, EventArgs e)
        {
            Key key = (Key)listBoxKeys.SelectedItem;
            DialogResult result = MessageBox.Show("Really delete the key: " + key.Serial + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                selectedType.keys.Remove(key);
                objects.keys.Remove(key);
                key.Delete();
                PopulateTypes();
                SelectAndExpand(key.KeyType);
            }
        }

        // initiate drag from doors
        private void treeViewDoors_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewDoors.GetNodeAt(e.Location);
            if (nodeToDrag != null)
            {
                treeViewDoors.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // drag enter graphic for unlockable list
        private void treeViewUnlockable_DragEnter(object sender, DragEventArgs e)
        {
            // ensure the drag data didn't originate here.
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !treeViewUnlockable.Nodes.Contains((TreeNode)e.Data.GetData(typeof(TreeNode))))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // complete drag-drop into unlockable list
        private void treeViewUnlockable_DragDrop(object sender, DragEventArgs e)
        {
            // ensure the drag data didn't originate here.
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !treeViewUnlockable.Nodes.Contains((TreeNode)e.Data.GetData(typeof(TreeNode))))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                Door door = (Door)draggedNode.Tag;
                selectedType.ConnectToDoor(door);
                PopulateDoors();
            }
        }

        // initiate drag from unlockable list
        private void treeViewUnlockable_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeToDrag = treeViewUnlockable.GetNodeAt(e.Location);
            if (nodeToDrag != null)
            {
                treeViewUnlockable.DoDragDrop(nodeToDrag, DragDropEffects.All);
            }
        }

        // graphic for drag into door list
        private void treeViewDoors_DragEnter(object sender, DragEventArgs e)
        {
            // ensure the drag data didn't originate here.
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !treeViewDoors.Nodes.Contains((TreeNode)e.Data.GetData(typeof(TreeNode))))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // finish drag drop into door list
        private void treeViewDoors_DragDrop(object sender, DragEventArgs e)
        {
            // ensure the drag data didn't originate here.
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !treeViewDoors.Nodes.Contains((TreeNode)e.Data.GetData(typeof(TreeNode))))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                Door door = (Door)draggedNode.Tag;
                selectedType.DisconnectDoor(door);
                PopulateDoors();
            }
        }

        // tooltip and help stuff
        private void buttonTypeHint_MouseHover(object sender, EventArgs e)
        {
            toolTipKey.Show(typeHint, buttonTypeHint);
        }

        private void buttonTypeHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(typeHint);
        }

        private void buttonUnlockableHint_MouseHover(object sender, EventArgs e)
        {
            toolTipKey.Show(unlockableHint, buttonUnlockableHint);
        }

        private void buttonUnlockableHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(unlockableHint);
        }

        private void buttonDoorHint_MouseHover(object sender, EventArgs e)
        {
            toolTipKey.Show(doorHint, buttonDoorHint);
        }

        private void buttonDoorHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(doorHint);
        }

        private void treeViewTypes_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            toolTipKey.Show("Click to see details on the right", treeViewTypes);
        }

        private void treeViewUnlockable_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            toolTipKey.Show("Drag to door list to remove", treeViewUnlockable);
        }

        private void treeViewDoors_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            toolTipKey.Show("Drag to Unlockable list to add", treeViewDoors);
        }
    }
}
