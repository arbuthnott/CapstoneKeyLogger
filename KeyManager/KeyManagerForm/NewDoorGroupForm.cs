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
    public partial class NewDoorGroupForm : Form
    {
        private ObjectHolder objects;

        // some ui constants
        Color lightBlue = Color.FromArgb(166, 227, 247);
        Color evenLighterBlue = Color.FromArgb(220, 241, 247);
        Color dimTextColor = Color.FromArgb(130, 130, 130);
        Font normalFont = new Font("sans-serif", 8.5f);
        Font bitBiggerFont = new Font("sans-serif", 11);

        string groupHint =
            "Expand (click the '+') to see keys and\n" +
            "key rings checked-out by each person.\n\n" +
            "Double-click a key or key ring to check-in\n" +
            "that item.";
        string doorHint =
            "Greyed-out key rings are checked out (hover\n" +
            "to see who has them). Drag free key rings" +
            "onto a Person to check-out.";

        public NewDoorGroupForm(ObjectHolder objects)
        {
            InitializeComponent();
            this.objects = objects;

            PopulateGroupTree();
            PopulateDoorTree();
            buttonRename.Enabled = false;
            buttonDelete.Enabled = false;
            buttonMap.Enabled = false;
        }

        private void PopulateGroupTree()
        {
            treeViewDoorGroup.Nodes.Clear();
            treeViewDoorGroup.Font = bitBiggerFont;
            TreeNode locNode, doorNode;
            bool isOdd = true;
            foreach (Location loc in objects.locations)
            {
                locNode = treeViewDoorGroup.Nodes.Add(loc.Name);
                locNode.Tag = loc;
                foreach (Door door in loc.doors)
                {
                    doorNode = locNode.Nodes.Add(door.RoomNumber);
                    doorNode.Tag = door;
                    doorNode.NodeFont = normalFont;
                    doorNode.BackColor = evenLighterBlue;
                }

                locNode.BackColor = isOdd ? lightBlue : Color.White;
                isOdd = !isOdd;
            }
        }

        private void PopulateDoorTree()
        {
            treeViewDoors.Nodes.Clear();
            TreeNode doorNode;
            bool isOdd = true;
            foreach (Door door in objects.doors)
            {
                doorNode = treeViewDoors.Nodes.Add(door.RoomNumber);
                doorNode.Tag = door;
                doorNode.BackColor = isOdd ? lightBlue : evenLighterBlue;
                isOdd = !isOdd;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            DoorGroupDialog dgd = new DoorGroupDialog();
            DialogResult result = dgd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Location loc = dgd.location;
                objects.locations.Add(loc);
                loc.Save();
                PopulateGroupTree();
            }
            dgd.Dispose();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewDoorGroup.SelectedNode;
            Location loc = (Location)node.Tag;
            DoorGroupDialog dgd = new DoorGroupDialog(loc);
            DialogResult result = dgd.ShowDialog();
            if (result == DialogResult.OK)
            {
                loc.Save();
                PopulateGroupTree();
            }
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewDoorGroup.SelectedNode;
            Location loc = (Location)node.Tag;
            DialogResult result = MessageBox.Show("Delete the Door Group: " + loc.Name + "?", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                loc.Delete();
                objects.locations.Remove(loc);
                PopulateGroupTree();
            }
        }

        private void buttonDoorGroupHint_Click(object sender, EventArgs e)
        {

        }

        private void buttonDoorHint_Click(object sender, EventArgs e)
        {

        }

        private void treeViewDoorGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewDoorGroup.SelectedNode;
            bool shouldEnable = (node != null);
            buttonMap.Enabled = shouldEnable;
            buttonRename.Enabled = shouldEnable;
            buttonDelete.Enabled = shouldEnable;
        }

        // initiate door drag
        private void treeViewDoors_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = treeViewDoors.GetNodeAt(e.Location);
            if (node != null)
            {
                treeViewDoors.DoDragDrop(node, DragDropEffects.All);
            }
        }

        // effect on drag-over the groups
        private void treeViewDoorGroup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        // drop door onto group
        private void treeViewDoorGroup_DragDrop(object sender, DragEventArgs e)
        {
            // check for some "do-not-proceed" conditions
            if (!e.Data.GetDataPresent(typeof(TreeNode))) { return; }
            Point dropLoc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeViewDoorGroup.GetNodeAt(dropLoc);
            if (targetNode == null) { return; }

            if (targetNode.Level > 0) // want the parent
            {
                targetNode = targetNode.Parent;
            }
            Door door = ((Door)((TreeNode)(e.Data.GetData(typeof(TreeNode)))).Tag);
            Location loc = (Location)targetNode.Tag;
            if (!loc.doors.Contains(door))
            {
                loc.AddDoor(door);
                // update ui here
                TreeNode newNode = targetNode.Nodes.Add(door.RoomNumber);
                newNode.Tag = door;
                newNode.NodeFont = normalFont;
                newNode.BackColor = evenLighterBlue;
                targetNode.Expand();
            }
        }

        // double click to remove doors from group
        private void treeViewDoorGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0 && e.Node.Nodes.Count > 0)
            {
                // clear the group
                Location loc = (Location)e.Node.Tag;
                DialogResult result = MessageBox.Show("Remove all doors from the group: " + loc.Name + "?", "Confirm Clear Group", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    foreach (Door door in loc.doors.ToArray())
                    {
                        loc.RemoveDoor(door);
                    }
                    // update ui here
                    e.Node.Nodes.Clear();
                }
            }
            else
            {
                // removing a single door
                TreeNode clickedNode = e.Node;
                Location loc = (Location)clickedNode.Parent.Tag;
                Door door = (Door)clickedNode.Tag;
                loc.RemoveDoor(door);
                // now the ui here
                clickedNode.Parent.Nodes.Remove(clickedNode);
            }
        }
    }
}
