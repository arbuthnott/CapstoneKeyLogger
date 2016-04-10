namespace KeyManagerForm
{
    partial class NewPersonnelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPersonnelForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search by Name, Login, or Checked-out Keys";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 26);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Personnel";
            // 
            // listViewResults
            // 
            this.listViewResults.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.listViewResults.HoverSelection = true;
            this.listViewResults.Location = new System.Drawing.Point(12, 117);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.ShowItemToolTips = true;
            this.listViewResults.Size = new System.Drawing.Size(600, 334);
            this.listViewResults.TabIndex = 12;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewResults_ColumnClick);
            this.listViewResults.DoubleClick += new System.EventHandler(this.listViewResults_DoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 30);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(52, 55);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(560, 29);
            this.textBoxSearch.TabIndex = 10;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Results: (double-click to edit)";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(513, 11);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(99, 33);
            this.buttonCreate.TabIndex = 16;
            this.buttonCreate.Text = "Add New";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // NewPersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 463);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "NewPersonnelForm";
            this.Text = "Personnel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreate;
    }
}