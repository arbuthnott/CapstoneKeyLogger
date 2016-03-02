namespace KeyManagerForm
{
    partial class DoorsForm
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
            this.gbxDoors = new System.Windows.Forms.GroupBox();
            this.lbxDoorList = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxAssignedKeyTypes = new System.Windows.Forms.ListBox();
            this.lbxUnassignedKeyTypes = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxDoorGroups = new System.Windows.Forms.ListBox();
            this.gbxDoors.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDoors
            // 
            this.gbxDoors.Controls.Add(this.lbxDoorList);
            this.gbxDoors.Controls.Add(this.btnDelete);
            this.gbxDoors.Controls.Add(this.btnCreate);
            this.gbxDoors.Location = new System.Drawing.Point(12, 12);
            this.gbxDoors.Name = "gbxDoors";
            this.gbxDoors.Size = new System.Drawing.Size(216, 401);
            this.gbxDoors.TabIndex = 0;
            this.gbxDoors.TabStop = false;
            this.gbxDoors.Text = "Doors";
            // 
            // lbxDoorList
            // 
            this.lbxDoorList.FormattingEnabled = true;
            this.lbxDoorList.Location = new System.Drawing.Point(0, 88);
            this.lbxDoorList.Name = "lbxDoorList";
            this.lbxDoorList.Size = new System.Drawing.Size(216, 303);
            this.lbxDoorList.TabIndex = 3;
            this.lbxDoorList.SelectedIndexChanged += new System.EventHandler(this.lbxDoorList_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1, 49);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(215, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(0, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(216, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.lbxUnassignedKeyTypes);
            this.groupBox1.Controls.Add(this.lbxAssignedKeyTypes);
            this.groupBox1.Location = new System.Drawing.Point(246, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 313);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Types";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Door Groups this door belongs to:";
            // 
            // lbxAssignedKeyTypes
            // 
            this.lbxAssignedKeyTypes.FormattingEnabled = true;
            this.lbxAssignedKeyTypes.Location = new System.Drawing.Point(0, 39);
            this.lbxAssignedKeyTypes.Name = "lbxAssignedKeyTypes";
            this.lbxAssignedKeyTypes.Size = new System.Drawing.Size(110, 264);
            this.lbxAssignedKeyTypes.TabIndex = 4;
            // 
            // lbxUnassignedKeyTypes
            // 
            this.lbxUnassignedKeyTypes.FormattingEnabled = true;
            this.lbxUnassignedKeyTypes.Location = new System.Drawing.Point(192, 39);
            this.lbxUnassignedKeyTypes.Name = "lbxUnassignedKeyTypes";
            this.lbxUnassignedKeyTypes.Size = new System.Drawing.Size(110, 264);
            this.lbxUnassignedKeyTypes.TabIndex = 5;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(117, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(69, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove ->";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(117, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "<- Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Unassigned Key Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Assigned Key Types";
            // 
            // lbxDoorGroups
            // 
            this.lbxDoorGroups.FormattingEnabled = true;
            this.lbxDoorGroups.Location = new System.Drawing.Point(414, 12);
            this.lbxDoorGroups.Name = "lbxDoorGroups";
            this.lbxDoorGroups.Size = new System.Drawing.Size(89, 82);
            this.lbxDoorGroups.TabIndex = 7;
            // 
            // DoorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 425);
            this.Controls.Add(this.lbxDoorGroups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxDoors);
            this.Name = "DoorsForm";
            this.Text = "Doors";
            this.Load += new System.EventHandler(this.DoorsForm_Load);
            this.gbxDoors.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDoors;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox lbxDoorList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxUnassignedKeyTypes;
        private System.Windows.Forms.ListBox lbxAssignedKeyTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxDoorGroups;
    }
}