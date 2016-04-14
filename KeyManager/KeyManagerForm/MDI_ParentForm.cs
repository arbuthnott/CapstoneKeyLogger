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
using System.IO;

namespace KeyManagerForm
{
    public partial class MDI_ParentForm : Form
    {
        private int childFormNumber = 0;
        private bool isAdmin = false;
        private Login loginForm;
        private Personnel currentUser;
        private bool loggingOut = false;
        private ObjectHolder objects;
        private Boolean treelaoded = false;

        // MDI Child Forms
        private MainForm mainForm;      // to be removed
        private FloorPlanForm floorPlanForm;
        //private LookupForm lookupForm;
        private NewLookupForm lookupForm;
        //private PersonnelForm personnelForm;
        private NewPersonnelForm personnelForm;
        //private KeyRingForm keyRingForm;
        private NewKeyringForm keyRingForm;
        //private KeysForm keys;
        private NewKeysForm keys;
        //private DoorGroupForm doorGroupForm;
        private NewDoorGroupForm doorGroupForm;
        //private DoorsForm doorsForm;
        private NewDoorForm doorsForm;
        private CheckoutForm checkoutForm;
        private HelpForm helpForm;

        public MDI_ParentForm(Login lgnForm, int loginId)
        {
            InitializeComponent();
            objects = new ObjectHolder();
            currentUser = objects.GetPersonnelById(loginId);
                      
            if (currentUser.IsAdmin)
            {
                isAdmin = true;
                lblUserName.Text = currentUser.FirstName + " " + currentUser.LastName + "  \n(Administrator)";
            }  
            else
            {
                lblUserName.Text = currentUser.FirstName + " " + currentUser.LastName + "  \n(User)";
            }
            this.loginForm = lgnForm;

            
            SetupTreeView();
        }
        
        private void SetupTreeView()
        {
            treeViewSummary.BeginUpdate();
            treeViewSummary.Nodes.Clear();
             
            TreeNode n1 = treeViewSummary.Nodes.Add("Key Rings");
            foreach (KeyRing ring in objects.keyrings)
            {
                TreeNode n = n1.Nodes.Add(ring.Name);
                foreach (Key key in ring.keys)
                {
                    TreeNode sub_n = n.Nodes.Add(key.Serial);
                    sub_n.Tag = "rings";
                }
                n.Tag = "rings";
            }
            n1.Tag = "rings";
            n1.Expand();

            TreeNode n2 = treeViewSummary.Nodes.Add("Door Groups");
            foreach (Location loc in objects.locations)
            {
                TreeNode n = n2.Nodes.Add(loc.Name);
                foreach (Door door in loc.doors)
                {
                    TreeNode sub_n = n.Nodes.Add(door.RoomNumber);
                    sub_n.Tag = "groups";
                }
                n.Tag = "groups";
            }
            n2.Tag = "groups";
            n2.Expand();

            TreeNode n3 = treeViewSummary.Nodes.Add("People");
            foreach (Personnel person in objects.personnel)
            {
                n3.Nodes.Add(person.FirstName + " " + person.LastName);
            }
            n3.Tag = "people";
            n3.Expand();

            treeViewSummary.EndUpdate();


        }

        private void treeViewSummary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treelaoded)
            {
                if (e.Node.Tag.Equals("rings"))
                {
                    if (keyRingForm == null || keyRingForm.IsDisposed)
                    {
                        keyRingForm = new NewKeyringForm(objects);
                        keyRingForm.MdiParent = this;
                        keyRingForm.Text = "Key Rings";
                        keyRingForm.Show();
                    }
                    else
                    {
                        keyRingForm.Focus();
                    }
                }

                if (e.Node.Tag.Equals("groups"))
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

                if (e.Node.Tag.Equals("people"))
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
            }
            else
            {
                treelaoded = true;
            }
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
                keyRingForm = new NewKeyringForm(objects);
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
                keys = new NewKeysForm(objects);
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

