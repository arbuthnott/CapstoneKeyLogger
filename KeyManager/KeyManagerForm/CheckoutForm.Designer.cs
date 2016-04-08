namespace KeyManagerForm
{
    partial class CheckoutForm
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
            this.treeViewPeople = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewPeople
            // 
            this.treeViewPeople.FullRowSelect = true;
            this.treeViewPeople.Location = new System.Drawing.Point(12, 57);
            this.treeViewPeople.Name = "treeViewPeople";
            this.treeViewPeople.ShowRootLines = false;
            this.treeViewPeople.Size = new System.Drawing.Size(196, 329);
            this.treeViewPeople.TabIndex = 0;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 398);
            this.Controls.Add(this.treeViewPeople);
            this.Name = "CheckoutForm";
            this.Text = "Key Checkouts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewPeople;
    }
}