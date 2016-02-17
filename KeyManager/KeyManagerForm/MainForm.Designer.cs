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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFloorplans = new System.Windows.Forms.TabPage();
            this.panelFloorplans = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.tabPageCheckout = new System.Windows.Forms.TabPage();
            this.panelCheckout = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageKeysets = new System.Windows.Forms.TabPage();
            this.panelKeyset = new System.Windows.Forms.Panel();
            this.groupBoxKeysetManage = new System.Windows.Forms.GroupBox();
            this.buttonAddKeysetKey = new System.Windows.Forms.Button();
            this.buttonRemoveKeysetKey = new System.Windows.Forms.Button();
            this.listBoxKeysNotInKeyset = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveKeysetChanges = new System.Windows.Forms.Button();
            this.listBoxKeysInKeyset = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeysetEdit = new System.Windows.Forms.Button();
            this.labelKeysetTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxKeysets = new System.Windows.Forms.ListBox();
            this.buttonCreateKeyset = new System.Windows.Forms.Button();
            this.labelKeysetChoice = new System.Windows.Forms.Label();
            this.tabPageLookup = new System.Windows.Forms.TabPage();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.groupBoxLookupResults = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLookupDoors = new System.Windows.Forms.TextBox();
            this.listBoxLookupDoors = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxLookupKeyrings = new System.Windows.Forms.TextBox();
            this.listBoxLookupKeyrings = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLookupKeys = new System.Windows.Forms.TextBox();
            this.listBoxLookupKeys = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLookupKeysets = new System.Windows.Forms.TextBox();
            this.listBoxLookupKeysets = new System.Windows.Forms.ListBox();
            this.labelLookupResultsTitle = new System.Windows.Forms.Label();
            this.groupBoxLookupSource = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxKeyserialLookup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxKeytypeLookup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDoorLookup = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageFloorplans.SuspendLayout();
            this.panelFloorplans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageCheckout.SuspendLayout();
            this.panelCheckout.SuspendLayout();
            this.tabPageKeysets.SuspendLayout();
            this.panelKeyset.SuspendLayout();
            this.groupBoxKeysetManage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageLookup.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.groupBoxLookupResults.SuspendLayout();
            this.groupBoxLookupSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFloorplans);
            this.tabControl.Controls.Add(this.tabPageCheckout);
            this.tabControl.Controls.Add(this.tabPageKeysets);
            this.tabControl.Controls.Add(this.tabPageLookup);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(785, 465);
            this.tabControl.TabIndex = 2;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 448);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            this.panelKeyset.Controls.Add(this.groupBoxKeysetManage);
            this.panelKeyset.Controls.Add(this.groupBox1);
            this.panelKeyset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKeyset.Location = new System.Drawing.Point(0, 0);
            this.panelKeyset.Name = "panelKeyset";
            this.panelKeyset.Size = new System.Drawing.Size(777, 439);
            this.panelKeyset.TabIndex = 0;
            // 
            // groupBoxKeysetManage
            // 
            this.groupBoxKeysetManage.Controls.Add(this.buttonAddKeysetKey);
            this.groupBoxKeysetManage.Controls.Add(this.buttonRemoveKeysetKey);
            this.groupBoxKeysetManage.Controls.Add(this.listBoxKeysNotInKeyset);
            this.groupBoxKeysetManage.Controls.Add(this.label4);
            this.groupBoxKeysetManage.Controls.Add(this.buttonSaveKeysetChanges);
            this.groupBoxKeysetManage.Controls.Add(this.listBoxKeysInKeyset);
            this.groupBoxKeysetManage.Controls.Add(this.label1);
            this.groupBoxKeysetManage.Controls.Add(this.buttonKeysetEdit);
            this.groupBoxKeysetManage.Controls.Add(this.labelKeysetTitle);
            this.groupBoxKeysetManage.Location = new System.Drawing.Point(345, 3);
            this.groupBoxKeysetManage.Name = "groupBoxKeysetManage";
            this.groupBoxKeysetManage.Size = new System.Drawing.Size(424, 428);
            this.groupBoxKeysetManage.TabIndex = 1;
            this.groupBoxKeysetManage.TabStop = false;
            this.groupBoxKeysetManage.Text = "Keys in Keyset";
            // 
            // buttonAddKeysetKey
            // 
            this.buttonAddKeysetKey.Location = new System.Drawing.Point(224, 209);
            this.buttonAddKeysetKey.Name = "buttonAddKeysetKey";
            this.buttonAddKeysetKey.Size = new System.Drawing.Size(89, 23);
            this.buttonAddKeysetKey.TabIndex = 9;
            this.buttonAddKeysetKey.Text = "Add Key";
            this.buttonAddKeysetKey.UseVisualStyleBackColor = true;
            this.buttonAddKeysetKey.Click += new System.EventHandler(this.buttonAddKeysetKey_Click);
            // 
            // buttonRemoveKeysetKey
            // 
            this.buttonRemoveKeysetKey.Location = new System.Drawing.Point(329, 209);
            this.buttonRemoveKeysetKey.Name = "buttonRemoveKeysetKey";
            this.buttonRemoveKeysetKey.Size = new System.Drawing.Size(89, 23);
            this.buttonRemoveKeysetKey.TabIndex = 8;
            this.buttonRemoveKeysetKey.Text = "Remove Key";
            this.buttonRemoveKeysetKey.UseVisualStyleBackColor = true;
            this.buttonRemoveKeysetKey.Click += new System.EventHandler(this.buttonRemoveKeysetKey_Click);
            // 
            // listBoxKeysNotInKeyset
            // 
            this.listBoxKeysNotInKeyset.FormattingEnabled = true;
            this.listBoxKeysNotInKeyset.Location = new System.Drawing.Point(10, 259);
            this.listBoxKeysNotInKeyset.Name = "listBoxKeysNotInKeyset";
            this.listBoxKeysNotInKeyset.Size = new System.Drawing.Size(408, 108);
            this.listBoxKeysNotInKeyset.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Available Keys:";
            // 
            // buttonSaveKeysetChanges
            // 
            this.buttonSaveKeysetChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveKeysetChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveKeysetChanges.Location = new System.Drawing.Point(286, 384);
            this.buttonSaveKeysetChanges.Name = "buttonSaveKeysetChanges";
            this.buttonSaveKeysetChanges.Size = new System.Drawing.Size(132, 28);
            this.buttonSaveKeysetChanges.TabIndex = 5;
            this.buttonSaveKeysetChanges.Text = "Save Changes";
            this.buttonSaveKeysetChanges.UseVisualStyleBackColor = true;
            this.buttonSaveKeysetChanges.Click += new System.EventHandler(this.buttonSaveKeysetChanges_Click);
            // 
            // listBoxKeysInKeyset
            // 
            this.listBoxKeysInKeyset.FormattingEnabled = true;
            this.listBoxKeysInKeyset.Location = new System.Drawing.Point(10, 73);
            this.listBoxKeysInKeyset.Name = "listBoxKeysInKeyset";
            this.listBoxKeysInKeyset.Size = new System.Drawing.Size(408, 108);
            this.listBoxKeysInKeyset.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keys currently in set:";
            // 
            // buttonKeysetEdit
            // 
            this.buttonKeysetEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKeysetEdit.Location = new System.Drawing.Point(295, 23);
            this.buttonKeysetEdit.Name = "buttonKeysetEdit";
            this.buttonKeysetEdit.Size = new System.Drawing.Size(123, 23);
            this.buttonKeysetEdit.TabIndex = 2;
            this.buttonKeysetEdit.Text = "Edit Name / Details";
            this.buttonKeysetEdit.UseVisualStyleBackColor = true;
            this.buttonKeysetEdit.Click += new System.EventHandler(this.buttonKeysetEdit_Click);
            // 
            // labelKeysetTitle
            // 
            this.labelKeysetTitle.AutoSize = true;
            this.labelKeysetTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeysetTitle.Location = new System.Drawing.Point(6, 20);
            this.labelKeysetTitle.Name = "labelKeysetTitle";
            this.labelKeysetTitle.Size = new System.Drawing.Size(122, 24);
            this.labelKeysetTitle.TabIndex = 1;
            this.labelKeysetTitle.Text = "Keyset Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxKeysets);
            this.groupBox1.Controls.Add(this.buttonCreateKeyset);
            this.groupBox1.Controls.Add(this.labelKeysetChoice);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keysets";
            // 
            // listBoxKeysets
            // 
            this.listBoxKeysets.FormattingEnabled = true;
            this.listBoxKeysets.Location = new System.Drawing.Point(10, 57);
            this.listBoxKeysets.Name = "listBoxKeysets";
            this.listBoxKeysets.Size = new System.Drawing.Size(302, 355);
            this.listBoxKeysets.TabIndex = 2;
            this.listBoxKeysets.SelectedIndexChanged += new System.EventHandler(this.listBoxKeysets_SelectedIndexChanged);
            // 
            // buttonCreateKeyset
            // 
            this.buttonCreateKeyset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateKeyset.Location = new System.Drawing.Point(237, 23);
            this.buttonCreateKeyset.Name = "buttonCreateKeyset";
            this.buttonCreateKeyset.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateKeyset.TabIndex = 1;
            this.buttonCreateKeyset.Text = "New Keyset";
            this.buttonCreateKeyset.UseVisualStyleBackColor = true;
            this.buttonCreateKeyset.Click += new System.EventHandler(this.buttonCreateKeyset_Click);
            // 
            // labelKeysetChoice
            // 
            this.labelKeysetChoice.AutoSize = true;
            this.labelKeysetChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeysetChoice.Location = new System.Drawing.Point(6, 20);
            this.labelKeysetChoice.Name = "labelKeysetChoice";
            this.labelKeysetChoice.Size = new System.Drawing.Size(152, 24);
            this.labelKeysetChoice.TabIndex = 0;
            this.labelKeysetChoice.Text = "Choose a Keyset";
            // 
            // tabPageLookup
            // 
            this.tabPageLookup.Controls.Add(this.panelSearch);
            this.tabPageLookup.Location = new System.Drawing.Point(4, 22);
            this.tabPageLookup.Name = "tabPageLookup";
            this.tabPageLookup.Size = new System.Drawing.Size(777, 439);
            this.tabPageLookup.TabIndex = 3;
            this.tabPageLookup.Text = "Lookup";
            this.tabPageLookup.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.groupBoxLookupResults);
            this.panelSearch.Controls.Add(this.groupBoxLookupSource);
            this.panelSearch.Controls.Add(this.pictureBox2);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(777, 439);
            this.panelSearch.TabIndex = 0;
            // 
            // groupBoxLookupResults
            // 
            this.groupBoxLookupResults.Controls.Add(this.label10);
            this.groupBoxLookupResults.Controls.Add(this.textBoxLookupDoors);
            this.groupBoxLookupResults.Controls.Add(this.listBoxLookupDoors);
            this.groupBoxLookupResults.Controls.Add(this.label9);
            this.groupBoxLookupResults.Controls.Add(this.textBoxLookupKeyrings);
            this.groupBoxLookupResults.Controls.Add(this.listBoxLookupKeyrings);
            this.groupBoxLookupResults.Controls.Add(this.label8);
            this.groupBoxLookupResults.Controls.Add(this.textBoxLookupKeys);
            this.groupBoxLookupResults.Controls.Add(this.listBoxLookupKeys);
            this.groupBoxLookupResults.Controls.Add(this.label7);
            this.groupBoxLookupResults.Controls.Add(this.textBoxLookupKeysets);
            this.groupBoxLookupResults.Controls.Add(this.listBoxLookupKeysets);
            this.groupBoxLookupResults.Controls.Add(this.labelLookupResultsTitle);
            this.groupBoxLookupResults.Location = new System.Drawing.Point(8, 218);
            this.groupBoxLookupResults.Name = "groupBoxLookupResults";
            this.groupBoxLookupResults.Size = new System.Drawing.Size(761, 213);
            this.groupBoxLookupResults.TabIndex = 2;
            this.groupBoxLookupResults.TabStop = false;
            this.groupBoxLookupResults.Text = "Lookup Results";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(582, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Doors";
            // 
            // textBoxLookupDoors
            // 
            this.textBoxLookupDoors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLookupDoors.Location = new System.Drawing.Point(697, 73);
            this.textBoxLookupDoors.Multiline = true;
            this.textBoxLookupDoors.Name = "textBoxLookupDoors";
            this.textBoxLookupDoors.ReadOnly = true;
            this.textBoxLookupDoors.Size = new System.Drawing.Size(57, 134);
            this.textBoxLookupDoors.TabIndex = 11;
            this.textBoxLookupDoors.Text = "Doors related to the lookup item";
            // 
            // listBoxLookupDoors
            // 
            this.listBoxLookupDoors.Enabled = false;
            this.listBoxLookupDoors.FormattingEnabled = true;
            this.listBoxLookupDoors.Location = new System.Drawing.Point(585, 73);
            this.listBoxLookupDoors.Name = "listBoxLookupDoors";
            this.listBoxLookupDoors.Size = new System.Drawing.Size(106, 134);
            this.listBoxLookupDoors.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Key Rings";
            // 
            // textBoxLookupKeyrings
            // 
            this.textBoxLookupKeyrings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLookupKeyrings.Location = new System.Drawing.Point(503, 73);
            this.textBoxLookupKeyrings.Multiline = true;
            this.textBoxLookupKeyrings.Name = "textBoxLookupKeyrings";
            this.textBoxLookupKeyrings.ReadOnly = true;
            this.textBoxLookupKeyrings.Size = new System.Drawing.Size(57, 134);
            this.textBoxLookupKeyrings.TabIndex = 8;
            this.textBoxLookupKeyrings.Text = "Key Rings related to the lookup item";
            // 
            // listBoxLookupKeyrings
            // 
            this.listBoxLookupKeyrings.Enabled = false;
            this.listBoxLookupKeyrings.FormattingEnabled = true;
            this.listBoxLookupKeyrings.Location = new System.Drawing.Point(391, 73);
            this.listBoxLookupKeyrings.Name = "listBoxLookupKeyrings";
            this.listBoxLookupKeyrings.Size = new System.Drawing.Size(106, 134);
            this.listBoxLookupKeyrings.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Keys";
            // 
            // textBoxLookupKeys
            // 
            this.textBoxLookupKeys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLookupKeys.Location = new System.Drawing.Point(310, 73);
            this.textBoxLookupKeys.Multiline = true;
            this.textBoxLookupKeys.Name = "textBoxLookupKeys";
            this.textBoxLookupKeys.ReadOnly = true;
            this.textBoxLookupKeys.Size = new System.Drawing.Size(57, 134);
            this.textBoxLookupKeys.TabIndex = 5;
            this.textBoxLookupKeys.Text = "Keys related to the lookup item";
            // 
            // listBoxLookupKeys
            // 
            this.listBoxLookupKeys.Enabled = false;
            this.listBoxLookupKeys.FormattingEnabled = true;
            this.listBoxLookupKeys.Location = new System.Drawing.Point(198, 73);
            this.listBoxLookupKeys.Name = "listBoxLookupKeys";
            this.listBoxLookupKeys.Size = new System.Drawing.Size(106, 134);
            this.listBoxLookupKeys.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "KeyTypes";
            // 
            // textBoxLookupKeysets
            // 
            this.textBoxLookupKeysets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLookupKeysets.Location = new System.Drawing.Point(118, 73);
            this.textBoxLookupKeysets.Multiline = true;
            this.textBoxLookupKeysets.Name = "textBoxLookupKeysets";
            this.textBoxLookupKeysets.ReadOnly = true;
            this.textBoxLookupKeysets.Size = new System.Drawing.Size(57, 134);
            this.textBoxLookupKeysets.TabIndex = 2;
            this.textBoxLookupKeysets.Text = "Keysets related to the lookup item";
            // 
            // listBoxLookupKeysets
            // 
            this.listBoxLookupKeysets.Enabled = false;
            this.listBoxLookupKeysets.FormattingEnabled = true;
            this.listBoxLookupKeysets.Location = new System.Drawing.Point(6, 73);
            this.listBoxLookupKeysets.Name = "listBoxLookupKeysets";
            this.listBoxLookupKeysets.Size = new System.Drawing.Size(106, 134);
            this.listBoxLookupKeysets.TabIndex = 1;
            // 
            // labelLookupResultsTitle
            // 
            this.labelLookupResultsTitle.AutoSize = true;
            this.labelLookupResultsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLookupResultsTitle.Location = new System.Drawing.Point(41, 27);
            this.labelLookupResultsTitle.Name = "labelLookupResultsTitle";
            this.labelLookupResultsTitle.Size = new System.Drawing.Size(71, 24);
            this.labelLookupResultsTitle.TabIndex = 0;
            this.labelLookupResultsTitle.Text = "Results";
            // 
            // groupBoxLookupSource
            // 
            this.groupBoxLookupSource.Controls.Add(this.label6);
            this.groupBoxLookupSource.Controls.Add(this.comboBoxKeyserialLookup);
            this.groupBoxLookupSource.Controls.Add(this.label5);
            this.groupBoxLookupSource.Controls.Add(this.comboBoxKeytypeLookup);
            this.groupBoxLookupSource.Controls.Add(this.label2);
            this.groupBoxLookupSource.Controls.Add(this.comboBoxDoorLookup);
            this.groupBoxLookupSource.Location = new System.Drawing.Point(8, 12);
            this.groupBoxLookupSource.Name = "groupBoxLookupSource";
            this.groupBoxLookupSource.Size = new System.Drawing.Size(358, 200);
            this.groupBoxLookupSource.TabIndex = 1;
            this.groupBoxLookupSource.TabStop = false;
            this.groupBoxLookupSource.Text = "Choose an item to Look up";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Key Serial #:";
            // 
            // comboBoxKeyserialLookup
            // 
            this.comboBoxKeyserialLookup.FormattingEnabled = true;
            this.comboBoxKeyserialLookup.Location = new System.Drawing.Point(81, 138);
            this.comboBoxKeyserialLookup.Name = "comboBoxKeyserialLookup";
            this.comboBoxKeyserialLookup.Size = new System.Drawing.Size(256, 21);
            this.comboBoxKeyserialLookup.TabIndex = 4;
            this.comboBoxKeyserialLookup.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyserialLookup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Key Type:";
            // 
            // comboBoxKeytypeLookup
            // 
            this.comboBoxKeytypeLookup.FormattingEnabled = true;
            this.comboBoxKeytypeLookup.Location = new System.Drawing.Point(81, 87);
            this.comboBoxKeytypeLookup.Name = "comboBoxKeytypeLookup";
            this.comboBoxKeytypeLookup.Size = new System.Drawing.Size(256, 21);
            this.comboBoxKeytypeLookup.TabIndex = 2;
            this.comboBoxKeytypeLookup.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeytypeLookup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Door:";
            // 
            // comboBoxDoorLookup
            // 
            this.comboBoxDoorLookup.FormattingEnabled = true;
            this.comboBoxDoorLookup.Location = new System.Drawing.Point(81, 38);
            this.comboBoxDoorLookup.Name = "comboBoxDoorLookup";
            this.comboBoxDoorLookup.Size = new System.Drawing.Size(256, 21);
            this.comboBoxDoorLookup.TabIndex = 0;
            this.comboBoxDoorLookup.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoorLookup_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(372, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 200);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 489);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageFloorplans.ResumeLayout(false);
            this.panelFloorplans.ResumeLayout(false);
            this.panelFloorplans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageCheckout.ResumeLayout(false);
            this.panelCheckout.ResumeLayout(false);
            this.panelCheckout.PerformLayout();
            this.tabPageKeysets.ResumeLayout(false);
            this.panelKeyset.ResumeLayout(false);
            this.groupBoxKeysetManage.ResumeLayout(false);
            this.groupBoxKeysetManage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageLookup.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.groupBoxLookupResults.ResumeLayout(false);
            this.groupBoxLookupResults.PerformLayout();
            this.groupBoxLookupSource.ResumeLayout(false);
            this.groupBoxLookupSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFloorplans;
        private System.Windows.Forms.Panel panelFloorplans;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TabPage tabPageCheckout;
        private System.Windows.Forms.Panel panelCheckout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageKeysets;
        private System.Windows.Forms.Panel panelKeyset;
        private System.Windows.Forms.TabPage tabPageLookup;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxKeysetManage;
        private System.Windows.Forms.Button buttonAddKeysetKey;
        private System.Windows.Forms.Button buttonRemoveKeysetKey;
        private System.Windows.Forms.ListBox listBoxKeysNotInKeyset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveKeysetChanges;
        private System.Windows.Forms.ListBox listBoxKeysInKeyset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeysetEdit;
        private System.Windows.Forms.Label labelKeysetTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxKeysets;
        private System.Windows.Forms.Button buttonCreateKeyset;
        private System.Windows.Forms.Label labelKeysetChoice;
        private System.Windows.Forms.GroupBox groupBoxLookupResults;
        private System.Windows.Forms.GroupBox groupBoxLookupSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxKeyserialLookup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxKeytypeLookup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDoorLookup;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxLookupKeysets;
        private System.Windows.Forms.ListBox listBoxLookupKeysets;
        private System.Windows.Forms.Label labelLookupResultsTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxLookupDoors;
        private System.Windows.Forms.ListBox listBoxLookupDoors;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxLookupKeyrings;
        private System.Windows.Forms.ListBox listBoxLookupKeyrings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLookupKeys;
        private System.Windows.Forms.ListBox listBoxLookupKeys;
        private System.Windows.Forms.Label label7;
    }
}