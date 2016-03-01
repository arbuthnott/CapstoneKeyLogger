namespace KeyManagerForm
{
    partial class Keys
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
            this.comboBoxKeyTabDoorGroups = new System.Windows.Forms.ComboBox();
            this.comboBoxKeyTabDoors = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.listBoxKeyTabDoorGroups = new System.Windows.Forms.ListBox();
            this.buttonKeyTabEditKey = new System.Windows.Forms.Button();
            this.buttonKeyTabNewKey = new System.Windows.Forms.Button();
            this.listBoxKeyTabDoors = new System.Windows.Forms.ListBox();
            this.buttonKeyTabEditType = new System.Windows.Forms.Button();
            this.comboBoxKeyTabKey = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonKeyTabAddDoor = new System.Windows.Forms.Button();
            this.buttonKeyTabNewType = new System.Windows.Forms.Button();
            this.comboBoxKeyTabKeyType = new System.Windows.Forms.ComboBox();
            this.buttonKeyTabAddGroup = new System.Windows.Forms.Button();
            this.labelKeyTabKeyTypeTitle = new System.Windows.Forms.Label();
            this.pictureBoxKeyTab = new System.Windows.Forms.PictureBox();
            this.listBoxKeyTabKeys = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyTab)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxKeyTabDoorGroups
            // 
            this.comboBoxKeyTabDoorGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabDoorGroups.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabDoorGroups.FormattingEnabled = true;
            this.comboBoxKeyTabDoorGroups.Location = new System.Drawing.Point(607, 412);
            this.comboBoxKeyTabDoorGroups.Name = "comboBoxKeyTabDoorGroups";
            this.comboBoxKeyTabDoorGroups.Size = new System.Drawing.Size(117, 21);
            this.comboBoxKeyTabDoorGroups.TabIndex = 30;
            this.comboBoxKeyTabDoorGroups.Text = "...select group...";
            this.comboBoxKeyTabDoorGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabDoorGroups_SelectedIndexChanged);
            // 
            // comboBoxKeyTabDoors
            // 
            this.comboBoxKeyTabDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabDoors.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabDoors.FormattingEnabled = true;
            this.comboBoxKeyTabDoors.Location = new System.Drawing.Point(382, 412);
            this.comboBoxKeyTabDoors.Name = "comboBoxKeyTabDoors";
            this.comboBoxKeyTabDoors.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKeyTabDoors.TabIndex = 28;
            this.comboBoxKeyTabDoors.Text = "...select door...";
            this.comboBoxKeyTabDoors.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabDoors_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(604, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Unlockable Door Groups:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(380, 267);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Unlockable Doors:";
            // 
            // listBoxKeyTabDoorGroups
            // 
            this.listBoxKeyTabDoorGroups.FormattingEnabled = true;
            this.listBoxKeyTabDoorGroups.Location = new System.Drawing.Point(605, 285);
            this.listBoxKeyTabDoorGroups.Name = "listBoxKeyTabDoorGroups";
            this.listBoxKeyTabDoorGroups.Size = new System.Drawing.Size(192, 121);
            this.listBoxKeyTabDoorGroups.TabIndex = 22;
            this.listBoxKeyTabDoorGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyTabDoorGroups_SelectedIndexChanged);
            // 
            // buttonKeyTabEditKey
            // 
            this.buttonKeyTabEditKey.Location = new System.Drawing.Point(222, 412);
            this.buttonKeyTabEditKey.Name = "buttonKeyTabEditKey";
            this.buttonKeyTabEditKey.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabEditKey.TabIndex = 32;
            this.buttonKeyTabEditKey.Text = "Edit Key";
            this.buttonKeyTabEditKey.UseVisualStyleBackColor = true;
            this.buttonKeyTabEditKey.Click += new System.EventHandler(this.buttonKeyTabEditKey_Click);
            // 
            // buttonKeyTabNewKey
            // 
            this.buttonKeyTabNewKey.Location = new System.Drawing.Point(222, 383);
            this.buttonKeyTabNewKey.Name = "buttonKeyTabNewKey";
            this.buttonKeyTabNewKey.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabNewKey.TabIndex = 29;
            this.buttonKeyTabNewKey.Text = "New Key Copy";
            this.buttonKeyTabNewKey.UseVisualStyleBackColor = true;
            this.buttonKeyTabNewKey.Click += new System.EventHandler(this.buttonKeyTabNewKey_Click);
            // 
            // listBoxKeyTabDoors
            // 
            this.listBoxKeyTabDoors.FormattingEnabled = true;
            this.listBoxKeyTabDoors.Location = new System.Drawing.Point(382, 285);
            this.listBoxKeyTabDoors.Name = "listBoxKeyTabDoors";
            this.listBoxKeyTabDoors.Size = new System.Drawing.Size(192, 121);
            this.listBoxKeyTabDoors.TabIndex = 20;
            this.listBoxKeyTabDoors.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyTabDoors_SelectedIndexChanged);
            // 
            // buttonKeyTabEditType
            // 
            this.buttonKeyTabEditType.Location = new System.Drawing.Point(222, 52);
            this.buttonKeyTabEditType.Name = "buttonKeyTabEditType";
            this.buttonKeyTabEditType.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabEditType.TabIndex = 31;
            this.buttonKeyTabEditType.Text = "Edit Key Type";
            this.buttonKeyTabEditType.UseVisualStyleBackColor = true;
            this.buttonKeyTabEditType.Click += new System.EventHandler(this.buttonKeyTabEditType_Click);
            // 
            // comboBoxKeyTabKey
            // 
            this.comboBoxKeyTabKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabKey.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabKey.FormattingEnabled = true;
            this.comboBoxKeyTabKey.Location = new System.Drawing.Point(51, 52);
            this.comboBoxKeyTabKey.Name = "comboBoxKeyTabKey";
            this.comboBoxKeyTabKey.Size = new System.Drawing.Size(165, 21);
            this.comboBoxKeyTabKey.TabIndex = 24;
            this.comboBoxKeyTabKey.Text = "...select by serial number...";
            this.comboBoxKeyTabKey.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabKey_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Keys:";
            // 
            // buttonKeyTabAddDoor
            // 
            this.buttonKeyTabAddDoor.Location = new System.Drawing.Point(646, 625);
            this.buttonKeyTabAddDoor.Name = "buttonKeyTabAddDoor";
            this.buttonKeyTabAddDoor.Size = new System.Drawing.Size(65, 23);
            this.buttonKeyTabAddDoor.TabIndex = 17;
            this.buttonKeyTabAddDoor.Text = "Add Door";
            this.buttonKeyTabAddDoor.UseVisualStyleBackColor = true;
            // 
            // buttonKeyTabNewType
            // 
            this.buttonKeyTabNewType.Location = new System.Drawing.Point(222, 23);
            this.buttonKeyTabNewType.Name = "buttonKeyTabNewType";
            this.buttonKeyTabNewType.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabNewType.TabIndex = 26;
            this.buttonKeyTabNewType.Text = "New Key Type";
            this.buttonKeyTabNewType.UseVisualStyleBackColor = true;
            this.buttonKeyTabNewType.Click += new System.EventHandler(this.buttonKeyTabNewType_Click);
            // 
            // comboBoxKeyTabKeyType
            // 
            this.comboBoxKeyTabKeyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabKeyType.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabKeyType.FormattingEnabled = true;
            this.comboBoxKeyTabKeyType.Location = new System.Drawing.Point(15, 25);
            this.comboBoxKeyTabKeyType.Name = "comboBoxKeyTabKeyType";
            this.comboBoxKeyTabKeyType.Size = new System.Drawing.Size(201, 21);
            this.comboBoxKeyTabKeyType.TabIndex = 16;
            this.comboBoxKeyTabKeyType.Text = "...choose a type...";
            this.comboBoxKeyTabKeyType.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabKeyType_SelectedIndexChanged);
            // 
            // buttonKeyTabAddGroup
            // 
            this.buttonKeyTabAddGroup.Location = new System.Drawing.Point(728, 410);
            this.buttonKeyTabAddGroup.Name = "buttonKeyTabAddGroup";
            this.buttonKeyTabAddGroup.Size = new System.Drawing.Size(69, 23);
            this.buttonKeyTabAddGroup.TabIndex = 19;
            this.buttonKeyTabAddGroup.Text = "Add Group";
            this.buttonKeyTabAddGroup.UseVisualStyleBackColor = true;
            this.buttonKeyTabAddGroup.Click += new System.EventHandler(this.buttonKeyTabAddGroup_Click);
            // 
            // labelKeyTabKeyTypeTitle
            // 
            this.labelKeyTabKeyTypeTitle.AutoSize = true;
            this.labelKeyTabKeyTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyTabKeyTypeTitle.Location = new System.Drawing.Point(379, 239);
            this.labelKeyTabKeyTypeTitle.Name = "labelKeyTabKeyTypeTitle";
            this.labelKeyTabKeyTypeTitle.Size = new System.Drawing.Size(95, 24);
            this.labelKeyTabKeyTypeTitle.TabIndex = 15;
            this.labelKeyTabKeyTypeTitle.Text = "Key Type:";
            // 
            // pictureBoxKeyTab
            // 
            this.pictureBoxKeyTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxKeyTab.BackColor = System.Drawing.Color.Black;
            this.pictureBoxKeyTab.Location = new System.Drawing.Point(382, 23);
            this.pictureBoxKeyTab.Name = "pictureBoxKeyTab";
            this.pictureBoxKeyTab.Size = new System.Drawing.Size(400, 200);
            this.pictureBoxKeyTab.TabIndex = 14;
            this.pictureBoxKeyTab.TabStop = false;
            this.pictureBoxKeyTab.Click += new System.EventHandler(this.pictureBoxKeyTab_Click);
            // 
            // listBoxKeyTabKeys
            // 
            this.listBoxKeyTabKeys.FormattingEnabled = true;
            this.listBoxKeyTabKeys.Location = new System.Drawing.Point(15, 103);
            this.listBoxKeyTabKeys.Name = "listBoxKeyTabKeys";
            this.listBoxKeyTabKeys.Size = new System.Drawing.Size(201, 329);
            this.listBoxKeyTabKeys.TabIndex = 23;
            this.listBoxKeyTabKeys.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyTabKeys_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Choose a Key Type:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Add Door";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxKeyTabDoorGroups);
            this.Controls.Add(this.comboBoxKeyTabDoors);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBoxKeyTabDoorGroups);
            this.Controls.Add(this.buttonKeyTabEditKey);
            this.Controls.Add(this.buttonKeyTabNewKey);
            this.Controls.Add(this.listBoxKeyTabDoors);
            this.Controls.Add(this.buttonKeyTabEditType);
            this.Controls.Add(this.comboBoxKeyTabKey);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonKeyTabAddDoor);
            this.Controls.Add(this.buttonKeyTabNewType);
            this.Controls.Add(this.comboBoxKeyTabKeyType);
            this.Controls.Add(this.buttonKeyTabAddGroup);
            this.Controls.Add(this.labelKeyTabKeyTypeTitle);
            this.Controls.Add(this.pictureBoxKeyTab);
            this.Controls.Add(this.listBoxKeyTabKeys);
            this.Controls.Add(this.label11);
            this.Name = "Keys";
            this.Text = "Keys";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyTab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKeyTabDoorGroups;
        private System.Windows.Forms.ComboBox comboBoxKeyTabDoors;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBoxKeyTabDoorGroups;
        private System.Windows.Forms.Button buttonKeyTabEditKey;
        private System.Windows.Forms.Button buttonKeyTabNewKey;
        private System.Windows.Forms.ListBox listBoxKeyTabDoors;
        private System.Windows.Forms.Button buttonKeyTabEditType;
        private System.Windows.Forms.ComboBox comboBoxKeyTabKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonKeyTabAddDoor;
        private System.Windows.Forms.Button buttonKeyTabNewType;
        private System.Windows.Forms.ComboBox comboBoxKeyTabKeyType;
        private System.Windows.Forms.Button buttonKeyTabAddGroup;
        private System.Windows.Forms.Label labelKeyTabKeyTypeTitle;
        private System.Windows.Forms.PictureBox pictureBoxKeyTab;
        private System.Windows.Forms.ListBox listBoxKeyTabKeys;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}