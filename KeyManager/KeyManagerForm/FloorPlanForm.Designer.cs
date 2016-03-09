namespace KeyManagerForm
{
    partial class FloorPlanForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelAdd = new System.Windows.Forms.ToolStripLabel();
            this.cbDoors = new System.Windows.Forms.ToolStripComboBox();
            this.listFloors = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listDoors = new System.Windows.Forms.ListView();
            this.listDoorGroups = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelAdd,
            this.cbDoors});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(150, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(748, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelAdd
            // 
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(131, 22);
            this.labelAdd.Text = "Add Door to Floorplan: ";
            // 
            // cbDoors
            // 
            this.cbDoors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoors.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cbDoors.Name = "cbDoors";
            this.cbDoors.Size = new System.Drawing.Size(121, 25);
            this.cbDoors.ToolTipText = "Add Door";
            this.cbDoors.SelectedIndexChanged += new System.EventHandler(this.cbDoors_SelectedIndexChanged);
            this.cbDoors.Click += new System.EventHandler(this.cbDoors_Click);
            // 
            // listFloors
            // 
            this.listFloors.BackColor = System.Drawing.Color.LightGray;
            this.listFloors.Location = new System.Drawing.Point(12, 28);
            this.listFloors.Name = "listFloors";
            this.listFloors.Size = new System.Drawing.Size(133, 148);
            this.listFloors.TabIndex = 3;
            this.listFloors.UseCompatibleStateImageBehavior = false;
            this.listFloors.SelectedIndexChanged += new System.EventHandler(this.listFloors_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeyManagerForm.Properties.Resources.map1;
            this.pictureBox1.Location = new System.Drawing.Point(151, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(585, 765);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // listDoors
            // 
            this.listDoors.BackColor = System.Drawing.Color.LightGray;
            this.listDoors.Location = new System.Drawing.Point(12, 472);
            this.listDoors.Name = "listDoors";
            this.listDoors.Size = new System.Drawing.Size(133, 321);
            this.listDoors.TabIndex = 4;
            this.listDoors.UseCompatibleStateImageBehavior = false;
            this.listDoors.SelectedIndexChanged += new System.EventHandler(this.listDoors_SelectedIndexChanged);
            this.listDoors.Leave += new System.EventHandler(this.listDoors_Leave);
            // 
            // listDoorGroups
            // 
            this.listDoorGroups.BackColor = System.Drawing.Color.LightGray;
            this.listDoorGroups.Location = new System.Drawing.Point(12, 182);
            this.listDoorGroups.Name = "listDoorGroups";
            this.listDoorGroups.Size = new System.Drawing.Size(133, 284);
            this.listDoorGroups.TabIndex = 5;
            this.listDoorGroups.UseCompatibleStateImageBehavior = false;
            this.listDoorGroups.SelectedIndexChanged += new System.EventHandler(this.listDoorGroups_SelectedIndexChanged);
            this.listDoorGroups.Leave += new System.EventHandler(this.listDoorGroups_Leave);
            // 
            // FloorPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 810);
            this.Controls.Add(this.listDoorGroups);
            this.Controls.Add(this.listDoors);
            this.Controls.Add(this.listFloors);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FloorPlanForm";
            this.Text = "FloorPlanForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView listFloors;
        private System.Windows.Forms.ListView listDoors;
        private System.Windows.Forms.ToolStripComboBox cbDoors;
        private System.Windows.Forms.ToolStripLabel labelAdd;
        private System.Windows.Forms.ListView listDoorGroups;
    }
}