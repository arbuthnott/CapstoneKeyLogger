namespace KeyManagerForm
{
    partial class KeysForm
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
            this.listBoxKeyTabKeys = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxKeyManage = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeyTabDeleteType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeytabDeleteKey = new System.Windows.Forms.Button();
            this.buttonKeyTabRemoveDoor = new System.Windows.Forms.Button();
            this.buttonKeyTabRemoveGroup = new System.Windows.Forms.Button();
            this.groupBoxKeyManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxKeyTabDoorGroups
            // 
            this.comboBoxKeyTabDoorGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabDoorGroups.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabDoorGroups.FormattingEnabled = true;
            this.comboBoxKeyTabDoorGroups.Location = new System.Drawing.Point(12, 395);
            this.comboBoxKeyTabDoorGroups.Name = "comboBoxKeyTabDoorGroups";
            this.comboBoxKeyTabDoorGroups.Size = new System.Drawing.Size(204, 21);
            this.comboBoxKeyTabDoorGroups.TabIndex = 30;
            this.comboBoxKeyTabDoorGroups.Text = "...select group...";
            this.comboBoxKeyTabDoorGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabDoorGroups_SelectedIndexChanged);
            // 
            // comboBoxKeyTabDoors
            // 
            this.comboBoxKeyTabDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKeyTabDoors.ForeColor = System.Drawing.Color.Black;
            this.comboBoxKeyTabDoors.FormattingEnabled = true;
            this.comboBoxKeyTabDoors.Location = new System.Drawing.Point(10, 199);
            this.comboBoxKeyTabDoors.Name = "comboBoxKeyTabDoors";
            this.comboBoxKeyTabDoors.Size = new System.Drawing.Size(206, 21);
            this.comboBoxKeyTabDoors.TabIndex = 28;
            this.comboBoxKeyTabDoors.Text = "...select door...";
            this.comboBoxKeyTabDoors.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabDoors_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Unlockable Groups:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Unlockable Doors:";
            // 
            // listBoxKeyTabDoorGroups
            // 
            this.listBoxKeyTabDoorGroups.FormattingEnabled = true;
            this.listBoxKeyTabDoorGroups.Location = new System.Drawing.Point(10, 268);
            this.listBoxKeyTabDoorGroups.Name = "listBoxKeyTabDoorGroups";
            this.listBoxKeyTabDoorGroups.Size = new System.Drawing.Size(281, 121);
            this.listBoxKeyTabDoorGroups.TabIndex = 22;
            this.listBoxKeyTabDoorGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxKeyTabDoorGroups_SelectedIndexChanged);
            // 
            // buttonKeyTabEditKey
            // 
            this.buttonKeyTabEditKey.Location = new System.Drawing.Point(222, 171);
            this.buttonKeyTabEditKey.Name = "buttonKeyTabEditKey";
            this.buttonKeyTabEditKey.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabEditKey.TabIndex = 32;
            this.buttonKeyTabEditKey.Text = "Edit Key";
            this.buttonKeyTabEditKey.UseVisualStyleBackColor = true;
            this.buttonKeyTabEditKey.Click += new System.EventHandler(this.buttonKeyTabEditKey_Click);
            // 
            // buttonKeyTabNewKey
            // 
            this.buttonKeyTabNewKey.Location = new System.Drawing.Point(222, 142);
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
            this.listBoxKeyTabDoors.Location = new System.Drawing.Point(10, 72);
            this.listBoxKeyTabDoors.Name = "listBoxKeyTabDoors";
            this.listBoxKeyTabDoors.Size = new System.Drawing.Size(281, 121);
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
            this.comboBoxKeyTabKey.Location = new System.Drawing.Point(51, 68);
            this.comboBoxKeyTabKey.Name = "comboBoxKeyTabKey";
            this.comboBoxKeyTabKey.Size = new System.Drawing.Size(165, 21);
            this.comboBoxKeyTabKey.TabIndex = 24;
            this.comboBoxKeyTabKey.Text = "...select by serial number...";
            this.comboBoxKeyTabKey.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyTabKey_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Keys:";
            // 
            // buttonKeyTabAddDoor
            // 
            this.buttonKeyTabAddDoor.Location = new System.Drawing.Point(222, 197);
            this.buttonKeyTabAddDoor.Name = "buttonKeyTabAddDoor";
            this.buttonKeyTabAddDoor.Size = new System.Drawing.Size(69, 23);
            this.buttonKeyTabAddDoor.TabIndex = 17;
            this.buttonKeyTabAddDoor.Text = "Add Door";
            this.buttonKeyTabAddDoor.UseVisualStyleBackColor = true;
            this.buttonKeyTabAddDoor.Click += new System.EventHandler(this.buttonKeyTabAddDoor_Click);
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
            this.buttonKeyTabAddGroup.Location = new System.Drawing.Point(222, 393);
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
            this.labelKeyTabKeyTypeTitle.Location = new System.Drawing.Point(6, 16);
            this.labelKeyTabKeyTypeTitle.Name = "labelKeyTabKeyTypeTitle";
            this.labelKeyTabKeyTypeTitle.Size = new System.Drawing.Size(95, 24);
            this.labelKeyTabKeyTypeTitle.TabIndex = 15;
            this.labelKeyTabKeyTypeTitle.Text = "Key Type:";
            // 
            // listBoxKeyTabKeys
            // 
            this.listBoxKeyTabKeys.FormattingEnabled = true;
            this.listBoxKeyTabKeys.Location = new System.Drawing.Point(15, 142);
            this.listBoxKeyTabKeys.Name = "listBoxKeyTabKeys";
            this.listBoxKeyTabKeys.Size = new System.Drawing.Size(201, 290);
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
            // groupBoxKeyManage
            // 
            this.groupBoxKeyManage.Controls.Add(this.buttonKeyTabRemoveGroup);
            this.groupBoxKeyManage.Controls.Add(this.buttonKeyTabRemoveDoor);
            this.groupBoxKeyManage.Controls.Add(this.labelKeyTabKeyTypeTitle);
            this.groupBoxKeyManage.Controls.Add(this.comboBoxKeyTabDoorGroups);
            this.groupBoxKeyManage.Controls.Add(this.buttonKeyTabAddGroup);
            this.groupBoxKeyManage.Controls.Add(this.comboBoxKeyTabDoors);
            this.groupBoxKeyManage.Controls.Add(this.listBoxKeyTabDoors);
            this.groupBoxKeyManage.Controls.Add(this.buttonKeyTabAddDoor);
            this.groupBoxKeyManage.Controls.Add(this.label14);
            this.groupBoxKeyManage.Controls.Add(this.listBoxKeyTabDoorGroups);
            this.groupBoxKeyManage.Controls.Add(this.label13);
            this.groupBoxKeyManage.Location = new System.Drawing.Point(345, 9);
            this.groupBoxKeyManage.Name = "groupBoxKeyManage";
            this.groupBoxKeyManage.Size = new System.Drawing.Size(297, 426);
            this.groupBoxKeyManage.TabIndex = 34;
            this.groupBoxKeyManage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Keys of this type:";
            // 
            // buttonKeyTabDeleteType
            // 
            this.buttonKeyTabDeleteType.Location = new System.Drawing.Point(222, 81);
            this.buttonKeyTabDeleteType.Name = "buttonKeyTabDeleteType";
            this.buttonKeyTabDeleteType.Size = new System.Drawing.Size(117, 23);
            this.buttonKeyTabDeleteType.TabIndex = 36;
            this.buttonKeyTabDeleteType.Text = "Delete Key Type";
            this.buttonKeyTabDeleteType.UseVisualStyleBackColor = true;
            this.buttonKeyTabDeleteType.Click += new System.EventHandler(this.buttonKeyTabDeleteType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "- OR -";
            // 
            // buttonKeytabDeleteKey
            // 
            this.buttonKeytabDeleteKey.Location = new System.Drawing.Point(222, 200);
            this.buttonKeytabDeleteKey.Name = "buttonKeytabDeleteKey";
            this.buttonKeytabDeleteKey.Size = new System.Drawing.Size(117, 23);
            this.buttonKeytabDeleteKey.TabIndex = 38;
            this.buttonKeytabDeleteKey.Text = "Delete Key";
            this.buttonKeytabDeleteKey.UseVisualStyleBackColor = true;
            this.buttonKeytabDeleteKey.Click += new System.EventHandler(this.buttonKeytabDeleteKey_Click);
            // 
            // buttonKeyTabRemoveDoor
            // 
            this.buttonKeyTabRemoveDoor.Location = new System.Drawing.Point(156, 46);
            this.buttonKeyTabRemoveDoor.Name = "buttonKeyTabRemoveDoor";
            this.buttonKeyTabRemoveDoor.Size = new System.Drawing.Size(135, 23);
            this.buttonKeyTabRemoveDoor.TabIndex = 31;
            this.buttonKeyTabRemoveDoor.Text = "Remove Selected Door";
            this.buttonKeyTabRemoveDoor.UseVisualStyleBackColor = true;
            this.buttonKeyTabRemoveDoor.Click += new System.EventHandler(this.buttonKeyTabRemoveDoor_Click);
            // 
            // buttonKeyTabRemoveGroup
            // 
            this.buttonKeyTabRemoveGroup.Location = new System.Drawing.Point(156, 240);
            this.buttonKeyTabRemoveGroup.Name = "buttonKeyTabRemoveGroup";
            this.buttonKeyTabRemoveGroup.Size = new System.Drawing.Size(135, 23);
            this.buttonKeyTabRemoveGroup.TabIndex = 32;
            this.buttonKeyTabRemoveGroup.Text = "Remove Selected Group";
            this.buttonKeyTabRemoveGroup.UseVisualStyleBackColor = true;
            this.buttonKeyTabRemoveGroup.Click += new System.EventHandler(this.buttonKeyTabRemoveGroup_Click);
            // 
            // KeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 442);
            this.Controls.Add(this.buttonKeytabDeleteKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonKeyTabDeleteType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxKeyManage);
            this.Controls.Add(this.buttonKeyTabEditKey);
            this.Controls.Add(this.buttonKeyTabNewKey);
            this.Controls.Add(this.buttonKeyTabEditType);
            this.Controls.Add(this.comboBoxKeyTabKey);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonKeyTabNewType);
            this.Controls.Add(this.comboBoxKeyTabKeyType);
            this.Controls.Add(this.listBoxKeyTabKeys);
            this.Controls.Add(this.label11);
            this.Name = "KeysForm";
            this.Text = "Keys";
            this.groupBoxKeyManage.ResumeLayout(false);
            this.groupBoxKeyManage.PerformLayout();
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
        private System.Windows.Forms.ListBox listBoxKeyTabKeys;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxKeyManage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeyTabDeleteType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKeytabDeleteKey;
        private System.Windows.Forms.Button buttonKeyTabRemoveGroup;
        private System.Windows.Forms.Button buttonKeyTabRemoveDoor;
    }
}