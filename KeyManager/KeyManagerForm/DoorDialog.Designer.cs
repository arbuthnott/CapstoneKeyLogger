namespace KeyManagerForm
{
    partial class DoorDialog
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxRoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLock = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonMap = new System.Windows.Forms.Button();
            this.buttonKeyHint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewKeys = new System.Windows.Forms.TreeView();
            this.buttonUnlockingHint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.treeViewUnlocking = new System.Windows.Forms.TreeView();
            this.buttonLockHint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(100, 24);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "New Door:";
            // 
            // textBoxRoom
            // 
            this.textBoxRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoom.Location = new System.Drawing.Point(171, 48);
            this.textBoxRoom.Name = "textBoxRoom";
            this.textBoxRoom.Size = new System.Drawing.Size(232, 23);
            this.textBoxRoom.TabIndex = 6;
            this.textBoxRoom.TextChanged += new System.EventHandler(this.textBoxRoom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Room Number / Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Same Lock As:";
            // 
            // comboBoxLock
            // 
            this.comboBoxLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLock.FormattingEnabled = true;
            this.comboBoxLock.Location = new System.Drawing.Point(171, 77);
            this.comboBoxLock.Name = "comboBoxLock";
            this.comboBoxLock.Size = new System.Drawing.Size(194, 24);
            this.comboBoxLock.TabIndex = 8;
            this.comboBoxLock.SelectedIndexChanged += new System.EventHandler(this.comboBoxLock_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(12, 414);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 34);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(247, 414);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 34);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(328, 414);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 34);
            this.buttonCreate.TabIndex = 14;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonMap
            // 
            this.buttonMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMap.Location = new System.Drawing.Point(93, 414);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(109, 34);
            this.buttonMap.TabIndex = 17;
            this.buttonMap.Text = "Show on Map";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // buttonKeyHint
            // 
            this.buttonKeyHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeyHint.Location = new System.Drawing.Point(371, 119);
            this.buttonKeyHint.Name = "buttonKeyHint";
            this.buttonKeyHint.Size = new System.Drawing.Size(32, 29);
            this.buttonKeyHint.TabIndex = 20;
            this.buttonKeyHint.Text = "?";
            this.buttonKeyHint.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Keys:";
            // 
            // treeViewKeys
            // 
            this.treeViewKeys.AllowDrop = true;
            this.treeViewKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewKeys.FullRowSelect = true;
            this.treeViewKeys.Indent = 24;
            this.treeViewKeys.ItemHeight = 18;
            this.treeViewKeys.Location = new System.Drawing.Point(225, 154);
            this.treeViewKeys.Name = "treeViewKeys";
            this.treeViewKeys.ShowLines = false;
            this.treeViewKeys.Size = new System.Drawing.Size(178, 237);
            this.treeViewKeys.TabIndex = 18;
            this.treeViewKeys.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewKeys_DragDrop);
            this.treeViewKeys.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewKeys_DragEnter);
            this.treeViewKeys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewKeys_MouseDown);
            // 
            // buttonUnlockingHint
            // 
            this.buttonUnlockingHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnlockingHint.Location = new System.Drawing.Point(162, 119);
            this.buttonUnlockingHint.Name = "buttonUnlockingHint";
            this.buttonUnlockingHint.Size = new System.Drawing.Size(32, 29);
            this.buttonUnlockingHint.TabIndex = 23;
            this.buttonUnlockingHint.Text = "?";
            this.buttonUnlockingHint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Unlocking Keys:";
            // 
            // treeViewUnlocking
            // 
            this.treeViewUnlocking.AllowDrop = true;
            this.treeViewUnlocking.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewUnlocking.FullRowSelect = true;
            this.treeViewUnlocking.Indent = 24;
            this.treeViewUnlocking.ItemHeight = 18;
            this.treeViewUnlocking.Location = new System.Drawing.Point(16, 154);
            this.treeViewUnlocking.Name = "treeViewUnlocking";
            this.treeViewUnlocking.ShowLines = false;
            this.treeViewUnlocking.Size = new System.Drawing.Size(178, 237);
            this.treeViewUnlocking.TabIndex = 21;
            this.treeViewUnlocking.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewUnlocking_DragDrop);
            this.treeViewUnlocking.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewUnlocking_DragOver);
            this.treeViewUnlocking.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewUnlocking_MouseDown);
            // 
            // buttonLockHint
            // 
            this.buttonLockHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLockHint.Location = new System.Drawing.Point(371, 73);
            this.buttonLockHint.Name = "buttonLockHint";
            this.buttonLockHint.Size = new System.Drawing.Size(32, 29);
            this.buttonLockHint.TabIndex = 24;
            this.buttonLockHint.Text = "?";
            this.buttonLockHint.UseVisualStyleBackColor = true;
            // 
            // DoorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 460);
            this.Controls.Add(this.buttonLockHint);
            this.Controls.Add(this.buttonUnlockingHint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeViewUnlocking);
            this.Controls.Add(this.buttonKeyHint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeViewKeys);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.comboBoxLock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Name = "DoorDialog";
            this.Text = "New Door";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLock;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.Button buttonKeyHint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewKeys;
        private System.Windows.Forms.Button buttonUnlockingHint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeViewUnlocking;
        private System.Windows.Forms.Button buttonLockHint;
    }
}