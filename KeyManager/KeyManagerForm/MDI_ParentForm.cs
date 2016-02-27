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
            MainForm mainForm = new MainForm(loginForm, isAdmin);
            mainForm.MdiParent = this;
            mainForm.Text = "Window " + childFormNumber++;
            mainForm.Show();
        }

        /// <summary>
        /// Open the form to view maps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFloorPlans_Click(object sender, EventArgs e)
        {
            FloorPlanForm mainForm = new FloorPlanForm(objects);
            mainForm.MdiParent = this;
            mainForm.Text = "Floor Plans";
            mainForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LookupForm mainForm = new LookupForm(objects);
            mainForm.MdiParent = this;
            mainForm.Text = "Lookup";
            mainForm.Show();
        }

        private void tsPersonnel_Click(object sender, EventArgs e)
        {
            PersonnelForm mainForm = new PersonnelForm(objects);
            mainForm.MdiParent = this;
            mainForm.Text = "Personnel";
            mainForm.Show();
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
