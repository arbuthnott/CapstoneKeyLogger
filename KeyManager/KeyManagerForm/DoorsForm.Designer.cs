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
            this.gbxKeySets = new System.Windows.Forms.GroupBox();
            this.lbxKeySets = new System.Windows.Forms.ListBox();
            this.lblKeySetTip = new System.Windows.Forms.Label();
            this.gbxKeyTypes = new System.Windows.Forms.GroupBox();
            this.txtKeyTypes = new System.Windows.Forms.TextBox();
            this.lblKeyTypeTip = new System.Windows.Forms.Label();
            this.gbxKeyAssignment = new System.Windows.Forms.GroupBox();
            this.btnRemoveKey = new System.Windows.Forms.Button();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.lblKeysAvailable = new System.Windows.Forms.Label();
            this.lblKeysAssigned = new System.Windows.Forms.Label();
            this.lbxKeysAssigned = new System.Windows.Forms.ListBox();
            this.lbxKeysAvailable = new System.Windows.Forms.ListBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.gbxKeySets.SuspendLayout();
            this.gbxKeyTypes.SuspendLayout();
            this.gbxKeyAssignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxKeySets
            // 
            this.gbxKeySets.Controls.Add(this.lbxKeySets);
            this.gbxKeySets.Controls.Add(this.lblKeySetTip);
            this.gbxKeySets.Location = new System.Drawing.Point(411, 36);
            this.gbxKeySets.Name = "gbxKeySets";
            this.gbxKeySets.Size = new System.Drawing.Size(343, 119);
            this.gbxKeySets.TabIndex = 16;
            this.gbxKeySets.TabStop = false;
            this.gbxKeySets.Text = "Assigned Keysets";
            // 
            // lbxKeySets
            // 
            this.lbxKeySets.FormattingEnabled = true;
            this.lbxKeySets.Location = new System.Drawing.Point(15, 31);
            this.lbxKeySets.Name = "lbxKeySets";
            this.lbxKeySets.Size = new System.Drawing.Size(212, 82);
            this.lbxKeySets.TabIndex = 7;
            // 
            // lblKeySetTip
            // 
            this.lblKeySetTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeySetTip.Location = new System.Drawing.Point(12, 16);
            this.lblKeySetTip.Name = "lblKeySetTip";
            this.lblKeySetTip.Size = new System.Drawing.Size(130, 21);
            this.lblKeySetTip.TabIndex = 10;
            this.lblKeySetTip.Text = "Double click to edit";
            // 
            // gbxKeyTypes
            // 
            this.gbxKeyTypes.Controls.Add(this.txtKeyTypes);
            this.gbxKeyTypes.Controls.Add(this.lblKeyTypeTip);
            this.gbxKeyTypes.Location = new System.Drawing.Point(12, 36);
            this.gbxKeyTypes.Name = "gbxKeyTypes";
            this.gbxKeyTypes.Size = new System.Drawing.Size(353, 119);
            this.gbxKeyTypes.TabIndex = 15;
            this.gbxKeyTypes.TabStop = false;
            this.gbxKeyTypes.Text = "Assigned Keytypes";
            // 
            // txtKeyTypes
            // 
            this.txtKeyTypes.Enabled = false;
            this.txtKeyTypes.Location = new System.Drawing.Point(7, 19);
            this.txtKeyTypes.Multiline = true;
            this.txtKeyTypes.Name = "txtKeyTypes";
            this.txtKeyTypes.Size = new System.Drawing.Size(315, 53);
            this.txtKeyTypes.TabIndex = 8;
            this.txtKeyTypes.Text = "Value1, Value 2, Value3, Value4, Value5";
            // 
            // lblKeyTypeTip
            // 
            this.lblKeyTypeTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyTypeTip.Location = new System.Drawing.Point(4, 77);
            this.lblKeyTypeTip.Name = "lblKeyTypeTip";
            this.lblKeyTypeTip.Size = new System.Drawing.Size(322, 39);
            this.lblKeyTypeTip.TabIndex = 9;
            this.lblKeyTypeTip.Text = "Tip: To add a new key type, add a new key of that type.";
            // 
            // gbxKeyAssignment
            // 
            this.gbxKeyAssignment.Controls.Add(this.btnRemoveKey);
            this.gbxKeyAssignment.Controls.Add(this.btnAddKey);
            this.gbxKeyAssignment.Controls.Add(this.lblKeysAvailable);
            this.gbxKeyAssignment.Controls.Add(this.lblKeysAssigned);
            this.gbxKeyAssignment.Controls.Add(this.lbxKeysAssigned);
            this.gbxKeyAssignment.Controls.Add(this.lbxKeysAvailable);
            this.gbxKeyAssignment.Location = new System.Drawing.Point(6, 157);
            this.gbxKeyAssignment.Name = "gbxKeyAssignment";
            this.gbxKeyAssignment.Size = new System.Drawing.Size(748, 253);
            this.gbxKeyAssignment.TabIndex = 14;
            this.gbxKeyAssignment.TabStop = false;
            this.gbxKeyAssignment.Text = "Key Assignment";
            // 
            // btnRemoveKey
            // 
            this.btnRemoveKey.Location = new System.Drawing.Point(338, 158);
            this.btnRemoveKey.Name = "btnRemoveKey";
            this.btnRemoveKey.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveKey.TabIndex = 6;
            this.btnRemoveKey.Text = "Remove   ->";
            this.btnRemoveKey.UseVisualStyleBackColor = true;
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(338, 113);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(75, 23);
            this.btnAddKey.TabIndex = 5;
            this.btnAddKey.Text = "<-   Add";
            this.btnAddKey.UseVisualStyleBackColor = true;
            // 
            // lblKeysAvailable
            // 
            this.lblKeysAvailable.AutoSize = true;
            this.lblKeysAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeysAvailable.Location = new System.Drawing.Point(417, 20);
            this.lblKeysAvailable.Name = "lblKeysAvailable";
            this.lblKeysAvailable.Size = new System.Drawing.Size(100, 17);
            this.lblKeysAvailable.TabIndex = 4;
            this.lblKeysAvailable.Text = "Keys Available";
            // 
            // lblKeysAssigned
            // 
            this.lblKeysAssigned.AutoSize = true;
            this.lblKeysAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeysAssigned.Location = new System.Drawing.Point(3, 20);
            this.lblKeysAssigned.Name = "lblKeysAssigned";
            this.lblKeysAssigned.Size = new System.Drawing.Size(101, 17);
            this.lblKeysAssigned.TabIndex = 3;
            this.lblKeysAssigned.Text = "Keys Assigned";
            // 
            // lbxKeysAssigned
            // 
            this.lbxKeysAssigned.FormattingEnabled = true;
            this.lbxKeysAssigned.Location = new System.Drawing.Point(6, 50);
            this.lbxKeysAssigned.Name = "lbxKeysAssigned";
            this.lbxKeysAssigned.Size = new System.Drawing.Size(322, 199);
            this.lbxKeysAssigned.TabIndex = 2;
            this.lbxKeysAssigned.SelectedIndexChanged += new System.EventHandler(this.lbxKeysAssigned_SelectedIndexChanged);
            // 
            // lbxKeysAvailable
            // 
            this.lbxKeysAvailable.FormattingEnabled = true;
            this.lbxKeysAvailable.Location = new System.Drawing.Point(420, 50);
            this.lbxKeysAvailable.Name = "lbxKeysAvailable";
            this.lbxKeysAvailable.Size = new System.Drawing.Size(322, 199);
            this.lbxKeysAvailable.TabIndex = 1;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.Location = new System.Drawing.Point(8, 9);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(140, 24);
            this.lblRoomCode.TabIndex = 13;
            this.lblRoomCode.Text = "RoomNumber";
            // 
            // DoorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 425);
            this.Controls.Add(this.gbxKeySets);
            this.Controls.Add(this.gbxKeyTypes);
            this.Controls.Add(this.gbxKeyAssignment);
            this.Controls.Add(this.lblRoomCode);
            this.Name = "DoorsForm";
            this.Text = "DoorsForm";
            this.gbxKeySets.ResumeLayout(false);
            this.gbxKeyTypes.ResumeLayout(false);
            this.gbxKeyTypes.PerformLayout();
            this.gbxKeyAssignment.ResumeLayout(false);
            this.gbxKeyAssignment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxKeySets;
        private System.Windows.Forms.ListBox lbxKeySets;
        private System.Windows.Forms.Label lblKeySetTip;
        private System.Windows.Forms.GroupBox gbxKeyTypes;
        private System.Windows.Forms.TextBox txtKeyTypes;
        private System.Windows.Forms.Label lblKeyTypeTip;
        private System.Windows.Forms.GroupBox gbxKeyAssignment;
        private System.Windows.Forms.Button btnRemoveKey;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.Label lblKeysAvailable;
        private System.Windows.Forms.Label lblKeysAssigned;
        private System.Windows.Forms.ListBox lbxKeysAssigned;
        private System.Windows.Forms.ListBox lbxKeysAvailable;
        private System.Windows.Forms.Label lblRoomCode;
    }
}