namespace KeyManagerForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.keyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFloorplans = new System.Windows.Forms.TabPage();
            this.panelFloorplans = new System.Windows.Forms.Panel();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.panelCheckout = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageKeysets = new System.Windows.Forms.TabPage();
            this.panelKeyset = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFloorplans.SuspendLayout();
            this.panelFloorplans.SuspendLayout();
            this.tabPageCheckout.SuspendLayout();
            this.panelCheckout.SuspendLayout();
            this.tabPageKeysets.SuspendLayout();
            this.panelKeyset.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyManagerToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // keyManagerToolStripMenuItem
            // 
            this.keyManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.keyManagerToolStripMenuItem.Name = "keyManagerToolStripMenuItem";
            this.keyManagerToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.keyManagerToolStripMenuItem.Text = "Key Manager";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(698, 1);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFloorplans);
            this.tabControl1.Controls.Add(this.tabPageCheckout);
            this.tabControl1.Controls.Add(this.tabPageKeysets);
            this.tabControl1.Controls.Add(this.tabPageSearch);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 465);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageFloorplans
            // 
            this.tabPageFloorplans.Controls.Add(this.panelFloorplans);
            this.tabPageFloorplans.Location = new System.Drawing.Point(4, 22);
            this.tabPageFloorplans.Name = "tabPageFloorplans";
            this.tabPageFloorplans.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFloorplans.Size = new System.Drawing.Size(777, 439);
            this.tabPageFloorplans.TabIndex = 0;
            this.tabPageFloorplans.Text = "Floor Plans";
            this.tabPageFloorplans.UseVisualStyleBackColor = true;
            // 
            // panelFloorplans
            // 
            this.panelFloorplans.Controls.Add(this.pictureBox1);
            this.panelFloorplans.Controls.Add(this.lblAdmin);
            this.panelFloorplans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFloorplans.Location = new System.Drawing.Point(3, 3);
            this.panelFloorplans.Name = "panelFloorplans";
            this.panelFloorplans.Size = new System.Drawing.Size(771, 433);
            this.panelFloorplans.TabIndex = 0;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.Location = new System.Drawing.Point(5, 9);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(157, 24);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "Floor Plans Here!";
            // 
            // tabPageCheckout
            // 
            this.tabPageCheckout.Controls.Add(this.panelCheckout);
            this.tabPageCheckout.Location = new System.Drawing.Point(4, 22);
            this.tabPageCheckout.Name = "tabPageCheckout";
            this.tabPageCheckout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckout.Size = new System.Drawing.Size(777, 439);
            this.tabPageCheckout.TabIndex = 1;
            this.tabPageCheckout.Text = "Keyset Checkout";
            this.tabPageCheckout.UseVisualStyleBackColor = true;
            // 
            // panelCheckout
            // 
            this.panelCheckout.Controls.Add(this.label3);
            this.panelCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckout.Location = new System.Drawing.Point(3, 3);
            this.panelCheckout.Name = "panelCheckout";
            this.panelCheckout.Size = new System.Drawing.Size(771, 433);
            this.panelCheckout.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Checkout stuff here!";
            // 
            // tabPageKeysets
            // 
            this.tabPageKeysets.Controls.Add(this.panelKeyset);
            this.tabPageKeysets.Location = new System.Drawing.Point(4, 22);
            this.tabPageKeysets.Name = "tabPageKeysets";
            this.tabPageKeysets.Size = new System.Drawing.Size(777, 439);
            this.tabPageKeysets.TabIndex = 2;
            this.tabPageKeysets.Text = "Manage Keysets";
            this.tabPageKeysets.UseVisualStyleBackColor = true;
            // 
            // panelKeyset
            // 
            this.panelKeyset.Controls.Add(this.label4);
            this.panelKeyset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKeyset.Location = new System.Drawing.Point(0, 0);
            this.panelKeyset.Name = "panelKeyset";
            this.panelKeyset.Size = new System.Drawing.Size(777, 439);
            this.panelKeyset.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Keyset Management here!";
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.panelSearch);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Size = new System.Drawing.Size(777, 439);
            this.tabPageSearch.TabIndex = 3;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.label2);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(777, 439);
            this.panelSearch.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search stuff here!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 448);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 489);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageFloorplans.ResumeLayout(false);
            this.panelFloorplans.ResumeLayout(false);
            this.panelFloorplans.PerformLayout();
            this.tabPageCheckout.ResumeLayout(false);
            this.panelCheckout.ResumeLayout(false);
            this.panelCheckout.PerformLayout();
            this.tabPageKeysets.ResumeLayout(false);
            this.panelKeyset.ResumeLayout(false);
            this.panelKeyset.PerformLayout();
            this.tabPageSearch.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem keyManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFloorplans;
        private System.Windows.Forms.Panel panelFloorplans;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TabPage tabPageCheckout;
        private System.Windows.Forms.Panel panelCheckout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageKeysets;
        private System.Windows.Forms.Panel panelKeyset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}