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
            "Expand (click the '+') to see keys in each ring.\n" +
            "Double-click to remove a key from a ring.";
        string unlockableHint =
            "Keys are grouped by type, and keys already in a\n" +
            "key ring are greyed out (hover to see which ring\n" +
            "they are in). Drag onto a key ring to add that key.";
        string doorHint =
            "" +
            "";

        public NewKeysForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            listBoxKeys.DisplayMember = "Serial";
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
            listBoxKeys.DataSource = selectedType.keys;
            listBoxKeys.SelectedIndex = -1;
            PopulateDoors();
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
    }
}
