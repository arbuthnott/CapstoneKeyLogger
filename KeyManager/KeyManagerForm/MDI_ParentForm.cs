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
    public partial class MDI_ParentForm : Form
    {
        private int childFormNumber = 0;
        private bool isAdmin = false;
        private Login loginForm;
        private bool loggingOut = false;
        private ObjectHolder objects;

        // MDI Child Forms
        private MainForm mainForm;      // to be removed
        private FloorPlanForm floorPlanForm;
        //private LookupForm lookupForm;
        private NewLookupForm lookupForm;
        //private PersonnelForm personnelForm;
        private NewPersonnelForm personnelForm;
        private KeyRingForm keyRingForm;
        private KeysForm keys;  // what are naming conventions?
        //private DoorGroupForm doorGroupForm;
        private NewDoorGroupForm doorGroupForm;
        //private DoorsForm doorsForm;
        private NewDoorForm doorsForm;
        private CheckoutForm checkoutForm;

        public MDI_ParentForm(Login lgnForm, bool admin)
        {
            InitializeComponent();
            objects = new ObjectHolder();
                      
            if (admin)
            {
                isAdmin = true;
            }  
            else
            {

            }
            this.loginForm = lgnForm;

            SetupTreeView();
        }
        
        private void SetupTreeView()
        {
            treeViewSummary.BeginUpdate();
            //treeView2.Nodes.Clear();

            TreeNode n1 = treeViewSummary.Nodes.Add("Key Rings");
            foreach (KeyRing ring in objects.keyrings)
            {
                TreeNode n = n1.Nodes.Add(ring.Name);
                foreach (Key key in ring.keys)
                {
                    n.Nodes.Add(key.Serial);
                }                
            }
            n1.Expand();

            TreeNode n2 = treeViewSummary.Nodes.Add("Door Groups");
            foreach (Location loc in objects.locations)
            {
                TreeNode n = n2.Nodes.Add(loc.Name);
                foreach (Door door in loc.doors)
                {
                    n.Nodes.Add(door.RoomNumber);
                }
            }
            n2.Expand();

            TreeNode n3 = treeViewSummary.Nodes.Add("People");
            foreach (Personnel person in objects.personnel)
            {
                n3.Nodes.Add(person.FirstName + " " + person.LastName);
            }
            n3.Expand();

            treeViewSummary.EndUpdate();


        }

        private void treeViewSummary_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public bool ShowDoorGroupOnMap(Location location)
        {
            List<MapPoint> points = objects.GetMapPointsByGroup(location);
            if (points.Count == 0)
            {
                // no mappoints for this group
                return false;
            }
            if (floorPlanForm == null || floorPlanForm.IsDisposed)
            {
                floorPlanForm = new FloorPlanForm(objects);
                floorPlanForm.MdiParent = this;
                floorPlanForm.Text = "Floor Plans";
                floorPlanForm.Show();
            }
            else
            {
                floorPlanForm.Focus();
            }
            // now show those points on the form?
            int floor = points[0].floor; // we'll just show points from this floor for now.
            foreach (MapPoint point in points.ToArray())
            {
                if (point.floor != floor)
                {
                    points.Remove(point);
                }
            }
            floorPlanForm.ShowPoints(points);
            return true;
        }

        public bool ShowDoorOnMap(Door door)
        {
            List<MapPoint> points = objects.GetMapPointsByDoor(door);
            if (points.Count == 0)
            {
                // no mappoints for this door
                return false;
            }
            if (floorPlanForm == null || floorPlanForm.IsDisposed)
            {
                floorPlanForm = new FloorPlanForm(objects);
                floorPlanForm.MdiParent = this;
                floorPlanForm.Text = "Floor Plans";
                floorPlanForm.Show();
            }
            else
            {
                floorPlanForm.Focus();
            }
            // now show those points on the form?
            int floor = points[0].floor; // we'll just show points from this floor for now.
            foreach (MapPoint point in points.ToArray())
            {
                if (point.floor != floor)
                {
                    points.Remove(point);
                }
            }
            floorPlanForm.ShowPoints(points);
            return true;
        }

     

        // Ribbon Menu Items


        /// <summary>
        /// Opens the old MainForm windows with all tabs still working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                mainForm = new MainForm(loginForm, isAdmin);
                mainForm.MdiParent = this;
                mainForm.Text = "Window " + childFormNumber++;
                mainForm.Show();
            }
            else
            {
                mainForm.Focus();
            }
            
        }

        /// <summary>
        /// Open the form to view maps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFloorPlans_Click(object sender, EventArgs e)
        {
            if (floorPlanForm == null || floorPlanForm.IsDisposed)
            {
                floorPlanForm = new FloorPlanForm(objects);
                floorPlanForm.MdiParent = this;
                floorPlanForm.Text = "Floor Plans";
                floorPlanForm.Show();
            }
            else
            {
                floorPlanForm.Focus();
            }  
        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {
            if (lookupForm == null || lookupForm.IsDisposed)
            {
                //lookupForm = new LookupForm(objects);
                lookupForm = new NewLookupForm(objects);
                lookupForm.MdiParent = this;
                lookupForm.Text = "Lookup";
                lookupForm.Show();
            }
            else
            {
                lookupForm.Focus();
            }
        }

        private void tsPersonnel_Click(object sender, EventArgs e)
        {
            if (personnelForm == null || personnelForm.IsDisposed)
            {
                personnelForm = new NewPersonnelForm(objects);
                personnelForm.MdiParent = this;
                personnelForm.Text = "Personnel";
                personnelForm.Show();
            }
            else
            {
                personnelForm.Focus();
            }            
        }

        private void toolStripButtonKeyRing_Click(object sender, EventArgs e)
        {
            if (keyRingForm == null || keyRingForm.IsDisposed)
            {
                keyRingForm = new KeyRingForm(objects);
                keyRingForm.MdiParent = this;
                keyRingForm.Text = "Key Rings";
                keyRingForm.Show();
            }
            else
            {
                keyRingForm.Focus();
            }
        }

        private void tsKeys_Click(object sender, EventArgs e)
        {
            if (keys == null || keys.IsDisposed)
            {
                keys = new KeysForm(objects);
                keys.MdiParent = this;
                keys.Text = "Keys";
                keys.Show();
            }
            else        
            {
                keys.Focus();
            }
        }

        private void txDoorGroups_Click(object sender, EventArgs e)
        {
            if (doorGroupForm == null || doorGroupForm.IsDisposed)
            {
                doorGroupForm = new NewDoorGroupForm(objects);
                doorGroupForm.MdiParent = this;
                doorGroupForm.Text = "Door Groups";
                doorGroupForm.Show();
            }
            else
            {
                doorGroupForm.Focus();
            }            
        }

        private void toolStripButtonDoor_Click(object sender, EventArgs e)
        {
            if (doorsForm == null || doorsForm.IsDisposed)
            {
                doorsForm = new NewDoorForm(objects);
                doorsForm.MdiParent = this;
                doorsForm.Text = "Doors";
                doorsForm.Show();
            }
            else
            {
                doorsForm.Focus();
            }
        }

        private void toolStripButtonCheckout_Click(object sender, EventArgs e)
        {
            if (checkoutForm == null || checkoutForm.IsDisposed)
            {
                checkoutForm = new CheckoutForm(objects);
                checkoutForm.MdiParent = this;
                checkoutForm.Show();
            }
            else
            {
                checkoutForm.Focus();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLogout_Click(object sender, EventArgs e)
        {
            this.loggingOut = true;
            loginForm.Logout();
        }

        private void MDI_ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.loggingOut)
            {
                loginForm.Close();
            }
        }
    }
}