        private void toolStripButtonHelp_Click(object sender, EventArgs e)
        {
            if (helpForm == null || helpForm.IsDisposed)
            {
                helpForm = new HelpForm();
                helpForm.MdiParent = this;
                helpForm.Show();
            }
            else
            {
                helpForm.Focus();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Control GetActiveControl()
        {
            IContainerControl container = this as IContainerControl;
            Control control = null;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = this.GetActiveControl();
            if (control != null)
            {
                if (typeof(TextBoxBase).IsAssignableFrom(control.GetType()))
                {
                    ((TextBoxBase)control).Cut();
                }
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = this.GetActiveControl();
            if (control != null)
            {
                if (typeof(TextBoxBase).IsAssignableFrom(control.GetType()))
                {
                    ((TextBoxBase)control).Copy();
                }
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = this.GetActiveControl();
            if (control != null)
            {
                if (typeof(TextBoxBase).IsAssignableFrom(control.GetType()))
                {
                    ((TextBoxBase)control).Paste();
                }
            }
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

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Reset();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "CSV | *.csv";
            saveFileDialog.Title = "Save to CSV";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Stream outStream = saveFileDialog.OpenFile();
                    StreamWriter writer = new StreamWriter(outStream);
                    writer.Write((new CSV()).GetCSV());

                    MessageBox.Show("CSV saved at " + saveFileDialog.FileName, "Export Complete");
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Error writing to csv: " + excep.Message, "Error");
                }
            }
        }

        private void importFromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "csv";
            openFileDialog.Filter = "CSV | *.csv";
            openFileDialog.Title = "Import from CSV";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                result = MessageBox.Show("Are you sure you wish to import? All current data will be overwritten", "Confirm Import", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string status = (new CSV()).InsertCSV(openFileDialog.FileName);
                    if (status == "refuse")
                    {
                        MessageBox.Show("Import Cancelled. Can only import from a CSV created using KeyManager.", "Import Cancelled");
                    }
                    else if (status == "error")
                    {
                        MessageBox.Show("Encountered an Error while importing");
                    }
                    else
                    {
                        MessageBox.Show("Import Complete");

                        // reset it all!
                        objects = new ObjectHolder();
                        currentUser = objects.GetPersonnelById(1);
                        isAdmin = true;
                        SetupTreeView();
                    }
                }
            }
            
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Reset();
            folderBrowserDialog.Description = "Choose a folder to store your backup in:";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string dbPath = DbSetupManager.GetDBPath();
                string dirPath = folderBrowserDialog.SelectedPath;
                string backupPath = dirPath + "\\" + "KEYMANAGER_BACKUP_" + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) + ".sqlite";
                File.Copy(dbPath, backupPath);

                MessageBox.Show("Backup created at " + backupPath, "Backup Complete");
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = ".sqlite";
            openFileDialog.Filter = "SQLite files (*.sqlite) | *.sqlite";
            openFileDialog.Title = "Select backup";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (!DbSetupManager.EvaluateExternalDB(path))
                {
                    // problem with selected database
                    MessageBox.Show(
                        "Cannot restore from the file you selected.\n" +
                        "Only restore from backups created by KeyManager\n" +
                        "usually name 'KEYMANAGER_BACKUP_###.sqlite'\n" +
                        "with some number in place of the '###'.",
                        "Restore Cancelled"
                    );
                }
                else
                {
                    // looks good
                    result = MessageBox.Show(
                        "Are you sure you want to restore from backup?\n" +
                        "All current data will be overwritten.",
                        "Confirm Restore from Backup",
                        MessageBoxButtons.OKCancel
                    );
                    if (result == DialogResult.OK)
                    {
                        string dbpath = DbSetupManager.GetDBPath();
                        File.Delete(dbpath);
                        File.Copy(path, dbpath);

                        // reset it all!
                        objects = new ObjectHolder();
                        currentUser = objects.GetPersonnelById(1);
                        isAdmin = true;
                        SetupTreeView();

                        MessageBox.Show("Restore complete.");
                    }
                }
            }
        }

        
    }
}
