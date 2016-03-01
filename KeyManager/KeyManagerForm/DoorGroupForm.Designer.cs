namespace KeyManagerForm
{
    partial class DoorGroupForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxDoorGroupTabGroups = new System.Windows.Forms.ListBox();
            this.buttonDoorGroupTabNewGroup = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxDoorGroupManage = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxDoorGroupTabNotInGroup = new System.Windows.Forms.ListBox();
            this.buttonDoorGroupTabAddDoor = new System.Windows.Forms.Button();
            this.buttonDoorGroupTabEditGroup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxDoorGroupTabInGroup = new System.Windows.Forms.ListBox();
            this.buttonDoorGroupTabRemoveDoor = new System.Windows.Forms.Button();
            this.labelDoorGroupTabGroupTitle = new System.Windows.Forms.Label();
            this.pictureBoxDoorGroupTab = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBoxDoorGroupManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoorGroupTab)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxDoorGroupTabGroups);
            this.groupBox2.Controls.Add(this.buttonDoorGroupTabNewGroup);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 428);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Door Groups";
            // 
            // listBoxDoorGroupTabGroups
            // 
            this.listBoxDoorGroupTabGroups.FormattingEnabled = true;
            this.listBoxDoorGroupTabGroups.Location = new System.Drawing.Point(10, 51);
            this.listBoxDoorGroupTabGroups.Name = "listBoxDoorGroupTabGroups";
            this.listBoxDoorGroupTabGroups.Size = new System.Drawing.Size(322, 355);
            this.listBoxDoorGroupTabGroups.TabIndex = 5;
            this.listBoxDoorGroupTabGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxDoorGroupTabGroups_SelectedIndexChanged);
            // 
            // buttonDoorGroupTabNewGroup
            // 
            this.buttonDoorGroupTabNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDoorGroupTabNewGroup.Location = new System.Drawing.Point(257, 22);
            this.buttonDoorGroupTabNewGroup.Name = "buttonDoorGroupTabNewGroup";
            this.buttonDoorGroupTabNewGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonDoorGroupTabNewGroup.TabIndex = 4;
            this.buttonDoorGroupTabNewGroup.Text = "New Group";
            this.buttonDoorGroupTabNewGroup.UseVisualStyleBackColor = true;
            this.buttonDoorGroupTabNewGroup.Click += new System.EventHandler(this.buttonDoorGroupTabNewGroup_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(195, 24);
            this.label16.TabIndex = 3;
            this.label16.Text = "Choose a Door Group";
            // 
            // groupBoxDoorGroupManage
            // 
            this.groupBoxDoorGroupManage.Controls.Add(this.label15);
            this.groupBoxDoorGroupManage.Controls.Add(this.listBoxDoorGroupTabNotInGroup);
            this.groupBoxDoorGroupManage.Controls.Add(this.buttonDoorGroupTabAddDoor);
            this.groupBoxDoorGroupManage.Controls.Add(this.buttonDoorGroupTabEditGroup);
            this.groupBoxDoorGroupManage.Controls.Add(this.label3);
            this.groupBoxDoorGroupManage.Controls.Add(this.listBoxDoorGroupTabInGroup);
            this.groupBoxDoorGroupManage.Controls.Add(this.buttonDoorGroupTabRemoveDoor);
            this.groupBoxDoorGroupManage.Controls.Add(this.labelDoorGroupTabGroupTitle);
            this.groupBoxDoorGroupManage.Controls.Add(this.pictureBoxDoorGroupTab);
            this.groupBoxDoorGroupManage.Location = new System.Drawing.Point(356, 12);
            this.groupBoxDoorGroupManage.Name = "groupBoxDoorGroupManage";
            this.groupBoxDoorGroupManage.Size = new System.Drawing.Size(417, 428);
            this.groupBoxDoorGroupManage.TabIndex = 13;
            this.groupBoxDoorGroupManage.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Doors not in Group:";
            // 
            // listBoxDoorGroupTabNotInGroup
            // 
            this.listBoxDoorGroupTabNotInGroup.FormattingEnabled = true;
            this.listBoxDoorGroupTabNotInGroup.Location = new System.Drawing.Point(216, 266);
            this.listBoxDoorGroupTabNotInGroup.Name = "listBoxDoorGroupTabNotInGroup";
            this.listBoxDoorGroupTabNotInGroup.Size = new System.Drawing.Size(195, 121);
            this.listBoxDoorGroupTabNotInGroup.TabIndex = 14;
            this.listBoxDoorGroupTabNotInGroup.SelectedIndexChanged += new System.EventHandler(this.listBoxDoorGroupTabNotInGroup_SelectedIndexChanged);
            // 
            // buttonDoorGroupTabAddDoor
            // 
            this.buttonDoorGroupTabAddDoor.Location = new System.Drawing.Point(216, 393);
            this.buttonDoorGroupTabAddDoor.Name = "buttonDoorGroupTabAddDoor";
            this.buttonDoorGroupTabAddDoor.Size = new System.Drawing.Size(131, 23);
            this.buttonDoorGroupTabAddDoor.TabIndex = 13;
            this.buttonDoorGroupTabAddDoor.Text = "<< Add Selected Door";
            this.buttonDoorGroupTabAddDoor.UseVisualStyleBackColor = true;
            this.buttonDoorGroupTabAddDoor.Click += new System.EventHandler(this.buttonDoorGroupTabAddDoor_Click);
            // 
            // buttonDoorGroupTabEditGroup
            // 
            this.buttonDoorGroupTabEditGroup.Location = new System.Drawing.Point(336, 225);
            this.buttonDoorGroupTabEditGroup.Name = "buttonDoorGroupTabEditGroup";
            this.buttonDoorGroupTabEditGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonDoorGroupTabEditGroup.TabIndex = 12;
            this.buttonDoorGroupTabEditGroup.Text = "Edit Group";
            this.buttonDoorGroupTabEditGroup.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Doors in Group:";
            // 
            // listBoxDoorGroupTabInGroup
            // 
            this.listBoxDoorGroupTabInGroup.FormattingEnabled = true;
            this.listBoxDoorGroupTabInGroup.Location = new System.Drawing.Point(11, 266);
            this.listBoxDoorGroupTabInGroup.Name = "listBoxDoorGroupTabInGroup";
            this.listBoxDoorGroupTabInGroup.Size = new System.Drawing.Size(199, 121);
            this.listBoxDoorGroupTabInGroup.TabIndex = 6;
            this.listBoxDoorGroupTabInGroup.SelectedIndexChanged += new System.EventHandler(this.listBoxDoorGroupTabInGroup_SelectedIndexChanged);
            // 
            // buttonDoorGroupTabRemoveDoor
            // 
            this.buttonDoorGroupTabRemoveDoor.Location = new System.Drawing.Point(64, 393);
            this.buttonDoorGroupTabRemoveDoor.Name = "buttonDoorGroupTabRemoveDoor";
            this.buttonDoorGroupTabRemoveDoor.Size = new System.Drawing.Size(146, 23);
            this.buttonDoorGroupTabRemoveDoor.TabIndex = 5;
            this.buttonDoorGroupTabRemoveDoor.Text = "Remove Selected Door >>";
            this.buttonDoorGroupTabRemoveDoor.UseVisualStyleBackColor = true;
            this.buttonDoorGroupTabRemoveDoor.Click += new System.EventHandler(this.buttonDoorGroupTabRemoveDoor_Click);
            // 
            // labelDoorGroupTabGroupTitle
            // 
            this.labelDoorGroupTabGroupTitle.AutoSize = true;
            this.labelDoorGroupTabGroupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDoorGroupTabGroupTitle.Location = new System.Drawing.Point(8, 222);
            this.labelDoorGroupTabGroupTitle.Name = "labelDoorGroupTabGroupTitle";
            this.labelDoorGroupTabGroupTitle.Size = new System.Drawing.Size(114, 24);
            this.labelDoorGroupTabGroupTitle.TabIndex = 3;
            this.labelDoorGroupTabGroupTitle.Text = "Door Group:";
            // 
            // pictureBoxDoorGroupTab
            // 
            this.pictureBoxDoorGroupTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDoorGroupTab.BackColor = System.Drawing.Color.Black;
            this.pictureBoxDoorGroupTab.Location = new System.Drawing.Point(11, 19);
            this.pictureBoxDoorGroupTab.Name = "pictureBoxDoorGroupTab";
            this.pictureBoxDoorGroupTab.Size = new System.Drawing.Size(400, 200);
            this.pictureBoxDoorGroupTab.TabIndex = 2;
            this.pictureBoxDoorGroupTab.TabStop = false;
            this.pictureBoxDoorGroupTab.Click += new System.EventHandler(this.pictureBoxDoorGroupTab_Click);
            // 
            // DoorGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 447);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxDoorGroupManage);
            this.Name = "DoorGroupForm";
            this.Text = "DoorGroupForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDoorGroupManage.ResumeLayout(false);
            this.groupBoxDoorGroupManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoorGroupTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxDoorGroupTabGroups;
        private System.Windows.Forms.Button buttonDoorGroupTabNewGroup;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxDoorGroupManage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxDoorGroupTabNotInGroup;
        private System.Windows.Forms.Button buttonDoorGroupTabAddDoor;
        private System.Windows.Forms.Button buttonDoorGroupTabEditGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxDoorGroupTabInGroup;
        private System.Windows.Forms.Button buttonDoorGroupTabRemoveDoor;
        private System.Windows.Forms.Label labelDoorGroupTabGroupTitle;
        private System.Windows.Forms.PictureBox pictureBoxDoorGroupTab;
    }
}