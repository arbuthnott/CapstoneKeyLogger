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
        private LookupForm lookupForm;
        private PersonnelForm personnelForm;
        private KeyRingForm keyRingForm;
        private Keys keys;  // what are naming conventions?
        private DoorGroupForm doorGroupForm;
        private DoorsForm doorsForm;

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

        }

        // Ribbon Menu Items
        // TODO - larger buttons with images

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
            if (floorPlanForm == null)
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (lookupForm == null)
            {
                lookupForm = new LookupForm(objects);
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
            if (personnelForm == null)
            {
                personnelForm = new PersonnelForm(objects);
                personnelForm.MdiParent = this;
                personnelForm.Text = "Personnel";
                personnelForm.Show();
            }
            else
            {
                personnelForm.Focus();
            }            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (keyRingForm == null)
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
            if (keys == null)
            {
                keys = new Keys(objects);
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
            if (doorGroupForm == null)
            {
                doorGroupForm = new DoorGroupForm(objects);
                doorGroupForm.MdiParent = this;
                doorGroupForm.Text = "Door Groups";
                doorGroupForm.Show();
            }
            else
            {
                doorGroupForm.Focus();
            }            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (doorsForm == null)
            {
                doorsForm = new DoorsForm(objects);
                doorsForm.MdiParent = this;
                doorsForm.Text = "Doors";
                doorsForm.Show();
            }
            else
            {
                doorsForm.Focus();
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

       
    }
}
