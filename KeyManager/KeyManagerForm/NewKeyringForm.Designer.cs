namespace KeyManagerForm
{
    partial class NewKeyringForm
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
            this.buttonKeyHint = new System.Windows.Forms.Button();
            this.buttonRingHint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewKeys = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewRings = new System.Windows.Forms.TreeView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.toolTipRing = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeyHint
            // 
            this.buttonKeyHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyHint.Location = new System.Drawing.Point(383, 6);
            this.buttonKeyHint.Name = "buttonKeyHint";
            this.buttonKeyHint.Size = new System.Drawing.Size(32, 29);
            this.buttonKeyHint.TabIndex = 14;
            this.buttonKeyHint.Text = "?";
            this.buttonKeyHint.UseVisualStyleBackColor = true;
            this.buttonKeyHint.Click += new System.EventHandler(this.buttonKeyHint_Click);
            this.buttonKeyHint.MouseHover += new System.EventHandler(this.buttonKeyHint_MouseHover);
            // 
            // buttonRingHint
            // 
            this.buttonRingHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRingHint.Location = new System.Drawing.Point(167, 6);
            this.buttonRingHint.Name = "buttonRingHint";
            this.buttonRingHint.Size = new System.Drawing.Size(32, 29);
            this.buttonRingHint.TabIndex = 13;
            this.buttonRingHint.Text = "?";
            this.buttonRingHint.UseVisualStyleBackColor = true;
            this.buttonRingHint.Click += new System.EventHandler(this.buttonRingHint_Click);
            this.buttonRingHint.MouseHover += new System.EventHandler(this.buttonRingHint_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Keys:";
            // 
            // treeViewKeys
            // 
            this.treeViewKeys.AllowDrop = true;
            this.treeViewKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewKeys.FullRowSelect = true;
            this.treeViewKeys.Indent = 24;
            this.treeViewKeys.ItemHeight = 18;
            this.treeViewKeys.Location = new System.Drawing.Point(237, 41);
            this.treeViewKeys.Name = "treeViewKeys";
            this.treeViewKeys.ShowLines = false;
            this.treeViewKeys.Size = new System.Drawing.Size(178, 423);
            this.treeViewKeys.TabIndex = 11;
            this.treeViewKeys.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewKeys_NodeMouseHover);
            this.treeViewKeys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewKeys_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "KeyRings:";
            // 
            // treeViewRings
            // 
            this.treeViewRings.AllowDrop = true;
            this.treeViewRings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewRings.FullRowSelect = true;
            this.treeViewRings.Indent = 24;
            this.treeViewRings.ItemHeight = 18;
            this.treeViewRings.Location = new System.Drawing.Point(21, 41);
            this.treeViewRings.Name = "treeViewRings";
            this.treeViewRings.ShowLines = false;
            this.treeViewRings.Size = new System.Drawing.Size(178, 278);
            this.treeViewRings.TabIndex = 9;
            this.treeViewRings.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewRings_NodeMouseHover);
            this.treeViewRings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRings_AfterSelect);
            this.treeViewRings.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewRings_NodeMouseDoubleClick);
            this.treeViewRings.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewRings_DragDrop);
            this.treeViewRings.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewRings_DragEnter);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(21, 22);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(133, 28);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "New Ring";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonRename);
            this.groupBox1.Controls.Add(this.buttonCreate);
            this.groupBox1.Location = new System.Drawing.Point(24, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 139);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(21, 90);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(133, 28);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Text = "Delete Selected";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Enabled = false;
            this.buttonRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRename.Location = new System.Drawing.Point(21, 56);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(133, 28);
            this.buttonRename.TabIndex = 19;
            this.buttonRename.Text = "Rename Selected";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // NewKeyringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonKeyHint);
            this.Controls.Add(this.buttonRingHint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeViewKeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewRings);
            this.Name = "NewKeyringForm";
            this.Text = "Key Rings";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonKeyHint;
        private System.Windows.Forms.Button buttonRingHint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewRings;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.ToolTip toolTipRing;
    }
}