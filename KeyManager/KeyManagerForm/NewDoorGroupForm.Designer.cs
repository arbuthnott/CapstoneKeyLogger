namespace KeyManagerForm
{
    partial class NewDoorGroupForm
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
            this.buttonDoorGroupHint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewDoorGroup = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonMap = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.treeViewDoors = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDoorHint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDoorGroupHint
            // 
            this.buttonDoorGroupHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDoorGroupHint.Location = new System.Drawing.Point(231, 4);
            this.buttonDoorGroupHint.Name = "buttonDoorGroupHint";
            this.buttonDoorGroupHint.Size = new System.Drawing.Size(32, 29);
            this.buttonDoorGroupHint.TabIndex = 9;
            this.buttonDoorGroupHint.Text = "?";
            this.buttonDoorGroupHint.UseVisualStyleBackColor = true;
            this.buttonDoorGroupHint.Click += new System.EventHandler(this.buttonDoorGroupHint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Door Groups:";
            // 
            // treeViewDoorGroup
            // 
            this.treeViewDoorGroup.AllowDrop = true;
            this.treeViewDoorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewDoorGroup.FullRowSelect = true;
            this.treeViewDoorGroup.Indent = 24;
            this.treeViewDoorGroup.ItemHeight = 18;
            this.treeViewDoorGroup.Location = new System.Drawing.Point(27, 39);
            this.treeViewDoorGroup.Name = "treeViewDoorGroup";
            this.treeViewDoorGroup.ShowLines = false;
            this.treeViewDoorGroup.Size = new System.Drawing.Size(236, 345);
            this.treeViewDoorGroup.TabIndex = 7;
            this.treeViewDoorGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDoorGroup_AfterSelect);
            this.treeViewDoorGroup.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDoorGroup_NodeMouseDoubleClick);
            this.treeViewDoorGroup.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewDoorGroup_DragDrop);
            this.treeViewDoorGroup.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewDoorGroup_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonRename);
            this.groupBox1.Controls.Add(this.buttonMap);
            this.groupBox1.Controls.Add(this.buttonCreate);
            this.groupBox1.Location = new System.Drawing.Point(27, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 106);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(126, 56);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 28);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Enabled = false;
            this.buttonRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRename.Location = new System.Drawing.Point(126, 22);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(99, 28);
            this.buttonRename.TabIndex = 19;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonMap
            // 
            this.buttonMap.Enabled = false;
            this.buttonMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMap.Location = new System.Drawing.Point(11, 56);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(99, 28);
            this.buttonMap.TabIndex = 18;
            this.buttonMap.Text = "Show on Map";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(11, 22);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(99, 28);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "New Group";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // treeViewDoors
            // 
            this.treeViewDoors.AllowDrop = true;
            this.treeViewDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewDoors.FullRowSelect = true;
            this.treeViewDoors.Indent = 24;
            this.treeViewDoors.ItemHeight = 18;
            this.treeViewDoors.Location = new System.Drawing.Point(289, 39);
            this.treeViewDoors.Name = "treeViewDoors";
            this.treeViewDoors.ShowLines = false;
            this.treeViewDoors.Size = new System.Drawing.Size(178, 457);
            this.treeViewDoors.TabIndex = 11;
            this.treeViewDoors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewDoors_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Doors:";
            // 
            // buttonDoorHint
            // 
            this.buttonDoorHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDoorHint.Location = new System.Drawing.Point(435, 4);
            this.buttonDoorHint.Name = "buttonDoorHint";
            this.buttonDoorHint.Size = new System.Drawing.Size(32, 29);
            this.buttonDoorHint.TabIndex = 13;
            this.buttonDoorHint.Text = "?";
            this.buttonDoorHint.UseVisualStyleBackColor = true;
            this.buttonDoorHint.Click += new System.EventHandler(this.buttonDoorHint_Click);
            // 
            // NewDoorGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 508);
            this.Controls.Add(this.buttonDoorHint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeViewDoors);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDoorGroupHint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewDoorGroup);
            this.Name = "NewDoorGroupForm";
            this.Text = "NewDoorGroupForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDoorGroupHint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewDoorGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TreeView treeViewDoors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDoorHint;
    }
}