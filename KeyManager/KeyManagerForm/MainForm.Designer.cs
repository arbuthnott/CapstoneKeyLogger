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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.keyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFloorplans = new System.Windows.Forms.TabPage();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.tabPageKeysets = new System.Windows.Forms.TabPage();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.panelFloorplans = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCheckout = new System.Windows.Forms.Panel();
            this.panelKeyset = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFloorplans.SuspendLayout();
            this.tabPageCheckout.SuspendLayout();
            this.tabPageKeysets.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.panelFloorplans.SuspendLayout();
            this.panelCheckout.SuspendLayout();
            this.panelKeyset.SuspendLayout();
            this.panelSearch.SuspendLayout();
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
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
            // panelFloorplans
            // 
            this.panelFloorplans.Controls.Add(this.label1);
            this.panelFloorplans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFloorplans.Location = new System.Drawing.Point(3, 3);
            this.panelFloorplans.Name = "panelFloorplans";
            this.panelFloorplans.Size = new System.Drawing.Size(771, 433);
            this.panelFloorplans.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Floor Plans Here!";
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
            // panelKeyset
            // 
            this.panelKeyset.Controls.Add(this.label4);
            this.panelKeyset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKeyset.Location = new System.Drawing.Point(0, 0);
            this.panelKeyset.Name = "panelKeyset";
            this.panelKeyset.Size = new System.Drawing.Size(777, 439);
            this.panelKeyset.TabIndex = 0;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Checkout stuff here!";
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
            this.tabPageCheckout.ResumeLayout(false);
            this.tabPageKeysets.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.panelFloorplans.ResumeLayout(false);
            this.panelFloorplans.PerformLayout();
            this.panelCheckout.ResumeLayout(false);
            this.panelCheckout.PerformLayout();
            this.panelKeyset.ResumeLayout(false);
            this.panelKeyset.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageCheckout;
        private System.Windows.Forms.Panel panelCheckout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageKeysets;
        private System.Windows.Forms.Panel panelKeyset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label label2;
    }
}