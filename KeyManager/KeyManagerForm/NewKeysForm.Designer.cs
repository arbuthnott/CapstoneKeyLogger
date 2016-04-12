namespace KeyManagerForm
{
    partial class NewKeysForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonTypeHint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewTypes = new System.Windows.Forms.TreeView();
            this.buttonCreateType = new System.Windows.Forms.Button();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.buttonDeleteKey = new System.Windows.Forms.Button();
            this.buttonEditKey = new System.Windows.Forms.Button();
            this.buttonDoorHint = new System.Windows.Forms.Button();
            this.buttonUnlockableHint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeleteType = new System.Windows.Forms.Button();
            this.treeViewDoors = new System.Windows.Forms.TreeView();
            this.treeViewUnlockable = new System.Windows.Forms.TreeView();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonCreateCopy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxKeys = new System.Windows.Forms.ListBox();
            this.labelTypeTitle = new System.Windows.Forms.Label();
            this.toolTipKey = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTypeHint
            // 
            this.buttonTypeHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTypeHint.Location = new System.Drawing.Point(170, 39);
            this.buttonTypeHint.Name = "buttonTypeHint";
            this.buttonTypeHint.Size = new System.Drawing.Size(32, 29);
            this.buttonTypeHint.TabIndex = 17;
            this.buttonTypeHint.Text = "?";
            this.buttonTypeHint.UseVisualStyleBackColor = true;
            this.buttonTypeHint.Click += new System.EventHandler(this.buttonTypeHint_Click);
            this.buttonTypeHint.MouseHover += new System.EventHandler(this.buttonTypeHint_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Keys Types:";
            // 
            // treeViewTypes
            // 
            this.treeViewTypes.AllowDrop = true;
            this.treeViewTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTypes.FullRowSelect = true;
            this.treeViewTypes.Indent = 24;
            this.treeViewTypes.ItemHeight = 18;
            this.treeViewTypes.Location = new System.Drawing.Point(24, 74);
            this.treeViewTypes.Name = "treeViewTypes";
            this.treeViewTypes.ShowLines = false;
            this.treeViewTypes.Size = new System.Drawing.Size(178, 384);
            this.treeViewTypes.TabIndex = 15;
            this.treeViewTypes.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewTypes_NodeMouseHover);
            this.treeViewTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTypes_AfterSelect);
            // 
            // buttonCreateType
            // 
            this.buttonCreateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateType.Location = new System.Drawing.Point(24, 39);
            this.buttonCreateType.Name = "buttonCreateType";
            this.buttonCreateType.Size = new System.Drawing.Size(133, 28);
            this.buttonCreateType.TabIndex = 18;
            this.buttonCreateType.Text = "New Key Type";
            this.buttonCreateType.UseVisualStyleBackColor = true;
            this.buttonCreateType.Click += new System.EventHandler(this.buttonCreateType_Click);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.buttonDeleteKey);
            this.groupBoxType.Controls.Add(this.buttonEditKey);
            this.groupBoxType.Controls.Add(this.buttonDoorHint);
            this.groupBoxType.Controls.Add(this.buttonUnlockableHint);
            this.groupBoxType.Controls.Add(this.label4);
            this.groupBoxType.Controls.Add(this.label2);
            this.groupBoxType.Controls.Add(this.buttonDeleteType);
            this.groupBoxType.Controls.Add(this.treeViewDoors);
            this.groupBoxType.Controls.Add(this.treeViewUnlockable);
            this.groupBoxType.Controls.Add(this.buttonRename);
            this.groupBoxType.Controls.Add(this.buttonCreateCopy);
            this.groupBoxType.Controls.Add(this.label1);
            this.groupBoxType.Controls.Add(this.listBoxKeys);
            this.groupBoxType.Controls.Add(this.labelTypeTitle);
            this.groupBoxType.Enabled = false;
            this.groupBoxType.Location = new System.Drawing.Point(223, 12);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(437, 446);
            this.groupBoxType.TabIndex = 19;
            this.groupBoxType.TabStop = false;
            // 
            // buttonDeleteKey
            // 
            this.buttonDeleteKey.Enabled = false;
            this.buttonDeleteKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteKey.Location = new System.Drawing.Point(281, 166);
            this.buttonDeleteKey.Name = "buttonDeleteKey";
            this.buttonDeleteKey.Size = new System.Drawing.Size(133, 28);
            this.buttonDeleteKey.TabIndex = 30;
            this.buttonDeleteKey.Text = "Delete Copy";
            this.buttonDeleteKey.UseVisualStyleBackColor = true;
            this.buttonDeleteKey.Click += new System.EventHandler(this.buttonDeleteKey_Click);
            // 
            // buttonEditKey
            // 
            this.buttonEditKey.Enabled = false;
            this.buttonEditKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditKey.Location = new System.Drawing.Point(281, 132);
            this.buttonEditKey.Name = "buttonEditKey";
            this.buttonEditKey.Size = new System.Drawing.Size(133, 28);
            this.buttonEditKey.TabIndex = 29;
            this.buttonEditKey.Text = "Edit Copy";
            this.buttonEditKey.UseVisualStyleBackColor = true;
            this.buttonEditKey.Click += new System.EventHandler(this.buttonEditKey_Click);
            // 
            // buttonDoorHint
            // 
            this.buttonDoorHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDoorHint.Location = new System.Drawing.Point(382, 208);
            this.buttonDoorHint.Name = "buttonDoorHint";
            this.buttonDoorHint.Size = new System.Drawing.Size(32, 29);
            this.buttonDoorHint.TabIndex = 28;
            this.buttonDoorHint.Text = "?";
            this.buttonDoorHint.UseVisualStyleBackColor = true;
            this.buttonDoorHint.Click += new System.EventHandler(this.buttonDoorHint_Click);
            this.buttonDoorHint.MouseHover += new System.EventHandler(this.buttonDoorHint_MouseHover);
            // 
            // buttonUnlockableHint
            // 
            this.buttonUnlockableHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnlockableHint.Location = new System.Drawing.Point(169, 208);
            this.buttonUnlockableHint.Name = "buttonUnlockableHint";
            this.buttonUnlockableHint.Size = new System.Drawing.Size(32, 29);
            this.buttonUnlockableHint.TabIndex = 27;
            this.buttonUnlockableHint.Text = "?";
            this.buttonUnlockableHint.UseVisualStyleBackColor = true;
            this.buttonUnlockableHint.Click += new System.EventHandler(this.buttonUnlockableHint_Click);
            this.buttonUnlockableHint.MouseHover += new System.EventHandler(this.buttonUnlockableHint_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Other Doors:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Unlockable Doors:";
            // 
            // buttonDeleteType
            // 
            this.buttonDeleteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteType.Location = new System.Drawing.Point(281, 64);
            this.buttonDeleteType.Name = "buttonDeleteType";
            this.buttonDeleteType.Size = new System.Drawing.Size(133, 28);
            this.buttonDeleteType.TabIndex = 24;
            this.buttonDeleteType.Text = "Delete Type";
            this.buttonDeleteType.UseVisualStyleBackColor = true;
            this.buttonDeleteType.Click += new System.EventHandler(this.buttonDeleteType_Click);
            // 
            // treeViewDoors
            // 
            this.treeViewDoors.AllowDrop = true;
            this.treeViewDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewDoors.FullRowSelect = true;
            this.treeViewDoors.Indent = 24;
            this.treeViewDoors.ItemHeight = 18;
            this.treeViewDoors.Location = new System.Drawing.Point(236, 243);
            this.treeViewDoors.Name = "treeViewDoors";
            this.treeViewDoors.ShowLines = false;
            this.treeViewDoors.Size = new System.Drawing.Size(178, 197);
            this.treeViewDoors.TabIndex = 23;
            this.treeViewDoors.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewDoors_NodeMouseHover);
            this.treeViewDoors.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewDoors_DragDrop);
            this.treeViewDoors.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewDoors_DragEnter);
            this.treeViewDoors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewDoors_MouseDown);
            // 
            // treeViewUnlockable
            // 
            this.treeViewUnlockable.AllowDrop = true;
            this.treeViewUnlockable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewUnlockable.FullRowSelect = true;
            this.treeViewUnlockable.Indent = 24;
            this.treeViewUnlockable.ItemHeight = 18;
            this.treeViewUnlockable.Location = new System.Drawing.Point(23, 243);
            this.treeViewUnlockable.Name = "treeViewUnlockable";
            this.treeViewUnlockable.ShowLines = false;
            this.treeViewUnlockable.Size = new System.Drawing.Size(178, 197);
            this.treeViewUnlockable.TabIndex = 22;
            this.treeViewUnlockable.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewUnlockable_NodeMouseHover);
            this.treeViewUnlockable.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewUnlockable_DragDrop);
            this.treeViewUnlockable.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewUnlockable_DragEnter);
            this.treeViewUnlockable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewUnlockable_MouseDown);
            // 
            // buttonRename
            // 
            this.buttonRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRename.Location = new System.Drawing.Point(281, 30);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(133, 28);
            this.buttonRename.TabIndex = 21;
            this.buttonRename.Text = "Rename Type";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonCreateCopy
            // 
            this.buttonCreateCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateCopy.Location = new System.Drawing.Point(281, 98);
            this.buttonCreateCopy.Name = "buttonCreateCopy";
            this.buttonCreateCopy.Size = new System.Drawing.Size(133, 28);
            this.buttonCreateCopy.TabIndex = 20;
            this.buttonCreateCopy.Text = "New Key Copy";
            this.buttonCreateCopy.UseVisualStyleBackColor = true;
            this.buttonCreateCopy.Click += new System.EventHandler(this.buttonCreateCopy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Key Copies:";
            // 
            // listBoxKeys
            // 
            this.listBoxKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxKeys.FormattingEnabled = true;
            this.listBoxKeys.IntegralHeight = false;
            this.listBoxKeys.ItemHeight = 16;
            this.listBoxKeys.Location = new System.Drawing.Point(23, 81);
            this.listBoxKeys.Name = "listBoxKeys";
            this.listBoxKeys.Size = new System.Drawing.Size(235, 113);
            this.listBoxKeys.TabIndex = 18;
            this.listBoxKeys.SelectedIndexChanged += new System.EventHandler(this.listBoxKeys_SelectedIndexChanged);
            // 
            // labelTypeTitle
            // 
            this.labelTypeTitle.AutoSize = true;
            this.labelTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypeTitle.Location = new System.Drawing.Point(19, 27);
            this.labelTypeTitle.Name = "labelTypeTitle";
            this.labelTypeTitle.Size = new System.Drawing.Size(118, 24);
            this.labelTypeTitle.TabIndex = 17;
            this.labelTypeTitle.Text = "Type Name";
            // 
            // NewKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 470);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.buttonCreateType);
            this.Controls.Add(this.buttonTypeHint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeViewTypes);
            this.Name = "NewKeysForm";
            this.Text = "Keys";
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTypeHint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewTypes;
        private System.Windows.Forms.Button buttonCreateType;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.Button buttonDeleteKey;
        private System.Windows.Forms.Button buttonEditKey;
        private System.Windows.Forms.Button buttonDoorHint;
        private System.Windows.Forms.Button buttonUnlockableHint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDeleteType;
        private System.Windows.Forms.TreeView treeViewDoors;
        private System.Windows.Forms.TreeView treeViewUnlockable;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonCreateCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxKeys;
        private System.Windows.Forms.Label labelTypeTitle;
        private System.Windows.Forms.ToolTip toolTipKey;
    }
}